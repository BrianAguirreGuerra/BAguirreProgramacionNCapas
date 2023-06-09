﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Usuario resultSubCategoria = new ML.Usuario();
            resultSubCategoria.Usuarios = new List<Object>();

            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("usuario");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        resultSubCategoria.Usuarios.Add(resultItemList);
                    }
                }
            }


            //ML.Usuario usuario = new ML.Usuario();
            //ML.Result result = BL.Usuario.GetAllEF();
            //if (result.Correct)
            //{
            //    usuario.Usuarios = result.Objects;
            //}
            //else
            //{
            //    ViewBag.Message = "Ocurrió un error al traer los registros" + result.ErrorMessage;
            //}

            return View(resultSubCategoria);

        }

        [HttpGet] // Mostrar el formulario
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAllLinQ();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRol.Objects;
            ML.Result resultPais = BL.Pais.GetAll();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado= new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

            if (IdUsuario == null) //add
            {
                return View(usuario); //vacio

            }
            else // update
            {
                ML.Result result = new ML.Result();
                try
                {
                    string url = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(url);
                        var responseTask = client.GetAsync("usuario/" + IdUsuario);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Usuario resultItemList = new ML.Usuario();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                            usuario = resultItemList;
                            usuario.Rol.Roles = resultRol.Objects;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                            //usuario.Direccion.IdDireccion = ((ML.Usuario)result.Object).Direccion.IdDireccion;
                            //usuario.Direccion.Calle = ((ML.Usuario)result.Object).Direccion.Calle;
                            //usuario.Direccion.NumeroInterior = ((ML.Usuario)result.Object).Direccion.NumeroInterior;
                            //usuario.Direccion.NumeroExterior = ((ML.Usuario)result.Object).Direccion.NumeroExterior;
                            //int IdPais = usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Pais.IdPais;
                            //int IdEstado = usuario.Direccion.Colonia.Municipio.Estado.IdEstado = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.IdEstado;
                            //int IdMunicipio = usuario.Direccion.Colonia.Municipio.IdMunicipio = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.IdMunicipio;
                            //usuario.Direccion.Colonia.IdColonia = ((ML.Usuario)result.Object).Direccion.Colonia.IdColonia;
                            result = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                            if (result.Correct)
                            {
                                usuario.Direccion.Colonia.Municipio.Estado.Estados = result.Objects;
                                result = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                                usuario.Direccion.Colonia.Municipio.Municipios = result.Objects;
                                result = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                                usuario.Direccion.Colonia.Colonias = result.Objects;

                            }
                            else
                            {
                                ViewBag.Message = "Ocurrió un error al actualizar los registros" + result.ErrorMessage;
                            }
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";
                        }

                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }



                //Get By Id
                //ML.Result result = BL.Usuario.GetByIdLinq(IdUsuario.Value);

                //usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                //usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                //usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                //usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                //usuario.UserName = ((ML.Usuario)result.Object).UserName;
                //usuario.Email = ((ML.Usuario)result.Object).Email;
                //usuario.Password = ((ML.Usuario)result.Object).Password;
                //usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                //usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                //usuario.Celular = ((ML.Usuario)result.Object).Celular;
                //usuario.CURP = ((ML.Usuario)result.Object).CURP;
                //usuario.IdUsuarioModificado = ((ML.Usuario)result.Object).IdUsuarioModificado;
                //usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                //usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;
                //usuario.Direccion.IdDireccion = ((ML.Usuario)result.Object).Direccion.IdDireccion;
                //usuario.Direccion.Calle = ((ML.Usuario)result.Object).Direccion.Calle;
                //usuario.Direccion.NumeroInterior = ((ML.Usuario)result.Object).Direccion.NumeroInterior;
                //usuario.Direccion.NumeroExterior = ((ML.Usuario)result.Object).Direccion.NumeroExterior;
                //int IdPais = usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Pais.IdPais;
                //int IdEstado = usuario.Direccion.Colonia.Municipio.Estado.IdEstado = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.IdEstado;
                //int IdMunicipio = usuario.Direccion.Colonia.Municipio.IdMunicipio = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.IdMunicipio;
                //usuario.Direccion.Colonia.IdColonia = ((ML.Usuario)result.Object).Direccion.Colonia.IdColonia;
                //usuario.Imagen = ((ML.Usuario)result.Object).Imagen;
                //result = BL.Estado.GetByIdPais(IdPais);
                //if (result.Correct)
                //{
                //    usuario.Direccion.Colonia.Municipio.Estado.Estados = result.Objects;
                //    result = BL.Municipio.GetByIdEstado(IdEstado);
                //    usuario.Direccion.Colonia.Municipio.Municipios = result.Objects;
                //    result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
                //    usuario.Direccion.Colonia.Colonias = result.Objects;

                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrió un error al actualizar los registros" + result.ErrorMessage;
                //}
                return View(usuario);
            }

        }

        [HttpPost] // Recibir los datos del formulario
        public ActionResult Form(ML.Usuario usuario, HttpPostedFileBase ImgUsuario)
            {
            if (ImgUsuario != null)
            {
                usuario.Imagen = ConvertToBytes(ImgUsuario);
            }

                if (usuario.IdUsuario == 0) //add
                {

                usuario.IdUsuarioModificado = 2;

                using (var cliente = new HttpClient())
                {
                    string url = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
                    cliente.BaseAddress = new Uri(url);

                    var task = cliente.PostAsJsonAsync<ML.Usuario>("usuario", usuario);

                    task.Wait();

                    var response = task.Result;
                    var readTask = response.Content.ReadAsAsync<ML.Result>();

                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Usuario registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo registrar usuario. Error: " + readTask.Result.ErrorMessage;
                    }
                }



                //ML.Result result = BL.Usuario.AddEF(usuario);

                //if (result.Correct)
                //{
                //    ViewBag.Mensaje = "Usuario registrado correctamente";
                //}
                //else
                //{
                //    ViewBag.Mensaje = "No se pudo registrar usuario. Error: " + result.ErrorMessage;
                //}

            }
                else //update
                {

                using (var cliente = new HttpClient())
                {
                    string url = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
                    cliente.BaseAddress = new Uri(url);
                    //cliente.BaseAddress = new Uri("http://localhost:51421/api/");

                    var task = cliente.PutAsJsonAsync<ML.Usuario>("usuario/" + usuario.IdUsuario, usuario);

                    task.Wait();

                    var response = task.Result;
                    var readTask = response.Content.ReadAsAsync<ML.Result>();

                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Usuario registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo registrar usuario. Error: " + readTask.Result.ErrorMessage;
                    }
                }

                //ML.Result result = BL.Usuario.UpdateEF(usuario);

                //if (result.Correct)
                //{
                //    //mediante el viewbag enviamos datos
                //    //del controlador -> hacia la vista
                //    ViewBag.Mensaje = "Usuario actualizado correctamente";
                //}
                //else
                //{
                //    ViewBag.Mensaje = "No se ha podido actualizar usuario. Error: " + result.ErrorMessage;
                //}
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUsuario) 
        {

            ML.Result resultListProduct = new ML.Result();
            int id = IdUsuario;
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(url);

                //HTTP POST
                var postTask = client.DeleteAsync("usuario/" + id);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se ha eliminado correctamente el usuario";
                }
            }


            return PartialView("Modal");


            //ML.Result result = BL.Usuario.DeleteLinq(IdUsuario);
            //if (result.Correct)
            //{
            //    ViewBag.Mensaje = "Se ha eliminado correctamente el usuario";
            //}
            //else
            //{
            //    ViewBag.Mensaje = "No se ha podido eliminar el usuario. Error: " + result.ErrorMessage;
            //}

            //return PartialView("Modal");
        }

        public JsonResult GetEstado(int IdPais)
        {
            ML.Result resultEstados = BL.Estado.GetByIdPais(IdPais);
            return Json(resultEstados.Objects);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(resultMunicipio.Objects);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(resultColonia.Objects);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase ImgUsuario)
        {
            byte[] imgBytes = null;
            BinaryReader reader = new BinaryReader(ImgUsuario.InputStream);
            imgBytes = reader.ReadBytes((int)ImgUsuario.ContentLength);
            return imgBytes;
        }

        public JsonResult UpdateStatus(int IdUsuario, bool Estatus)
        {
            ML.Result resultEstatus = BL.Usuario.EstatusUpdate(IdUsuario, Estatus);
            return Json(resultEstatus);
        }
    }
}