using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.Models
{
    public class Llamada
    {
        [Key]
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public int llamadaId { get; set; }
       
        public DateTime fecha { get; set; }
       
        [Required(ErrorMessage ="Este campo no puede estar vacio")]
        public decimal total { get; set; }
        
        [ForeignKey("llamadaId")]
        public virtual List<LlamadaDetalle> Detalles { get; set; }
        
        public Llamada()
        {
            llamadaId = 0;
            fecha = DateTime.Now;
            total = 0;
            Detalles = new List<LlamadaDetalle>();
        }
    }
}
