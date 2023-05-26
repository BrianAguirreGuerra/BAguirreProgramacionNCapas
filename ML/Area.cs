using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Area
    {
        [Required(ErrorMessage = "El campo Area es obligatorio.")]
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public List<object> Areas { get; set; }

    }
}
