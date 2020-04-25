using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
    public class Blog:Base
    {
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int Star { get; set; }
        public virtual User Users { get; set; }


    }
}
