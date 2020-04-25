using RCP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RCP.UI.ViewModel
{
    public class BlogDetailViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int Star { get; set; }
        public virtual User Users { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public List<BlogComment> blogComment { get; set; }
        public List<BlogPhoto> blogPhoto { get; set; }
    }
}