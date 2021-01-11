using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestFullCsharp.Models
{
    public class CarteraModel
    {
        [Key]
        public int id_car { get; set; }

        public double Pesos { get; set; }

        [Required]
        public string TipoMoneda{get; set;}

        [ForeignKey("id_p")]
        public int id_p { get; set; }

    }
}
