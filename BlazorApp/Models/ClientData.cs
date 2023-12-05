using System;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;
namespace BlazorApp.Models
{
    public class ClientData
    {
        [Required (ErrorMessage = "Naam is verplicht")]
        [StringLength(30, ErrorMessage = "Naam is te lang")]
        public string Name { get; set; }
        
        [Required (ErrorMessage = "Email is verplicht")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Incorrect email formaat.")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Telefoon is verplicht")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect telefoonnummer formaat.")]
        public string Phone { get; set; }

        [Required (ErrorMessage = "Geboortedatum is verplicht")]
        [DateNotInFuture(ErrorMessage = "Geboortedatum mag niet in de toekomst liggen")]
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-18);

        [Required (ErrorMessage = "Reden voor consultatie is verplicht")]
        [StringLength(250, ErrorMessage = "Reden is te lang")]
        public string Reason { get; set; }

        [Required (ErrorMessage = "Geslacht is verplicht")]
        public Gender SelectedGender { get; set;}
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

