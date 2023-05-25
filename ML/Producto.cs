using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }

        [Display(Name = "Nombre Producto")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se aceptan letras.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El campo Nombre debe tener entre 1 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "El campo Precio Unitario es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Precio Unitario debe ser un valor numérico válido.")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El campo Stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo Stock debe ser un valor numérico válido.")]
        public int Stock { get; set; }
        public ML.Proveedor  Proveedor { get; set; }
        public ML.Departamento Departamento { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen del Producto")]
        public byte[] Imagen { get; set;}
        public List<object> Productos { get; set; }
    }
}
