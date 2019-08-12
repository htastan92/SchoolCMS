using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class EventCategoryController : Controller
    {
        private readonly IEventCategoryService _eventCategoryService;

        public EventCategoryController(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }
        public IActionResult Index()
        {
            EventCategoryListViewModel viewModel = new EventCategoryListViewModel()
            {
                EventCategories = _eventCategoryService.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(EventCategoryNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            EventCategory newEventCategory = new EventCategory()
            {
                Name = viewModel.Name,
                StatusId = viewModel.StatusId
            };
            _eventCategoryService.New(newEventCategory);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var findEvent = _eventCategoryService.Get(id);
            if (findEvent == null)
                return RedirectToAction("Index");

            EventCategoryEditViewModel viewModel = new EventCategoryEditViewModel()
            {
                Id = findEvent.Id,
                Name = findEvent.Name,
                StatusId = findEvent.StatusId
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EventCategoryEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            EventCategory editedEventCategory = new EventCategory()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                StatusId = viewModel.StatusId,

            };
            _eventCategoryService.Edit(editedEventCategory);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventCategoryService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventCategoryService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventCategoryService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}