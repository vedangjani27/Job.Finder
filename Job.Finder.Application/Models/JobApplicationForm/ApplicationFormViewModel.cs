using System.ComponentModel.DataAnnotations;

namespace Job.Finder.Application.Models.JobApplicationForm
{
    public class ApplicationFormViewModel
    {
        public ApplicationForm ApplicationForm { get; set; }

        public EducationDetail EducationDetails { get; set; }

        public WorkExperience WorkExperiences { get; set; }

        public List<KnownLanguageModel> KnownLanguages { get; set; }

        public List<TechnicalExperienceModel> TechnicalExperiences { get; set; }
        public ApplicationFormViewModel()
        {
            KnownLanguages = new List<KnownLanguageModel>();
            TechnicalExperiences = new List<TechnicalExperienceModel>();
        }
    }
}
