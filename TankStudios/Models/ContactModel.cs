using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TankStudios.Models
{
    public class ContactModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} cannot be more than {1} characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} cannot be more than {1} characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        public ContactModel()
        {

        }

        private ContactModel(string firstName, string lastName, string email, string message,
            string errorMessage, string successMessage)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Message = message;
            this.ErrorMessage = errorMessage;
            this.SuccessMessage = successMessage;
        }

        public static ContactModel CreateEmpty()
        {
            return new ContactModel(string.Empty, string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty);
        }

        public static ContactModel CreateError(string firstName, string lastName, string email, string message,
            string errorMessage)
        {
            return new ContactModel(firstName, lastName, email, message, errorMessage, string.Empty);
        }

        public static ContactModel CreateSuccess(string firstName, string lastName, string email, string message,
            string successMessage)
        {
            return new ContactModel(firstName, lastName, email, message, string.Empty, successMessage);
        }
    }
}