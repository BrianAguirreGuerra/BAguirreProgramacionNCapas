﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ML
{
    public class Estado
    {
        public int IdEstado { get; set; }

        [Display(Name = "Estado")]
        public string Nombre { get; set; }
        public ML.Pais Pais { get; set; }
        public List<object> Estados { get; set; }
    }
}
