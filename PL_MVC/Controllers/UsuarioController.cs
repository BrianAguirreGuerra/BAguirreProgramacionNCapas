using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllLinq();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }

        public ActionResult Add() 
        {
            return View();
        }

        public ActionResult Delete(int id) 
        {
            ML.Result result = BL.Usuario.DeleteLinq(id);
            return View();
        }
                
    }
}