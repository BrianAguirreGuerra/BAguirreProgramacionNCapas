using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Sexo")]
        public char Sexo { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "CURP")]
        public string CURP { get; set; }

        [Display(Name = "ID Usuario (Modificación)")]
        public int IdUsuarioModificado { get; set; }
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }

        [Display(Name = "Fecha de Creaciòn")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Fecha de Modificaciòn")]
        public string FechaModificacion { get; set; }

        [Display(Name = "Avatar")]
        public byte[] Imagen { get; set; }

        [Display(Name = "Estatus")]
        public bool Estatus { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
