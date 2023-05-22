﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class EmployeeVacationService : IEmployeeVacationService
{
    private readonly IEmployeeVacationRepository _repository;

    public EmployeeVacationService(IEmployeeVacationRepository repository)
    {
        _repository = repository;
    }
    public string CreateOne(EmployeeVacation employeeVacation)
    {
        try
        {
            //if (employeeVacation.IsApproved)
            //{
            //    var yearlyVacations = _yearlyVacationService.GetAll();
            //    var yearlyVacation = yearlyVacations.Where(x => x.EmployeeId == employeeVacation.EmployeeId && x.Year == DateTime.Now.Year).FirstOrDefault();

            //    var usedDays = (employeeVacation.VacationEnd -employeeVacation.VacationStart ).Value.Days;
            //    yearlyVacation.VacationDaysUsed += usedDays;
            //    _yearlyVacationService.UpdateOne(yearlyVacation);
            //}
            return _repository.Create(employeeVacation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string UpdateOne(EmployeeVacation employeeVacation)
    {
        try
        {
            //if (employeeVacation.IsApproved)
            //{
            //    var yearlyVacations = _yearlyVacationService.GetAll();
            //    var yearlyVacation = yearlyVacations.Where(x => x.EmployeeId == employeeVacation.EmployeeId && x.Year == DateTime.Now.Year).FirstOrDefault();

            //    var usedDays = (employeeVacation.VacationEnd - employeeVacation.VacationStart ).Value.Days;
            //    yearlyVacation.VacationDaysUsed += usedDays;
            //    _yearlyVacationService.UpdateOne(yearlyVacation);
            //}
            return _repository.Update(employeeVacation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string DeleteEmployeeVacation(int id)
    {
        try
        {
            return _repository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public IEnumerable<EmployeeVacation> GetEmployeeVacation()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public EmployeeVacation GetById(int id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}
