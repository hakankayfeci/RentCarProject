using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
   public class Contact
    {
        [Required(ErrorMessage = "Adınız Soyadınız Gereklidir Lütfen Giriniz")]
        public string NameSurname { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [EmailAddress(ErrorMessage = "Email Geçersiz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MaxLength(500, ErrorMessage = "500 karateri geçmeyin")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MaxLength(500, ErrorMessage = "50 karateri geçmeyin")]
        public string Title { get; set; }
    }
}
