using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Identity.Controllers;

[Area("Identity")]
public class RoleController : Controller
{
    private readonly RoleManager<AppUserRole> _roleManager;

    public RoleController(RoleManager<AppUserRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var roles = _roleManager.Roles;
        return View(roles.ToList());
    }

    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(AppUserRole newRole)
    {
        await _roleManager.CreateAsync(newRole);
        return View();
    }

    public IActionResult UpdateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(AppUserRole updatedRole)
    {
        await _roleManager.UpdateAsync(updatedRole);
        return View();
    }

    public async Task<IActionResult> DeleteRole(int id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString()) ?? new();
        await _roleManager.DeleteAsync(role);
        return RedirectToAction("Index");
    }

}
