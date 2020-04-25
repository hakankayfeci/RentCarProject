using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
   public class Role:Base
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public string RoleName { get; set; }

        //nav prop 
        public virtual ICollection<User> Users { get; set; }

    }
}
