﻿using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class EmployeeMonthlyWagesRepository : BaseRepository<EmployeeMonthlyWagesModel>, IEmployeeMonthlyWagesRepository
    {
        private readonly DataAccess.Context _context;

        public EmployeeMonthlyWagesRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<EmployeeMonthlyWagesModel> GetAll()
        {
            var wages = from mw in _context.EmployeeMonthlyWages
                        join e in _context.Employees on mw.EmployeeId equals e.Id
                        where mw.State != EntityState.Deleted
                         && e.State != EntityState.Deleted
                        select new EmployeeMonthlyWagesModel
                        {
                            CreatedDate = mw.CreatedDate,
                            Employee = e,
                            EmployeeId = mw.EmployeeId,
                            Id = mw.Id,
                            Month = mw.Month,
                            State = mw.State,
                            Wage = mw.Wage,
                        };
            return wages;
        }

        public override EmployeeMonthlyWagesModel GetById(int id)
        {
            var wage = (from mw in _context.EmployeeMonthlyWages
                        join e in _context.Employees on mw.EmployeeId equals e.Id
                        where mw.State != EntityState.Deleted
                         && e.State != EntityState.Deleted
                        select new EmployeeMonthlyWagesModel
                        {
                            CreatedDate = mw.CreatedDate,
                            Employee = e,
                            EmployeeId = mw.EmployeeId,
                            Id = mw.Id,
                            Month = mw.Month,
                            State = mw.State,
                            Wage = mw.Wage,
                        }).FirstOrDefault();
            return wage ?? new();
        }
    }
}