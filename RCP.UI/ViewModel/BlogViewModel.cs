using RCP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RCP.UI.ViewModel
{
    public class BlogViewModel
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
        public string Photo { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }

        public int CommentCount { get; set; }
    }
}