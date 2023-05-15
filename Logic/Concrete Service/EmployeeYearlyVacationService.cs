using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service
{
    public class EmployeeYearlyVacationService : IEmployeeYearlyVacationService
    {
        private readonly IRepository<EmployeeYearlyVacation> _repository;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeVacationService _vacationService;

        public EmployeeYearlyVacationService(IRepository<EmployeeYearlyVacation> repository, IEmployeeService employeeService,IEmployeeVacationService vacationService)
        {
            _repository = repository;
            _employeeService = employeeService;
            _vacationService = vacationService;
        }

        public string CreateOne(EmployeeYearlyVacation employeeYearlyVacation)
        {
            try
            {
                return _repository.Create(employeeYearlyVacation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }

        public string DeleteOne(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }

        public IEnumerable<EmployeeYearlyVacation> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public EmployeeYearlyVacation GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string UpdateOne(EmployeeYearlyVacation employeeYearlyVacation)
        {
            try
            {
                return _repository.Update(employeeYearlyVacation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }
        public void UpdateUsedVacations()
        {
            var vacations = _vacationService.GetEmployeeVacation();
            var approvedVacations = vacations.Where(x => x.IsApproved == true).ToList();
            var years = approvedVacations.Select(x => x.VacationStart.Value.Year).ToList();
            var yearlyVacations = _repository.GetAll();

            //Going through each year there are vacations for
            foreach (var item in years)
            {
                Dictionary<int?, int?> employeesAndVacations = new Dictionary<int?, int?>();

                //Adding the vacations by employee into the dictionary
                foreach (var vacation in approvedVacations)
                {
                    if (vacation.VacationStart.Value.Year == item)
                    {
                        var vacationLengthInDays = (vacation.VacationEnd - vacation.VacationStart).Value.Days;
                        if (employeesAndVacations.ContainsKey(vacation.EmployeeId))
                        {
                            employeesAndVacations[vacation.EmployeeId] += vacationLengthInDays;
                        }
                        else
                        {
                            employeesAndVacations.Add(vacation.EmployeeId, vacationLengthInDays);
                        }
                    }
                };

                foreach (KeyValuePair<int?, int?> i in employeesAndVacations)
                {
                    var yearlyVacation = yearlyVacations.Where(x => x.Year == item && x.EmployeeId == i.Key).FirstOrDefault();
                    if (yearlyVacation != null)
                    {
                        yearlyVacation.VacationDaysUsed = i.Value;

                        _repository.Update(yearlyVacation);
                    }
                }
            }
        }

        public void CalculateAll()
        {
            var employees = _employeeService.GetEmployees();
            var yearlyVacations = _repository.GetAll();
            var vacationInDays = 0;
            var workYears = 0;
            var thisYear = DateTime.Now.Year;

            foreach (var item in yearlyVacations)
            {
                item.VacationDaysUsed = 0;
                _repository.Update(item);
            }

            foreach (var employee in employees)
            {
                bool isRecordMade = false;

                foreach (var yearlyVacation in yearlyVacations)
                {
                    if (employee.Id != yearlyVacation.EmployeeId)
                    {
                        continue;
                    }
                    if (yearlyVacation.Year == thisYear)
                    {
                        isRecordMade = true;
                        break;
                    }
                }

                if (isRecordMade)
                {
                    UpdateUsedVacations();
                    continue;
                }

                workYears = thisYear - employee.HiredDate.Value.Year;

                if (workYears >= 0 && workYears <= 5)
                {
                    vacationInDays = 14;
                }
                else if (workYears >= 6 && workYears <= 10)
                {
                    vacationInDays = 21;
                }
                else if (workYears >= 11 )
                {
                    vacationInDays = 28;
                }

                EmployeeYearlyVacation vacation = new EmployeeYearlyVacation
                {
                    YearlyVacationDays = vacationInDays,
                    EmployeeId = employee.Id,
                    Year = DateTime.Now.Year,
                };
                CreateOne(vacation);
                UpdateUsedVacations();
            }
        }
    }
}
