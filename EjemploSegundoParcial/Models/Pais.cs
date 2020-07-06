using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.Models
{
    public class Pais
    {
        [Key]
        public int paisId { get; set; }
        public string pais { get; set; }
        public decimal precio { get; set; }

        public Pais()
        {
            paisId = 0;
            pais = string.Empty;
            precio = 0;
        }
    }
}
