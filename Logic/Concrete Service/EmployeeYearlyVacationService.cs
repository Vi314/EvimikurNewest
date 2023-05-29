using System.Net;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service;

public class EmployeeYearlyVacationService : IEmployeeYearlyVacationService
{
    private readonly IEmployeeYearlyVacationRepository _repository;
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeVacationService _vacationService;

    public EmployeeYearlyVacationService(IEmployeeYearlyVacationRepository repository, IEmployeeService employeeService,IEmployeeVacationService vacationService)
    {
        _repository = repository;
        _employeeService = employeeService;
        _vacationService = vacationService;
    }

    public HttpStatusCode CreateOne(EmployeeYearlyVacation employeeYearlyVacation)
    {
        try
        {
            return _repository.Create(employeeYearlyVacation);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteOne(int id)
    {
        try
        {
            return _repository.Delete(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
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

    public HttpStatusCode UpdateOne(EmployeeYearlyVacation employeeYearlyVacation)
    {
        try
        {
            return _repository.Update(employeeYearlyVacation);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

	/// <summary>
	/// Kullanılan izin günlerine göre kalan yıllık izinleri hesaplar
	/// </summary>
	public void CalculateAll()
    {
        ResetYearlyVacations();

		var vacations = _vacationService.GetEmployeeVacation().ToList();

		//Getting all vacations used
		foreach (var i in vacations)
        {
            if (i.IsApproved == false){ continue; }

			var yearlyVacations = _repository.GetAll().ToList();

			var year = i.VacationStart.Value.Year;
            i.VacationDuration = (i.VacationEnd - i.VacationStart).Value.Days;

			//Gets the amount of vacation in days
			var workYears = year - i.Employee.HiredDate.Value.Year;
			var vacationDays = VacationsFromWorkYears(workYears);

			EmployeeYearlyVacation yearlyVacation = yearlyVacations.Where(x => x.Year == year && x.EmployeeId == i.EmployeeId).FirstOrDefault() ?? new EmployeeYearlyVacation { EmployeeId = i.EmployeeId,Year = year};

            yearlyVacation.YearlyVacationDays = vacationDays;
            yearlyVacation.VacationDaysUsed = (yearlyVacation.VacationDaysUsed ?? new()) + i.VacationDuration;

            var result = yearlyVacation.Id == 0 ? CreateOne(yearlyVacation) : UpdateOne(yearlyVacation);
        }
        return;
    }

	/// <summary>
	/// Çalışma yılına göre Tatil günü hesaplar
	/// </summary>
	/// <param name="years">Çalışma Yılı</param>
	/// <returns>Yıllık İzin (gün)</returns>
	int VacationsFromWorkYears(int years)
    {
        switch (years)
        {
			case >= 11:
				return 28;
			case >= 6:
				return 21;
			case >= 0:
                return 14;
            default:
                return 0;
        }
	}
    void ResetYearlyVacations()
    {
        var i = _repository.GetAll().ToList();
        foreach (var z in i)
        {
            z.VacationDaysUsed = 0;
        }
        UpdateRange(i);
    }

	public HttpStatusCode CreateRange(IEnumerable<EmployeeYearlyVacation> Thing)
	{
        try
        {
            return _repository.CreateRange(Thing);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
            throw;
        }
	}
	public HttpStatusCode UpdateRange(IEnumerable<EmployeeYearlyVacation> Thing)
	{
		try
		{
            return _repository.UpdateRange(Thing);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return HttpStatusCode.BadRequest;
			throw;
		}
	}
	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{

		try
		{
            return _repository.DeleteRange(id);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return HttpStatusCode.BadRequest;
			throw;
		}
	}
}
