using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;


namespace SchoolManagementSystem.Areas.Student.Controllers
{
    [Area("Student")]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactMessage cm)
        {
           cm.CreatedAt = DateTime.Now;
           _context.ContactMessages.Add(cm);
           _context.SaveChanges();
           TempData["SuccessMessage"] = "Thank you for your message!";
           return RedirectToPage("/Contact/AddContact");
         }
    }
}

