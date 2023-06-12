using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class SupplierRepository : BaseRepository<SupplierModel>, ISupplierRepository
    {
        private readonly Context _context;

        public SupplierRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<SupplierModel> GetAll()
        {
            var suppliers = from s in _context.Suppliers
                            join u in _context.Users on s.UserId equals u.Id into uu
                            from u in uu.DefaultIfEmpty()
                            where s.State != EntityState.Deleted
                            select new SupplierModel
                            {
                                ApprovalState = s.ApprovalState,
                                State = s.State,
                                SupplierGrade = s.SupplierGrade,
                                CompanyName = s.CompanyName,
                                CreatedDate = s.CreatedDate,
                                Id = s.Id,
                                UserId = s.UserId,
                                User = u ?? new(),
                            };

            return suppliers;
        }

        public override SupplierModel GetById(int id)
        {
            var supplier = (from s in _context.Suppliers
                            join u in _context.Users on s.UserId equals u.Id into uu
                            from u in uu.DefaultIfEmpty()
                            where s.State != EntityState.Deleted
                            select new SupplierModel
                            {
                                ApprovalState = s.ApprovalState,
                                State = s.State,
                                SupplierGrade = s.SupplierGrade,
                                CompanyName = s.CompanyName,
                                CreatedDate = s.CreatedDate,
                                Id = s.Id,
                                UserId = s.UserId,
                                User = u ?? new(),
                            }).FirstOrDefault();

            return supplier ?? new();
        }
    }
}