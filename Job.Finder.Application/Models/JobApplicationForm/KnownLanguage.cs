using System.ComponentModel.DataAnnotations;

namespace Job.Finder.Application.Models.JobApplicationForm
{
    public class KnownLanguage
    {
        public int Id { get; set; }

        [Required]
        public string Language { get; set; }

        public bool Read { get; set; }

        public bool Write { get; set; }

        public bool Speak { get; set; }
        //public bool IsSelected { get; set; }
        public int ApplicationFormId { get; set; }
    }

    public class KnownLanguageModel
    {
        public int Id { get; set; }

        [Required]
        public string Language { get; set; }

        public bool Read { get; set; }

        public bool Write { get; set; }
        public bool IsSelected { get; set; }
        public bool Speak { get; set; }
        public int ApplicationFormId { get; set; }
    }
}
