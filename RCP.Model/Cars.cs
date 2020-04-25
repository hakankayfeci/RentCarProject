using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
    public class Cars : Base
    {
        [Required]
        [StringLength(25, ErrorMessage = "Model 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Model { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Marka 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Brand { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public string Engine { get; set; }//motor
        [Required]
        public string Sherry { get; set; }//seri
        [Required]
        public string Fuel { get; set; }
        [Required]    
        public string Gear { get; set; }//Vites
        [Required]
        public double Km { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Kasa Tipi 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string CaseType { get; set; }
        [Required]
        public string EnginePower { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Çekiş 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Traction { get; set; }//Çekiş
        [Required]
        public bool Waranty { get; set; }
        public string CarPlate { get; set; }
        [Required]
        public int Price { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }




    }
}
