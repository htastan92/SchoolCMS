using Admin.Helper;
using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    [SessionFilter]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            MenuElementListViewModel viewModel = new MenuElementListViewModel()
            {
                MenuElements = _menuService.GetAllAdmin()
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(MenuElementNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            MenuElement menuElement = new MenuElement()
            {
                Name = viewModel.Name,
                Url = viewModel.Url,
                MenuLocation = viewModel.MenuLocation,
                ParentMenuId = viewModel.ParentMenuId,
                StatusId = viewModel.StatusId

            };
            _menuService.New(menuElement);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var findMenu = _menuService.GetAdmin(id);
            if (findMenu == null)
                return RedirectToAction("Index");
            MenuElementEditViewModel viewModel=new MenuElementEditViewModel()
            {
                Name =findMenu.Name,
                Url = findMenu.Url,
                Id = findMenu.Id,
                StatusId = findMenu.StatusId,
                MenuLocation = findMenu.MenuLocation,
                ParentMenuId = findMenu.ParentMenuId
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(MenuElementEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            MenuElement editedMenuElement = new MenuElement()
            {
                Name = viewModel.Name,
                Url = viewModel.Url,
                Id = viewModel.Id,
                StatusId = viewModel.StatusId,
                MenuLocation =viewModel.MenuLocation,
                ParentMenuId = viewModel.ParentMenuId
            };
            _menuService.Edit(editedMenuElement);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _menuService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _menuService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _menuService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}