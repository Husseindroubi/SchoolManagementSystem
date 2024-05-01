using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
        public class ClassroomController : Controller
        {
        private readonly IUnitOfWork _UnitOfWork;

        public ClassroomController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult Index()
        {
            List<Classroom> ClassroomList = _UnitOfWork.Classroom.GetAll().ToList();
            return View(ClassroomList);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Classroom Classroom)
        {
            _UnitOfWork.Classroom.Add(Classroom);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "A new classroom created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? ClassroomId)
        {
            if (ClassroomId == 0 || ClassroomId == null)
            {
                return NotFound();
            }

            Classroom? ClassroomFromDB = _UnitOfWork.Classroom.Get(u => u.ClassroomId == ClassroomId);
            if (ClassroomFromDB == null)
            {
                return NotFound();
            }

            return View(ClassroomFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Classroom Classroom)
        {
            _UnitOfWork.Classroom.Update(Classroom);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Classroom updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? ClassroomId)
        {
            if (ClassroomId == 0 || ClassroomId == null)
            {
                return NotFound();
            }

            Classroom? ClassroomFromDB = _UnitOfWork.Classroom.Get(u => u.ClassroomId == ClassroomId);
            if (ClassroomFromDB == null)
            {
                return NotFound();
            }
            return View(ClassroomFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteClassroom(int? ClassroomId)
        {
            Classroom? Classroom = _UnitOfWork.Classroom.Get(u => u.ClassroomId == ClassroomId);
            if (Classroom == null)
            {
                return NotFound();
            }

            _UnitOfWork.Classroom.Remove(Classroom);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Classroom deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
