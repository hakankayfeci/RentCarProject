using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
   public class CarPhoto : Base
    {
        [ForeignKey("Cars")]
        public int CarId { get; set; }
        [Required]
        public string Photo { get; set; }
        public virtual Cars Cars { get; set; }
    }
}
