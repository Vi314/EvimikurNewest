using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class EmployeeYearlyVacationService : IEmployeeYearlyVacationService
{
    private readonly IEmployeeYearlyVacationRepository _repository;
    private readonly IEmployeeVacationService _vacationService;

    public EmployeeYearlyVacationService(IEmployeeYearlyVacationRepository repository, IEmployeeVacationService vacationService)
    {
        _repository = repository;
        _vacationService = vacationService;
    }

    public HttpStatusCode Create(EmployeeYearlyVacationModel employeeYearlyVacation)
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

    public HttpStatusCode Delete(int id)
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

    public IEnumerable<EmployeeYearlyVacationModel> GetAll()
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

    public EmployeeYearlyVacationModel GetById(int id)
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

    public HttpStatusCode Update(EmployeeYearlyVacationModel employeeYearlyVacation)
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
    public HttpStatusCode CalculateAll()
    {
        _repository.ResetYearlyVacations();
        var result = HttpStatusCode.OK;
        var vacations = _vacationService.GetAll().ToList().Where(i => i.IsApproved == true);

        //Getting all vacations used
        foreach (var i in vacations)
        {
            var year = i.VacationStart.Year;
            i.VacationDuration = (i.VacationEnd - i.VacationStart).Days;

            //Gets the amount of vacation in days
            var workYears = year - i.Employee.HiredDate.Year;
            var vacationDays = VacationsFromWorkYears(workYears);

            //Gets the yearlyVacation or creates a new one
            EmployeeYearlyVacationModel yearlyVacation = _repository.GetByYearAndEmployee(year, i.EmployeeId);

            yearlyVacation.YearlyVacationDays = vacationDays;
            yearlyVacation.VacationDaysUsed = (yearlyVacation.VacationDaysUsed ?? new()) + i.VacationDuration;

            result = yearlyVacation.Id == 0 ? Create(yearlyVacation) : Update(yearlyVacation);
        }
        return result;
    }

    /// <summary>
    /// Çalışma yılına göre Tatil günü hesaplar
    /// </summary>
    /// <param name="years">Çalışma Yılı</param>
    /// <returns>Yıllık İzin (gün)</returns>
    public int VacationsFromWorkYears(int? years)
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
                return 14;
        }
    }

    public void ResetYearlyVacations(List<EmployeeYearlyVacationModel> model)
    {
        var i = model;

        foreach (var z in i)
        {
            z.VacationDaysUsed = 0;
        }
        UpdateRange(i);
    }

    public HttpStatusCode CreateRange(IEnumerable<EmployeeYearlyVacationModel> Thing)
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

    public HttpStatusCode UpdateRange(IEnumerable<EmployeeYearlyVacationModel> Thing)
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