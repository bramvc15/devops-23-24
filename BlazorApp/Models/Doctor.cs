using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Doctor
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Specialization { get; set; }

        public string? InfoAbout { get; set; }
        public string? InfoEducation { get; set; }
        public string? InfoPublications { get; set; }

        public string? Image { get; set; }
    }
}