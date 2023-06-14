using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            //ML.Result result = BL.Producto.GetAllEF();
            ServiceProductos.ProductosClient productosClient = new ServiceProductos.ProductosClient();
            var result = productosClient.GetAll();

            if (result.Correct)
            {
                producto.Productos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros" + result.ErrorMessage;
            }

            return View(producto);

        }
        [HttpGet] // Mostrar el formulario
        public ActionResult Form(int? IdProducto)       
        {
            ML.Producto producto = new ML.Producto();
            ML.Result resultProveedor = BL.Proveedor.GetAllLinQ();
            producto.Proveedor = new ML.Proveedor();
            producto.Departamento = new ML.Departamento();
            producto.Proveedor.Proveedores = resultProveedor.Objects;
            ML.Result resultArea = BL.Area.GetAllLinQ();
            producto.Departamento.Area = new ML.Area();
            producto.Departamento.Area.Areas = resultArea.Objects;

            if (IdProducto == null) //add
            {
                return View(producto); //vacio

            }
            else // update
            {
                //Get By Id
                //ML.Result resultA = new ML.Result();
                ServiceProductos.ProductosClient productosClient = new ServiceProductos.ProductosClient();
                var result = productosClient.GetById(IdProducto.Value);

                //unboxing
                producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                producto.Nombre = ((ML.Producto)result.Object).Nombre;
                producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                producto.Stock = ((ML.Producto)result.Object).Stock;
                producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                producto.Descripcion = ((ML.Producto)result.Object).Descripcion;            
                int IdArea = producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                producto.Imagen = ((ML.Producto)result.Object).Imagen;
                ML.Result resultDepartamentos = BL.Departamento.GetByIdArea(IdArea);
                producto.Departamento.Departamentos = resultDepartamentos.Objects;
                producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                //result = BL.Departamento.GetByIdArea(IdArea);
                //producto.Departamento.Departamentos = result.Objects.ToList();
                return View(producto);
            }

        }

        [HttpPost] 
        public ActionResult Form(ML.Producto producto, HttpPostedFileBase ImgProducto)
        {
            if (ImgProducto != null)
            {
                producto.Imagen = ConvertToBytes(ImgProducto);
            }


            if (ModelState.IsValid)
            {
                if (producto.IdProducto == 0) //add
                {
                    //ML.Result result = BL.Producto.AddLinq(producto);
                    //producto.Imagen = null;
                    ServiceProductos.ProductosClient productosClient = new ServiceProductos.ProductosClient();
                    var result = productosClient.Add(producto);


                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Producto registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo registrar producto. Error: " + result.ErrorMessage;
                    }

                }
                else //update
                {
                    //producto.Imagen = null;
                    ServiceProductos.ProductosClient productosClient = new ServiceProductos.ProductosClient();
                    var result = productosClient.Update(producto);

                    //ML.Result result = BL.Producto.UpdateLinq(producto);

                    if (result.Correct)
                    {
                        //mediante el viewbag enviamos datos
                        //del controlador -> hacia la vista
                        ViewBag.Mensaje = "Producto actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar producto. Error: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }

            ML.Result resultProveedor = BL.Proveedor.GetAllLinQ();
            producto.Proveedor = new ML.Proveedor();

            producto.Departamento = new ML.Departamento();
            
            producto.Proveedor.Proveedores = resultProveedor.Objects;
            ML.Result resultArea = BL.Area.GetAllLinQ();
            producto.Departamento.Area = new ML.Area();
            producto.Departamento.Area.Areas = resultArea.Objects;
            return View(producto);
        }

        public ActionResult Delete(int IdProducto)
        {
            //ML.Result result = BL.Producto.DeleteLinq(IdProducto);
            ServiceProductos.ProductosClient productosClient = new ServiceProductos.ProductosClient();
            var result = productosClient.Delete(IdProducto);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el producto";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar el producto. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        public ActionResult GetByIdArea(int IdArea) {
            ML.Result result = BL.Departamento.GetByIdArea(IdArea);
            ML.Producto producto = new ML.Producto();
            producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
            return ViewBag.IdDepartamento(producto);
        }

        public JsonResult GetDepartamento(int IdArea)
        {
            //BL- > Grupos de determinado plantel 
            ML.Result resultDepartamentos = BL.Departamento.GetByIdArea(IdArea);
            //crear un nuevo stored GrupoGetByIdPlantel -> DepartamentoGetByIdArea
            return Json(resultDepartamentos.Objects);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase ImgProducto)
        {
            byte[] imgBytes = null;
            BinaryReader reader = new BinaryReader(ImgProducto.InputStream);
            imgBytes = reader.ReadBytes((int)ImgProducto.ContentLength);
            return imgBytes;
        }

    }
}