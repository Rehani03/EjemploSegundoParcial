using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.Models
{
    public class Cobros
    {
        public int CobroId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double Monto { get; set; }

        public Cobros(int cobroId, DateTime fecha, string cliente, double monto)
        {
            CobroId = cobroId;
            Fecha = fecha;
            Cliente = cliente;
            Monto = monto;
        }
    }
   
}
