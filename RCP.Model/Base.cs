using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace RCP.Model
{
  public class Base
    {
        [Key]
        public int Id { get; set; }       
        public DateTime RegisterDate { get; set; }
        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
