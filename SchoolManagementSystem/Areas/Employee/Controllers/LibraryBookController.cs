using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Employee")]
    public class LibraryBookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LibraryBookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<LibraryBook> LibraryBookList = _unitOfWork.LibraryBook.GetAll().ToList();
            return View(LibraryBookList);
        }

        [Authorize(Roles ="Employee")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Create(LibraryBook libraryBook, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    var imagePath = "/images/" + image.FileName;
                    var imagePathFull = Path.Combine(_webHostEnvironment.WebRootPath, "images", image.FileName);
                    using (var stream = new FileStream(imagePathFull, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    libraryBook.ImagePath = imagePath;
                }

                _unitOfWork.LibraryBook.Add(libraryBook);
                _unitOfWork.Save();
                TempData["SuccessMessage"] = "A new book created successfully!!";
                return RedirectToAction("Index");
            }
            return View(libraryBook);
        }



        [Authorize(Roles = "Employee")]
        public IActionResult Edit(int? LibraryBookId)
        {
            if (LibraryBookId == 0 || LibraryBookId == null)
            {
                return NotFound();
            }

            LibraryBook? LibraryBookFromDB = _unitOfWork.LibraryBook.Get(u => u.LibraryBookId == LibraryBookId);
            if (LibraryBookFromDB == null)
            {
                return NotFound();
            }

            return View(LibraryBookFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public IActionResult Edit(LibraryBook LibraryBook)
        {
            _unitOfWork.LibraryBook.Update(LibraryBook);
            _unitOfWork.Save();
            TempData["SuccessMessage"] = "Book updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Delete(int? LibraryBookId)
        {
            if (LibraryBookId == 0 || LibraryBookId == null)
            {
                return NotFound();
            }

            LibraryBook? LibraryBookFromDB = _unitOfWork.LibraryBook.Get(u => u.LibraryBookId == LibraryBookId);
            if (LibraryBookFromDB == null)
            {
                return NotFound();
            }
            return View(LibraryBookFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Employee")]
        public IActionResult DeleteLibraryBook(int? LibraryBookId)
        {
            LibraryBook? LibraryBook = _unitOfWork.LibraryBook.Get(u => u.LibraryBookId == LibraryBookId);
            if (LibraryBook == null)
            {
                return NotFound();
            }

            _unitOfWork.LibraryBook.Remove(LibraryBook);
            _unitOfWork.Save();
            TempData["SuccessMessage"] = "Book deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
