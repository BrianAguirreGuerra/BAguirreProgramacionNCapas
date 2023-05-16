using System;
using System.Collections.Generic;
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
            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros de materias" + result.ErrorMessage;
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
            ML.Result resultDepartamento = BL.Departamento.GetAllLinQ();
            //producto.Departamento.Departamentos = resultDepartamento.Objects;

            if (IdProducto == null) //add
            {
                return View(producto); //vacio

            }
            else // update
            {
                //Get By Id
                ML.Result result = BL.Producto.GetByIdLinq(IdProducto.Value);

                //unboxing
                producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                producto.Nombre = ((ML.Producto)result.Object).Nombre;
                producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                producto.Stock = ((ML.Producto)result.Object).Stock;
                producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                producto.Descripcion = ((ML.Producto)result.Object).Descripcion;
                //producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                
                int IdArea = producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                producto.Departamento.Area.Areas = resultArea.Objects;
                result = BL.Departamento.GetByIdArea(IdArea);
                producto.Departamento.Departamentos = result.Objects;

                //BL.Departamento.GetByIdArea //lista
                return View(producto);
            }

        }

        [HttpPost] // Recibir los datos del formulario
        public ActionResult Form(ML.Producto producto)
        {
            if (producto.IdProducto == 0) //add
            {
                ML.Result result = BL.Producto.AddLinq(producto);

                if (result.Correct)
                {
                    //mediante el viewbag enviamos datos
                    //del controlador -> hacia la vista
                    ViewBag.Mensaje = "Producto registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo registrar producto. Error: " + result.ErrorMessage;
                }

            }
            else //update
            {
                ML.Result result = BL.Producto.UpdateLinq(producto);

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

        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteLinq(IdProducto);
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

    }
}