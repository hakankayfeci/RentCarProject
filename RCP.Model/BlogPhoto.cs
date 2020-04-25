using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
    public class BlogPhoto : Base
    {
        [ForeignKey("Blogs")]
        [Required]
        public int BlogId { get; set; }
        [Required]
        public string Photo { get; set; }
        public virtual Blog Blogs { get; set; }


    }
}
