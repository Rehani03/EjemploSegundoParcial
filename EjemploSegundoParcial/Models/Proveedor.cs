using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.Models
{
    public class Proveedor
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 1000000.")]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener por lo menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre es muy largo.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo RNC no puede estar vacío.")]
        [MinLength(9, ErrorMessage = "El campo RNC debe contener 9 caracteres.")]
        [Phone(ErrorMessage = "Debe ser numerico.")]
        public string RNC { get; set; }

        [Required(ErrorMessage = "El campo dirección no puede estar vacía.")]
        [MinLength(10, ErrorMessage = "La dirección es muy corta.")]
        [MaxLength(40, ErrorMessage = "La dirección debe contener menos de 40 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo telefono no puede estar vacío.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo telefono no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage ="El tipo de negocio no puede estar vacio.")]
        [MinLength(5, ErrorMessage = "El tipo de negocio es muy corto.")]
        [MaxLength(40, ErrorMessage = "El tipo de negocio debe contener menos de 40 caracteres.")]
        public string TipoNegocio { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }


        public Proveedor()
        {
            ProveedorId = 0;
            Nombre = string.Empty;
            RNC = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            TipoNegocio = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
