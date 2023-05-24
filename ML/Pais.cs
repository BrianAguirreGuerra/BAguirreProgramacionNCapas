﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ML
{
    public class Pais
    {
        public int IdPais { get; set; }

        [Display(Name = "País")]
        public string Nombre { get; set; }
        public List<object> Paises { get; set; }
    }
}
