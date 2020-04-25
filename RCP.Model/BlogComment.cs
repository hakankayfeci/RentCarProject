using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
  public class BlogComment:Base
    {
        [Required]
        [ForeignKey("Blogs")]
        public int BlogId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [ForeignKey("Users")]
        public int? UserId { get; set; }
      
        public virtual Blog Blogs { get; set; }
        public virtual User Users { get; set; }


    }
}
