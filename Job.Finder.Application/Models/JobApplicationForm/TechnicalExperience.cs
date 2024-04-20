using System.ComponentModel.DataAnnotations;

namespace Job.Finder.Application.Models.JobApplicationForm
{
    public class TechnicalExperience
    {
        public int Id { get; set; }

        [Required]
        public string Technology { get; set; }

        public string ExperienceLevel { get; set; }
        //public bool Beginner { get; set; }

        //public bool Mediator { get; set; }

        //public bool Expert { get; set; }

        public int ApplicationFormId { get; set; }
    }

    public class TechnicalExperienceModel
    {
        public int Id { get; set; }

        [Required]
        public string Technology { get; set; }
        public string ExperienceLevel { get; set; }


        //public bool Beginner { get; set; }

        //public bool Mediator { get; set; }

        //public bool Expert { get; set; }

        public bool IsSelected { get; set; }
        public int ApplicationFormId { get; set; }
    }
}
