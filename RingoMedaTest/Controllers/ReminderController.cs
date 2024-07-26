using Application.DTOs.Reminders;
using Application.Interfaces.IService;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace RingoMediaTest.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(ReminderDto reminder)
        {
            _reminderService.ScheduleHangFireJob(reminder);

            return RedirectToAction("Index");
        }
    }
}
