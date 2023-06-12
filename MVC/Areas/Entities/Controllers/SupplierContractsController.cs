using Entity.Identity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SupplierContractsController : Controller
    {
        private readonly ISupplierContractService _service;
        private readonly ISupplierContractMapper _mapper;
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public SupplierContractsController(ISupplierContractService service,
            ISupplierContractMapper mapper,
            ISupplierService supplierService,
            IProductService productService,
            UserManager<AppUser> userManager)
        {
            _service = service;
            _mapper = mapper;
            _supplierService = supplierService;
            _productService = productService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            int currentUserId = user == null ? 0 : user.Id;

            var suppliersContracts = _service.GetSupplierContractsByUser(currentUserId).ToList();
            var supplierContractsDTO = new List<SupplierContractDTO>();
            foreach (var item in suppliersContracts)
            {
                if (item.State != EntityState.Deleted)
                {
                    supplierContractsDTO.Add(_mapper.FromEntity(item));
                }
            }
            return View(supplierContractsDTO);
        }

        public IActionResult CreateSupplierContract()
        {
            ViewBag.Products = _productService.GetProducts().ToList();
            ViewBag.Suppliers = _supplierService.GetSuppliers().ToList();
            SupplierContractDTO supplierContractDTO = new();
            return View(supplierContractDTO);
        }

        [HttpPost]
        public IActionResult CreateSupplierContract(SupplierContractDTO supplierContractDTO)
        {
            var products = _productService.GetProducts().ToList();
            var suppliers = _supplierService.GetSuppliers().ToList();
            ViewBag.Products = products;
            ViewBag.Suppliers = suppliers;
            if (!ModelState.IsValid)
            {
                return View(supplierContractDTO);
            }
            var supplierContract = _mapper.FromDto(supplierContractDTO);
            var result = _service.CreateOne(supplierContract);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSupplierContract(int id)
        {
            var suppliers = _supplierService.GetSuppliers().ToList();
            var products = _productService.GetProducts().ToList();
            ViewBag.Products = products;
            ViewBag.Suppliers = suppliers;
            var supplierContract = _service.GetById(id);
            var supplierContractDTO = _mapper.FromEntity(supplierContract);
            return View(supplierContractDTO);
        }

        [HttpPost]
        public IActionResult UpdateSupplierContract(SupplierContractDTO supplierContractDTO)
        {
            var suppliers = _supplierService.GetSuppliers().ToList();
            var products = _productService.GetProducts().ToList();
            ViewBag.Products = products;
            ViewBag.Suppliers = suppliers;
            if (!ModelState.IsValid)
            {
                return View(supplierContractDTO);
            }
            var supplierContract = _mapper.FromDto(supplierContractDTO);
            var result = _service.UpdateOne(supplierContract);
            ViewBag.Suppliers = suppliers;
            ViewBag.Products = products;
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSupplierContract(int id)
        {
            var result = _service.DeleteSupplierContract(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
    }
}