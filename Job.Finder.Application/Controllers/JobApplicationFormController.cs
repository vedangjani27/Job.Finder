using Job.Finder.Application.Models;
using Job.Finder.Application.Models.JobApplicationForm;
using Microsoft.AspNetCore.Mvc;

namespace Job.Finder.Application.Controllers
{
    public class JobApplicationFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<string> AvailableLanguages = new List<string> { "Hindi", "English", "Gujarati" };
        private static List<string> TechnicalExperience = new List<string> { ".NET", "Angular", "React" };
        public JobApplicationFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {

            ApplicationFormViewModel model = new ApplicationFormViewModel();

            foreach (string language in AvailableLanguages)
            {
                KnownLanguageModel knownLanguage = new KnownLanguageModel
                {
                    Language = language,
                    IsSelected = false,
                    Read = false,
                    Write = false,
                    Speak = false
                };
                model.KnownLanguages.Add(knownLanguage);
            }


            foreach (string technology in TechnicalExperience)
            {
                TechnicalExperienceModel techExperience = new TechnicalExperienceModel
                {
                    Technology = technology,
                    IsSelected = false,
                    //Beginner = false,
                    //Mediator = false,
                    //Expert = false,

                };
                model.TechnicalExperiences.Add(techExperience);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationFormViewModel applicationFormViewModel)
        {
            //Save basic details
            if (_context.ApplicationForm.FirstOrDefault(x => x.Email == applicationFormViewModel.ApplicationForm.Email || x.Email == applicationFormViewModel.ApplicationForm.Contact) == null)
            {
                ApplicationForm model = new ApplicationForm()
                {
                    Name = applicationFormViewModel.ApplicationForm.Name,
                    Email = applicationFormViewModel.ApplicationForm.Email,
                    Address = applicationFormViewModel.ApplicationForm.Address,
                    Gender = applicationFormViewModel.ApplicationForm.Gender,
                    Contact = applicationFormViewModel.ApplicationForm.Contact,
                    PreferredLocation = applicationFormViewModel.ApplicationForm?.PreferredLocation ?? "",
                    ExpectedCTC = applicationFormViewModel.ApplicationForm.ExpectedCTC,
                    CurrentCTC = applicationFormViewModel.ApplicationForm.CurrentCTC,
                    NoticePeriod = applicationFormViewModel.ApplicationForm.NoticePeriod
                };
                await _context.ApplicationForm.AddAsync(model);
                await _context.SaveChangesAsync();

                //save education details
                EducationDetail educationDetail = new EducationDetail()
                {
                    Degree = applicationFormViewModel.EducationDetails.Degree,
                    BoardUniversity = applicationFormViewModel.EducationDetails.BoardUniversity,
                    Year = applicationFormViewModel.EducationDetails.Year,
                    CGPA = applicationFormViewModel.EducationDetails.CGPA,
                    ApplicationFormId = model.Id,
                };

                if (educationDetail != null)
                    await _context.EducationDetail.AddAsync(educationDetail);

                //save languages 
                List<KnownLanguage> languages = new List<KnownLanguage>();
                foreach (var item in applicationFormViewModel.KnownLanguages.Where(x => x.IsSelected == true))
                {
                    KnownLanguage obj = new KnownLanguage()
                    {
                        Language = item.Language,
                        Read = item.Read,
                        Write = item.Write,
                        Speak = item.Speak,
                        ApplicationFormId = model.Id,
                    };
                    languages.Add(obj);
                }
                if (languages.Any())
                    await _context.KnownLanguage.AddRangeAsync(languages);

                //save techical expertise 
                List<TechnicalExperience> technicalExperiences = new List<TechnicalExperience>();
                foreach (var item in applicationFormViewModel.TechnicalExperiences.Where(x => x.IsSelected == true))
                {
                    TechnicalExperience obj = new TechnicalExperience()
                    {
                        Technology = item.Technology,
                        ExperienceLevel = item.ExperienceLevel,
                        ApplicationFormId = model.Id,
                    };
                    technicalExperiences.Add(obj);
                }

                if (technicalExperiences.Any())
                    await _context.TechnicalExperience.AddRangeAsync(technicalExperiences);

                //save work experience
                WorkExperience workExperience = new WorkExperience()
                {
                    Company = applicationFormViewModel.WorkExperiences.Company,
                    Designation = applicationFormViewModel.WorkExperiences.Designation,
                    From = applicationFormViewModel.WorkExperiences.From,
                    To = applicationFormViewModel.WorkExperiences.To,
                    ApplicationFormId = model.Id,
                };
                if (workExperience != null)
                    await _context.WorkExperience.AddAsync(workExperience);

                await _context.SaveChangesAsync();
            }
            else
            {
                TempData["ErrorMsg"] = "Form is already submitted";
            }
            return RedirectToAction("Create");
        }

 
        [HttpPost]
        public JsonResult IsEmailAvailable(string Email)
        {
            //Check the Email Id in the Database
            return Json(!_context.ApplicationForm.Any(x => x.Email == Email));
        }


    }
}
