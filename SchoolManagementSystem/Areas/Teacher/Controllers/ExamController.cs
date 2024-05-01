using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using Rotativa;
using System.IO;


namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ExamController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [Authorize(Roles ="Teacher, Student")]
        public IActionResult Index()
        {
            List<Exam> ExamList = _UnitOfWork.Exam.GetAll().ToList();
            return View(ExamList);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(Exam Exam)
        {
            _UnitOfWork.Exam.Add(Exam);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Exam created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int? ExamId)
        {
            if (ExamId == 0 || ExamId == null)
            {
                return NotFound();
            }

            Exam? ExamFromDB = _UnitOfWork.Exam.Get(u => u.ExamId == ExamId);
            if (ExamFromDB == null)
            {
                return NotFound();
            }

            return View(ExamFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(Exam Exam)
        {
            _UnitOfWork.Exam.Update(Exam);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Exam updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int? ExamId)
        {
            if (ExamId == 0 || ExamId == null)
            {
                return NotFound();
            }

            Exam? ExamFromDB = _UnitOfWork.Exam.Get(u => u.ExamId == ExamId);
            if (ExamFromDB == null)
            {
                return NotFound();
            }
            return View(ExamFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteExam(int? ExamId)
        {
            Exam? Exam = _UnitOfWork.Exam.Get(u => u.ExamId == ExamId);
            if (Exam == null)
            {
                return NotFound();
            }

            _UnitOfWork.Exam.Remove(Exam);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Exam deleted successfully";
            return RedirectToAction("Index");
        }
      }
}
