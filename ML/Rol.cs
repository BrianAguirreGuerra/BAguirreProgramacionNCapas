using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Rol
    {
        public byte IdRol { get; set; }

        [Display(Name = "Rol")]
        public string Nombre { get; set;}
        public List<object> Roles { get; set; }
    }
}
