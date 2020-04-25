using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
   public class Advert:Base
    {
        [ForeignKey("Carss")]
        public int CarId { get; set; }
  
        public int AdvertNo { get; set; }
        [Required]
        public string Explanation { get; set; }//açıklama
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
        [Required]
        public int StartPrie { get; set; }
        [Required]
        public bool AdvertStatus { get; set; }//ilan Durumu yani Açık arttırma mı yoksa normal ilan mı

        public virtual Cars Carss { get; set; }
     
    }
}
