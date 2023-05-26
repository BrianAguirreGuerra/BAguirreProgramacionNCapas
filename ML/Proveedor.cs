using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Proveedor
    {

        [Required(ErrorMessage = "El campo Proveedor es obligatorio.")]
        public int IdProveedor { get; set; }
        public string Telefono { get; set; }

        [Display(Name = "Proveedor")]
        public string Nombre { get; set; }
        public List<object> Proveedores { get; set; }
    }
}
