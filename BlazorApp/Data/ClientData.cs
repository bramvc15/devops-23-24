using System;
using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Data
{
    public class ClientData
    {
        [Required (ErrorMessage = "Naam is verplicht")]
        [StringLength(30, ErrorMessage = "Naam is te lang")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Email is verplicht")]
        [EmailAddress(ErrorMessage = "Email is niet geldig")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Telefoon is verplicht")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }
        [Required (ErrorMessage = "Geboortedatum is verplicht")]
        [DateNotInFuture(ErrorMessage = "Geboortedatum mag niet in de toekomst liggen")]
        public DateTime birthDate { get; set; }
    }
}

public class DateNotInFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
        {
            return date <= DateTime.Now;
        }

        return true;
    }
}

