using DataAccessLayer;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public AnnouncementController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        
        public IActionResult Index()
        {
            List<Announcement> AnnouncementList = _UnitOfWork.Announcement.GetAll().ToList();
            return View(AnnouncementList);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Announcement Announcement)
        {
            Announcement.DatePosted = DateTime.Now;
            _UnitOfWork.Announcement.Add(Announcement);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "An announcement created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? AnnouncementId)
        {
            if (AnnouncementId == 0 || AnnouncementId == null)
            {
                return NotFound();
            }

            Announcement? AnnouncementFromDB = _UnitOfWork.Announcement.Get(u => u.AnnouncementId == AnnouncementId);
            if (AnnouncementFromDB == null)
            {
                return NotFound();
            }

            return View(AnnouncementFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Announcement Announcement)
        {
            Announcement.DatePosted = DateTime.Now;
            _UnitOfWork.Announcement.Update(Announcement);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Announcement updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? AnnouncementId)
        {
            if (AnnouncementId == 0 || AnnouncementId == null)
            {
                return NotFound();
            }

            Announcement? AnnouncementFromDB = _UnitOfWork.Announcement.Get(u => u.AnnouncementId == AnnouncementId);
            if (AnnouncementFromDB == null)
            {
                return NotFound();
            }
            return View(AnnouncementFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAnnouncement(int? AnnouncementId)
        {
            Announcement? Announcement = _UnitOfWork.Announcement.Get(u => u.AnnouncementId == AnnouncementId);
            if (Announcement == null)
            {
                return NotFound();
            }

            Announcement.DatePosted = DateTime.Now;
            _UnitOfWork.Announcement.Remove(Announcement);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Announcement deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
