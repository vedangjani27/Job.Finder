using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Job.Finder.Application.Models.JobApplicationForm
{
    public class ApplicationForm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Remote("IsEmailAvailable", "JobApplicationForm", HttpMethod = "POST", ErrorMessage = "Email ID already in use.")]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        [Phone]
        //[Remote(action: "IsFieldDataAvailable", controller: "JobApplicationFormController")]
        public string Contact { get; set; }

        // Preference
        [Required]
        public string PreferredLocation { get; set; }

        [Required]
        public decimal ExpectedCTC { get; set; }

        [Required]
        public decimal CurrentCTC { get; set; }

        [Required]
        public int NoticePeriod { get; set; }
    }

}
