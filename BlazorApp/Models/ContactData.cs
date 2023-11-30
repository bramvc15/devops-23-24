using System;
using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Models
{
    public class ContactData
    {
        [Required (ErrorMessage = "Naam is verplicht")]
        [StringLength(30, ErrorMessage = "Naam is te lang")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Naam is verplicht")]
        [StringLength(30, ErrorMessage = "Naam is te lang")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Email is verplicht")]
        [EmailAddress(ErrorMessage = "Email is niet geldig")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Telefoon is verplicht")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect telefoonnummer formaat.")]
        public string Phone { get; set; }

        [Required (ErrorMessage = "Geboortedatum is verplicht")]
        public DateTime BirthDate { get; set; }

        [Required (ErrorMessage = "Bericht is verplicht")]
        public string Message { get; set; }
    }
}
