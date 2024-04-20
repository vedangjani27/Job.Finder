using System.ComponentModel.DataAnnotations;

namespace Job.Finder.Application.Models.JobApplicationForm
{
    public class EducationDetail
    {
        public int Id { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string BoardUniversity { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double CGPA { get; set; }
        public int ApplicationFormId { get; set; }
    }
}
