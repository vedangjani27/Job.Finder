using System.ComponentModel.DataAnnotations;

namespace Job.Finder.Application.Models.JobApplicationForm
{
    public class WorkExperience
    {
        public int Id { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public DateTime From { get; set; }

        public DateTime? To { get; set; }
        public int ApplicationFormId { get; set; }
    }
}
