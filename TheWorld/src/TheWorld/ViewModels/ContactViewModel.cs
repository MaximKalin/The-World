using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(250,MinimumLength =5)]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [StringLength(1024,MinimumLength =5)]
        public String Message { get; set; }
    }
}