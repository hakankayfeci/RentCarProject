using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
    public class UserRole
    {
        [Key]        
        public int UserRoleId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        public virtual User Users { get; set; }
        public virtual Role Roles { get; set; }

    }
}
