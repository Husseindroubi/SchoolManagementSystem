using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
        public class SubjectController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public SubjectController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult Index()
        {
            List<Subject> SubjectList = _UnitOfWork.Subject.GetAll().ToList();
            return View(SubjectList);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Subject Subject)
        {
            _UnitOfWork.Subject.Add(Subject);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "A new subject created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? SubjectId)
        {
            if (SubjectId == 0 || SubjectId == null)
            {
                return NotFound();
            }

            Subject? SubjectFromDB = _UnitOfWork.Subject.Get(u => u.SubjectId == SubjectId);
            if (SubjectFromDB == null)
            {
                return NotFound();
            }

            return View(SubjectFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Subject Subject)
        {
            _UnitOfWork.Subject.Update(Subject);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Subject updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? SubjectId)
        {
            if (SubjectId == 0 || SubjectId == null)
            {
                return NotFound();
            }

            Subject? SubjectFromDB = _UnitOfWork.Subject.Get(u => u.SubjectId == SubjectId);
            if (SubjectFromDB == null)
            {
                return NotFound();
            }
            return View(SubjectFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSubject(int? SubjectId)
        {
            Subject? Subject = _UnitOfWork.Subject.Get(u => u.SubjectId == SubjectId);
            if (Subject == null)
            {
                return NotFound();
            }

            _UnitOfWork.Subject.Remove(Subject);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Subject deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
