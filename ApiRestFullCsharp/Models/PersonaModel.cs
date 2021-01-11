using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestFullCsharp.Models
{
    public class PersonaModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string sexo { get; set; }

        [Required]
        public int edad { get; set; }   
    }
}
