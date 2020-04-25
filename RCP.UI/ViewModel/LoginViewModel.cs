using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCP.UI.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}