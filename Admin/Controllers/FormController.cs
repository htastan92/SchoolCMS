using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class FormController : Controller
    {
        private readonly FormService _formService;

        public FormController(FormService formService)
        {
            _formService = formService;
        }

        public IActionResult Index()
        {
            FormListViewModel viewModel = new FormListViewModel
            {
                Forms = _formService.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var findForm = _formService.Get(id);
            if (findForm == null)
                return RedirectToAction("Index");

            FormDetailViewModel viewModel = new FormDetailViewModel
            {

            };

            return View(viewModel);
        }
    }
}