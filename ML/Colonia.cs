﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ML
{
    public class Colonia
    {
        public int IdColonia { get; set; }

        [Display(Name = "Colonia")]
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public ML.Municipio Municipio { get; set; }
        public List<object> Colonias { get; set; }
    }
}
