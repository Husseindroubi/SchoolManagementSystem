using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Policy = "AuthenticatedUser")]
    public class DashboardController : Controller
    {
        public IActionResult DashPage()
        {
            return View();
        }
    }
}
