using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository
{
	public class SupplierContractRepository : BaseRepository<SupplierContract>, ISupplierContractRepository
	{
		private readonly Context _context;

		public SupplierContractRepository(Context context) : base(context)
		{
			_context = context;
		}

        public override IEnumerable<SupplierContract> GetAll()
        {
			var contracts = from sc in _context.SupplierContracts
							join s in _context.Suppliers on sc.SupplierId equals s.Id into ss from s in ss.DefaultIfEmpty()
							join p in _context.Products on sc.ProductId equals p.Id into sp from p in sp.DefaultIfEmpty()
							where sc.State != EntityState.Deleted
								&& s.State != EntityState.Deleted
								&& p.State != EntityState.Deleted
							select new SupplierContract
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
								ContractEndDate	= sc.ContractEndDate,
								Supplier = s ?? new(),
								Product = p ?? new(),
							};

            return contracts;
        }

		public override SupplierContract GetById(int id)
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
							select new SupplierContract
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
