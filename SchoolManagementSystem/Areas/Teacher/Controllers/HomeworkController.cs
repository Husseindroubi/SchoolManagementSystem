using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeworkController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public HomeworkController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [Authorize(Roles = "Teacher,Student")]
        public IActionResult Index()
        {
            List<Homework> HomeworkList = _UnitOfWork.Homework.GetAll().ToList();
            return View(HomeworkList);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(Homework Homework)
        {
            Homework.DueDate = DateTime.Now;
            _UnitOfWork.Homework.Add(Homework);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Homework created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int? HomeworkId)
        {
            if (HomeworkId == 0 || HomeworkId == null)
            {
                return NotFound();
            }

            Homework? HomeworkFromDB = _UnitOfWork.Homework.Get(u => u.HomeworkId == HomeworkId);
            if (HomeworkFromDB == null)
            {
                return NotFound();
            }

            return View(HomeworkFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(Homework Homework)
        {
            Homework.DueDate = DateTime.Now;
            _UnitOfWork.Homework.Update(Homework);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Homework updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int? HomeworkId)
        {
            if (HomeworkId == 0 || HomeworkId == null)
            {
                return NotFound();
            }

            Homework? HomeworkFromDB = _UnitOfWork.Homework.Get(u => u.HomeworkId == HomeworkId);
            if (HomeworkFromDB == null)
            {
                return NotFound();
            }
            return View(HomeworkFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteHomework(int? HomeworkId)
        {
            Homework? Homework = _UnitOfWork.Homework.Get(u => u.HomeworkId == HomeworkId);
            if (Homework == null)
            {
                return NotFound();
            }

            Homework.DueDate = DateTime.Now;
            _UnitOfWork.Homework.Remove(Homework);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Homework deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
