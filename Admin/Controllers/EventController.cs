using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }
        public IActionResult Index()
        {
            EventListViewModel viewModel = new EventListViewModel()
            {
                Events = _eventService.GetAllAdmin()
            };

            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(EventNewViewModel viewModel)   
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            Event newEvent = new Event()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                EditorContent = viewModel.EditorContent,
                ImageId = 1,
                StatusId = viewModel.StatusId,
                Location = viewModel.Location,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                CampusId = viewModel.CampusId
            };
            _eventService.New(newEvent);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var findEvent = _eventService.GetAdmin(id);
            if (findEvent == null)
                return RedirectToAction("Index");

            EventEditViewModel viewModel = new EventEditViewModel()
            {
                Id = findEvent.Id,
                Name = findEvent.Name,
                Description = findEvent.Description,
                EditorContent = findEvent.EditorContent,
                Slug = findEvent.Slug,
                StatusId = findEvent.StatusId,
                ImageUrl = null,
                Location = findEvent.Slug,
                StartDate = findEvent.StartDate,
                EndDate = findEvent.EndDate,
                CampusId = findEvent.CampusId
                
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Event editedEvent = new Event()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                EditorContent = viewModel.EditorContent,
                Slug = viewModel.Slug,
                ImageId = 1,
                StatusId = viewModel.StatusId,
                Image = null,
                Location = viewModel.Location,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                CampusId = viewModel.CampusId
                
            };
            _eventService.Edit(editedEvent);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}