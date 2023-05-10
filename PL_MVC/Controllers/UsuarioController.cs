using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllLinq();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros de materias" + result.ErrorMessage;
            }
          
            return View(usuario);

        }

        [HttpGet] // Mostrar el formulario
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            if (IdUsuario == null) //add
            {
                return View(usuario); //vacio
            }
            else // update
            {
                //Get By Id
                ML.Result result = BL.Usuario.GetByIdLinq(IdUsuario.Value);

                //unboxing
                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.UserName = ((ML.Usuario)result.Object).UserName;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.Password = ((ML.Usuario)result.Object).Password;
                usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                usuario.Celular = ((ML.Usuario)result.Object).Celular;
                usuario.CURP = ((ML.Usuario)result.Object).CURP;
                usuario.IdUsuarioModificado = ((ML.Usuario)result.Object).IdUsuarioModificado;
                usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                return View(usuario);
            }

        }

        [HttpPost] // Recibir los datos del formulario
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0) //add
            {
                ML.Result result = BL.Usuario.AddLinq(usuario);

                if (result.Correct)
                {
                    //mediante el viewbag enviamos datos
                    //del controlador -> hacia la vista
                    ViewBag.Mensaje = "Usuario registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo registrar usuario. Error: " + result.ErrorMessage;
                }
                
            }
            else //update
            {
                ML.Result result = BL.Usuario.UpdateLinq(usuario);

                if (result.Correct)
                {
                    //mediante el viewbag enviamos datos
                    //del controlador -> hacia la vista
                    ViewBag.Mensaje = "Usuario actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar usuario. Error: " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUsuario) 
        {
            ML.Result result = BL.Usuario.DeleteLinq(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el usuario";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar el usuario. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
                
    }
}