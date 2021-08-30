using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LinkedInSalesToolGUI.Data
{
    public class AccountModel
    {
        //[StringLength(10, ErrorMessage = "Name is too long.")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password requires at least 6 characters.")]
        public string Password { get; set; }

        public bool Special { get; set; }
    }
}
