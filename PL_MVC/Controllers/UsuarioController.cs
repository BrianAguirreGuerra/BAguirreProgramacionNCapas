using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ML.Result result = BL.Usuario.GetAllLinq();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Usuario());
        }

        public void Delete(int IdUsuario) 
        {
            ML.Result result = BL.Usuario.DeleteLinq(IdUsuario);
            GetAll();
        }
                
    }
}