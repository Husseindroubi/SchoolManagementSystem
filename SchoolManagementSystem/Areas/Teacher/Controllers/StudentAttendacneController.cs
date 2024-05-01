using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class StudentAttendanceController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public StudentAttendanceController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [Authorize(Roles = "Teacher,Admin")]
        public IActionResult Index()
        {
            List<StudentAttendance> StudentAttendanceList = _UnitOfWork.StudentAttendance.GetAll().ToList();
            return View(StudentAttendanceList);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(StudentAttendance StudentAttendance)
        {
            StudentAttendance.Date = DateTime.Now;
            _UnitOfWork.StudentAttendance.Add(StudentAttendance);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Student Attendance created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int? StudentAttendanceId)
        {
            if (StudentAttendanceId == 0 || StudentAttendanceId == null)
            {
                return NotFound();
            }

            StudentAttendance? StudentAttendanceFromDB = _UnitOfWork.StudentAttendance.Get(u => u.StudentAttendanceId == StudentAttendanceId);
            if (StudentAttendanceFromDB == null)
            {
                return NotFound();
            }

            return View(StudentAttendanceFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(StudentAttendance StudentAttendance)
        {
            StudentAttendance.Date = DateTime.Now;
            _UnitOfWork.StudentAttendance.Update(StudentAttendance);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Student Attendance updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int? StudentAttendanceId)
        {
            if (StudentAttendanceId == 0 || StudentAttendanceId == null)
            {
                return NotFound();
            }

            StudentAttendance? StudentAttendanceFromDB = _UnitOfWork.StudentAttendance.Get(u => u.StudentAttendanceId == StudentAttendanceId);
            if (StudentAttendanceFromDB == null)
            {
                return NotFound();
            }
            return View(StudentAttendanceFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteAttendance(int? StudentAttendanceId)
        {
            StudentAttendance? StudentAttendance = _UnitOfWork.StudentAttendance.Get(u => u.StudentAttendanceId == StudentAttendanceId);
            if (StudentAttendance == null)
            {
                return NotFound();
            }
            StudentAttendance.Date = DateTime.Now;
            _UnitOfWork.StudentAttendance.Remove(StudentAttendance);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Student Attendance deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
