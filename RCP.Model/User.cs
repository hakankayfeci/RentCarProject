using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
   public class User:Base
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
        [Required]
        [StringLength(25, ErrorMessage = "Ad 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string  Name  { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Soyad 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Surname { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string Phone  { get; set; }

        //nav prop 
        public virtual ICollection<Role> Roles { get; set; }
    }
}
