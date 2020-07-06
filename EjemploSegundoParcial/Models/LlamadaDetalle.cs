using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.Models
{
    public class LlamadaDetalle
    {
        [Key]
        public int llamadaDetalleId { get; set; }
        public int llamadaId { get; set; }
        public int paisId { get; set; }
        public decimal precio { get; set; }
        public decimal duracion { get; set; }

        public LlamadaDetalle()
        {
            llamadaDetalleId = 0;
            llamadaId = 0;
            paisId = 0;
            precio = 0;
            duracion = 0;
        }
    }

}
