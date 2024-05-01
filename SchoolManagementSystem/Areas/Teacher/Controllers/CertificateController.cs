using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;


namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class CertificateController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CertificateController(IUnitOfWork UnitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Index()
        {
            List<Certificate> CertificateList = _UnitOfWork.Certificate.GetAll().ToList();
            return View(CertificateList);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(Certificate Certificate)
        {
            Certificate.IssueDate = DateTime.Now;
            _UnitOfWork.Certificate.Add(Certificate);
            _UnitOfWork.Save();
            if (Certificate != null)
            {
                string wwwrootPath = _hostingEnvironment.WebRootPath;
                string templatePath = Path.Combine(wwwrootPath, "Certification.pdf");
                string outputDirectory = Path.Combine(wwwrootPath, "Certificate");

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string outputFileName = $"{Certificate.RecipientName}_Certificate.pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                PdfDocument document = PdfReader.Open(templatePath, PdfDocumentOpenMode.Modify);

                PdfPage page = document.Pages[0];

                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font1 = new XFont("Arial", 60, XFontStyle.Bold);
                XFont font2 = new XFont("Arial", 80, XFontStyle.Bold);
                XFont font3 = new XFont("Arial", 20, XFontStyle.Bold);

                XPoint titlePosition = new XPoint(270, 180);
                gfx.DrawString(Certificate.Title, font1, XBrushes.Black, titlePosition);

                XPoint descriptionPosition = new XPoint(250, 340);
                gfx.DrawString(Certificate.Description, font3, XBrushes.Blue, descriptionPosition);

                XPoint issueDatePosition = new XPoint(610, 75);
                gfx.DrawString(Certificate.IssueDate.ToString("MMMM dd, yyyy"), font3, XBrushes.Black, issueDatePosition);

                XPoint expiryDatePosition = new XPoint(45, 500);
                gfx.DrawString(Certificate.ExpiryDate.ToString("MMMM dd, yyyy"), font3, XBrushes.Black, expiryDatePosition);

                XPoint recipientPosition = new XPoint(195, 285);
                gfx.DrawString(Certificate.RecipientName, font1, XBrushes.Red, recipientPosition);

                XPoint issuerPosition = new XPoint(350, 480);
                gfx.DrawString(Certificate.IssuerName, font3, XBrushes.Red, issuerPosition);

                document.Save(outputPath);
                
                return PhysicalFile(outputPath, "application/pdf", "Certificate.pdf");
            }
            TempData["SuccessMessage"] = "Certificate created successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int? CertificateId)
        {
            if (CertificateId == 0 || CertificateId == null)
            {
                return NotFound();
            }

            Certificate? CertificateFromDB = _UnitOfWork.Certificate.Get(u => u.CertificateId == CertificateId);
            if (CertificateFromDB == null)
            {
                return NotFound();
            }

            return View(CertificateFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(Certificate Certificate)
        {
            Certificate.IssueDate = DateTime.Now;
            _UnitOfWork.Certificate.Update(Certificate);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Certificate updated successfully!!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int? CertificateId)
        {
            if (CertificateId == 0 || CertificateId == null)
            {
                return NotFound();
            }

            Certificate? CertificateFromDB = _UnitOfWork.Certificate.Get(u => u.CertificateId == CertificateId);
            if (CertificateFromDB == null)
            {
                return NotFound();
            }
            return View(CertificateFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteCertificate(int? CertificateId)
        {
            Certificate? Certificate = _UnitOfWork.Certificate.Get(u => u.CertificateId == CertificateId);
            if (Certificate == null)
            {
                return NotFound();
            }
            Certificate.IssueDate = DateTime.Now;
            _UnitOfWork.Certificate.Remove(Certificate);
            _UnitOfWork.Save();
            TempData["SuccessMessage"] = "Certificate deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
