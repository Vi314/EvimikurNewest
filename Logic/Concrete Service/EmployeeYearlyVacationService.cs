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

        public EmployeeYearlyVacationService(IRepository<EmployeeYearlyVacation> repository, IEmployeeService employeeService)
        {
            _repository = repository;
            _employeeService = employeeService;
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
        public string CalculateAll()
        {
            var employees = _employeeService.GetEmployees();
            var yearlyVacations = _repository.GetAll();
            var vacationInDays = 0;
            var workYears = 0;
            var thisYear = DateTime.Now.Year;

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
                    VacationDaysUsed = 0,
                    EmployeeId = employee.Id,
                    Year = DateTime.Now.Year,
                };
                CreateOne(vacation);
            }
            return "Calculated";
        }

    }
}
