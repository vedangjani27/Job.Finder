using Job.Finder.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Job.Finder.Application.Controllers
{
    [Authorize("LoggedIn")]
    public class JobApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.ApplicationForm.ToList();
            return View(list);
        }


        public IActionResult Delete(int Id)
        {
            _context.ApplicationForm.Remove(_context.ApplicationForm.FirstOrDefault(x => x.Id == Id));
            _context.EducationDetail.Remove(_context.EducationDetail.FirstOrDefault(x => x.ApplicationFormId == Id));
            _context.WorkExperience.Remove(_context.WorkExperience.FirstOrDefault(x => x.ApplicationFormId == Id));
            _context.KnownLanguage.Remove(_context.KnownLanguage.FirstOrDefault(x => x.ApplicationFormId == Id));
            _context.TechnicalExperience.Remove(_context.TechnicalExperience.FirstOrDefault(x => x.ApplicationFormId == Id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
