using RCP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RCP.UI.ViewModel
{
    public class AdvertViewModel
    {
        
        [Required]
        public string Photo { get; set; }
        public virtual Advert Adverts { get; set; }
        public virtual Cars Carss { get; set; }
        public virtual User Users { get; set; }

    }
}