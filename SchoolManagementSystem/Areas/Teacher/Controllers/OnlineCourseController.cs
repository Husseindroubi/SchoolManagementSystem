using DataAccessLayer;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class OnlineCourseController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public OnlineCourseController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public IActionResult Index()
        {
            List<OnlineCourse> OnlineCourseList = _UnitOfWork.OnlineCourse.GetAll().ToList();
            return View(OnlineCourseList);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(OnlineCourse OnlineCourse)
        {
            _UnitOfWork.OnlineCourse.Add(OnlineCourse);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Online Course created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int? OnlineCourseId)
        {
            if (OnlineCourseId == 0 || OnlineCourseId == null)
            {
                return NotFound();
            }

            OnlineCourse? OnlineCourseFromDB = _UnitOfWork.OnlineCourse.Get(u => u.OnlineCourseId == OnlineCourseId);
            if (OnlineCourseFromDB == null)
            {
                return NotFound();
            }

            return View(OnlineCourseFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(OnlineCourse OnlineCourse)
        {
            _UnitOfWork.OnlineCourse.Update(OnlineCourse);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "OnlineCourse updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int? OnlineCourseId)
        {
            if (OnlineCourseId == 0 || OnlineCourseId == null)
            {
                return NotFound();
            }

            OnlineCourse? OnlineCourseFromDB = _UnitOfWork.OnlineCourse.Get(u => u.OnlineCourseId == OnlineCourseId);
            if (OnlineCourseFromDB == null)
            {
                return NotFound();
            }
            return View(OnlineCourseFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteOnlineCourse(int? OnlineCourseId)
        {
            OnlineCourse? OnlineCourse = _UnitOfWork.OnlineCourse.Get(u => u.OnlineCourseId == OnlineCourseId);
            if (OnlineCourse == null)
            {
                return NotFound();
            }

            _UnitOfWork.OnlineCourse.Remove(OnlineCourse);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "OnlineCourse deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
