using DL_EF1;
using ML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        //En Entity Framework SP
        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdProducto)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                 var query = context.ProductoDelete(IdProducto);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result UpdateEF(ML.Producto producto)
        {
            Result result = new Result();
            try
            {

                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var updateResult = context.ProductoUpdate(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen, producto.IdProducto);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                    var productolista = context.ProductoGetAll().ToList();                    

                    if (productolista != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in productolista)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario= obj.PrecioUnitario;
                            producto.Stock = obj.Stock;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.Nombre = (obj.NombreProveedor != null) ? obj.NombreProveedor : "0";
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;                        
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.Nombre = (obj.DepartamentNombre != null) ? obj.DepartamentNombre : "0";
                            producto.Descripcion = (obj.Descripcion != null) ? obj.Descripcion.ToString() : "0";
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.Nombre = (obj.NombreArea != null) ? obj.NombreArea : "0";
                            producto.Imagen = obj.Imagen;
                            result.Objects.Add(producto);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result GetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetById(IdProducto).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.PrecioUnitario = query.PrecioUnitario;
                        producto.Stock = query.Stock;
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = query.IdProveedor;
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = query.IdDepartamento;
                        producto.Descripcion = (query.Descripcion != null) ? query.Descripcion.ToString() : "0";
                        producto.Imagen = query.Imagen;
                        result.Object = producto;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }


                   
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;

        }

        //Entity Framework -> En Linq
        public static ML.Result AddLinq(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    DL_EF1.Producto productoDL = new DL_EF1.Producto();
        

                    productoDL.Nombre = producto.Nombre;
                    productoDL.PrecioUnitario = producto.PrecioUnitario;
                    productoDL.Stock = producto.Stock;
                    productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                    productoDL.Descripcion = producto.Descripcion;
                    productoDL.Imagen = producto.Imagen;

                    context.Productoes.Add(productoDL);
                    int rowsAffected = context.SaveChanges();
                    
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El producto no fue insertado";
                    }


                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateLinq(ML.Producto producto)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from p in context.Productoes
                                 where p.IdProducto == producto.IdProducto
                                 select p).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.PrecioUnitario= producto.PrecioUnitario;
                        query.Stock = producto.Stock;
                        query.IdProveedor = producto.Proveedor.IdProveedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        query.Descripcion = producto.Descripcion;
                        query.Imagen = producto.Imagen;
                        int rowsAffected = context.SaveChanges();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El producto no fue insertado";
                        }
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el grupo" + producto.IdProducto;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result; 
        
    }
        public static ML.Result DeleteLinq(int IdProducto)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from productos1 in context.Productoes
                                 where productos1.IdProducto == IdProducto
                                 select productos1).SingleOrDefault();

                    context.Productoes.Remove(query);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El producto no fue insertado";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetAllLinq()
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from producto in context.Productoes
                                 select new { IdProducto = producto.IdProducto, Nombre = producto.Nombre, PrecioUnitario = producto.PrecioUnitario, Stock = producto.Stock, IdProveedor = producto.IdProveedor, IdDepartamento = producto.IdDepartamento, Descripcion = producto.Descripcion, Imagen = producto.Imagen});

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto productolista = new ML.Producto();
                            productolista.IdProducto = obj.IdProducto;
                            productolista.Nombre = obj.Nombre;
                            productolista.PrecioUnitario = obj.PrecioUnitario;
                            productolista.Stock = obj.Stock;
                            productolista.Proveedor = new ML.Proveedor();
                            productolista.Proveedor.IdProveedor = obj.IdProveedor;
                            productolista.Departamento = new ML.Departamento();
                            productolista.Departamento.IdDepartamento = obj.IdDepartamento;
                            productolista.Descripcion = obj.Descripcion;
                            productolista.Imagen = obj.Imagen;

                            result.Objects.Add(productolista);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdLinq(int IdProducto)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from producto in context.Productoes
                                 join departamento in context.Departamentoes on producto.IdDepartamento equals departamento.IdDepartamento
                                 join area in context.Areas on departamento.IdArea equals area.IdArea
                                 where producto.IdProducto == IdProducto
                                 select new { IdProducto = producto.IdProducto, Nombre = producto.Nombre, PrecioUnitario = producto.PrecioUnitario, Stock = producto.Stock, IdProveedor = producto.IdProveedor, IdDepartamento = producto.IdDepartamento, Descripcion = producto.Descripcion, Imagen = producto.Imagen, IdArea = departamento.IdArea }).SingleOrDefault();

                    if (query != null)
                    {
                            ML.Producto producto2 = new ML.Producto();
                            producto2.IdProducto = query.IdProducto;
                            producto2.Nombre = query.Nombre;
                            producto2.PrecioUnitario = query.PrecioUnitario;
                            producto2.Stock = query.Stock;
                            producto2.Proveedor = new ML.Proveedor();
                            producto2.Proveedor.IdProveedor = query.IdProveedor;
                            producto2.Departamento = new ML.Departamento();
                            producto2.Departamento.IdDepartamento = query.IdDepartamento;
                            producto2.Descripcion = query.Descripcion;
                            producto2.Imagen = query.Imagen;
                            producto2.Departamento.Area = new ML.Area();
                            producto2.Departamento.Area.IdArea = query.IdArea.Value;

                        
                            result.Object = producto2;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
