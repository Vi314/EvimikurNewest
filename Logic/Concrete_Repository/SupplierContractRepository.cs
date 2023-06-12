using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class SupplierContractRepository : BaseRepository<SupplierContractModel>, ISupplierContractRepository
    {
        private readonly Context _context;

        public SupplierContractRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<SupplierContractModel> GetAll()
        {
            var contracts = from sc in _context.SupplierContracts
                            join s in _context.Suppliers on sc.SupplierId equals s.Id into ss from s in ss.DefaultIfEmpty()
                            join p in _context.Products  on sc.ProductId  equals p.Id into sp from p in sp.DefaultIfEmpty()
                            where sc.State != EntityState.Deleted
                                && s.State != EntityState.Deleted
                                && p.State != EntityState.Deleted
                            select new SupplierContractModel
                            {
                                Amount = sc.Amount,
                                SupplierId = sc.SupplierId,
                                State = sc.State,
                                ShippingCost = sc.ShippingCost,
                                ProductId = sc.ProductId,
                                Price = sc.Price,
                                PaymentDate = sc.PaymentDate,
                                ContractSignDate = sc.ContractSignDate,
                                Id = sc.Id,
                                CreatedDate = sc.CreatedDate,
                                ContractState = sc.ContractState,
                                ContractEndDate = sc.ContractEndDate,
                                Supplier = s ?? new(),
                                Product = p ?? new(),
                            };

            return contracts;
        }

        public IEnumerable<SupplierContractModel> GetAll(int userId)
        {
            var contracts = from sc in _context.SupplierContracts
                            join s in _context.Suppliers on sc.SupplierId equals s.Id into ss
                            from s in ss.DefaultIfEmpty()
                            join p in _context.Products on sc.ProductId equals p.Id into sp
                            from p in sp.DefaultIfEmpty()
                            where sc.State != EntityState.Deleted
                                && s.State != EntityState.Deleted
                                && p.State != EntityState.Deleted
                                && s.UserId == userId
                            select new SupplierContractModel
                            {
                                Amount = sc.Amount,
                                SupplierId = sc.SupplierId,
                                State = sc.State,
                                ShippingCost = sc.ShippingCost,
                                ProductId = sc.ProductId,
                                Price = sc.Price,
                                PaymentDate = sc.PaymentDate,
                                ContractSignDate = sc.ContractSignDate,
                                Id = sc.Id,
                                CreatedDate = sc.CreatedDate,
                                ContractState = sc.ContractState,
                                ContractEndDate = sc.ContractEndDate,
                                Supplier = s ?? new(),
                                Product = p ?? new(),
                            };

            return contracts ?? throw new Exception("NO GOD DAMN SUPPLIER WITH THAT USERID");
        }

        public override SupplierContractModel GetById(int id)
        {
            var contract = (from sc in _context.SupplierContracts
                            join s in _context.Suppliers on sc.SupplierId equals s.Id into ss
                            from s in ss.DefaultIfEmpty()
                            join p in _context.Products on sc.ProductId equals p.Id into sp
                            from p in sp.DefaultIfEmpty()
                            where sc.Id == p.Id
                                && sc.State != EntityState.Deleted
                                && s.State != EntityState.Deleted
                                && p.State != EntityState.Deleted
                            select new SupplierContractModel
                            {
                                Amount = sc.Amount,
                                SupplierId = sc.SupplierId,
                                State = sc.State,
                                ShippingCost = sc.ShippingCost,
                                ProductId = sc.ProductId,
                                Price = sc.Price,
                                PaymentDate = sc.PaymentDate,
                                ContractSignDate = sc.ContractSignDate,
                                Id = sc.Id,
                                CreatedDate = sc.CreatedDate,
                                ContractState = sc.ContractState,
                                ContractEndDate = sc.ContractEndDate,
                                Supplier = s ?? new(),
                                Product = p ?? new(),
                            }).FirstOrDefault();

            return contract ?? new();
        }
    }
}