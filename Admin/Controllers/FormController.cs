using Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class FormController : Controller
    {
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

            var findForm = _formService.Find(id);
            if (findForm == null)
                return RedirectToAction("Index");

            FormDetailViewModel viewModel = new FormDetailViewModel
            {

            };

            return view(viewModel);
        }
    }
}