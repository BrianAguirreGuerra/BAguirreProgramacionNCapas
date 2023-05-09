using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Producto
    {

        public static void Menu1()
        {
            Console.WriteLine("Menú CON ENTITY FRAMEWORK STORE");
            Console.WriteLine("¿Que deseas hacer?");
            Console.WriteLine("Agregar registro = 1");
            Console.WriteLine("Actualizar Registro = 2");
            Console.WriteLine("Eliminar registro = 3");
            Console.WriteLine("Ver todos los registros = 4");
            Console.WriteLine("Buscar  un registros = 5");
            int Respuesta = int.Parse(Console.ReadLine());

            switch (Respuesta)
            {
                case 1:
                    PL.Producto.Add();
                    break;
                case 2:
                    PL.Producto.UpDate();
                    break;
                case 3:
                    PL.Producto.Delete();
                    break;
                case 4:
                    PL.Producto.GetAll();
                    break;
                case 5:
                    PL.Producto.GetById();
                    break;
            }
        }
        public static void Menu2()
        {
            Console.WriteLine("Menú ENTITY FRAMEWORK LINQ");
            Console.WriteLine("¿Que deseas hacer?");
            Console.WriteLine("Agregar registro = 1");
            Console.WriteLine("Actualizar Registro = 2");
            Console.WriteLine("Eliminar registro = 3");
            Console.WriteLine("Ver todos los registros = 4");
            Console.WriteLine("Buscar  un registros = 5");
            int Respuesta = int.Parse(Console.ReadLine());

            switch (Respuesta)
            {
                case 1:
                    PL.Producto.AddL();
                    break;
                case 2:
                    PL.Producto.UpDateL();
                    break;
                case 3:
                    PL.Producto.DeleteL();
                    break;
                case 4:
                    PL.Producto.GetAllL();
                    break;
                case 5:
                    PL.Producto.GetByIdL();
                    break;
            }
        }
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Introduce nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Introduce su precio");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor= int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento= int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce una descripcion");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.AddEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("El producto fue registrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al registrar el producto " + result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese ID del producto a eliminar:");
            int IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteEF(IdProducto);

            if (result.Correct)
            {
                Console.WriteLine("El producto fue eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar el producto " + result.ErrorMessage);
            }
        }
        public static void UpDate()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese ID del producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Introduce su precio");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce una descripcion");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.UpdateEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("El producto fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el producto " + result.ErrorMessage);
            }
        }
        public static void GetAll()
        {

            ML.Result result = BL.Producto.GetAllEF();

            if (result.Correct)
            {
                Console.WriteLine("Estos son todos los registros");
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("IdProducto---------->" + producto.IdProducto);
                    Console.WriteLine("Nombre-------------->" + producto.Nombre);
                    Console.WriteLine("PrecioUnitario------>" + producto.PrecioUnitario);
                    Console.WriteLine("Stock--------------->" + producto.Stock);
                    Console.WriteLine("Id-Proveedor-------->" + producto.Proveedor.IdProveedor);
                    Console.WriteLine("Id-Departamento----->" + producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripcion--------->" + producto.Descripcion);
                    Console.WriteLine("Imagen-------------->" + producto.Imagen);
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al mostrar los registros " + result.ErrorMessage);
            }
            Console.ReadKey();
        }   
        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id del producto que desee visualizar");

            ML.Producto producto = new ML.Producto();
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.GetByIdEF(producto.IdProducto);

            if (result.Correct)
            {
                producto = (ML.Producto)result.Object;

                Console.WriteLine("");
                Console.WriteLine("IdProducto---------->" + producto.IdProducto);
                Console.WriteLine("Nombre-------------->" + producto.Nombre);
                Console.WriteLine("PrecioUnitario------>" + producto.PrecioUnitario);
                Console.WriteLine("Stock--------------->" + producto.Stock);
                Console.WriteLine("Id-Proveedor-------->" + producto.Proveedor.IdProveedor);
                Console.WriteLine("Id-Departamento----->" + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion--------->" + producto.Descripcion);
                Console.WriteLine("Imagen-------------->" + producto.Imagen);

            }

        }

        public static void AddL() 
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Introduce nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Introduce su precio");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce una descripcion");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.AddLinq(producto);

            if (result.Correct)
            {
                Console.WriteLine("El producto fue registrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al registrar el producto " + result.ErrorMessage);
            }
        }
        public static void UpDateL()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese ID del producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Introduce su precio");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce una descripcion");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.UpdateLinq(producto);

            if (result.Correct)
            {
                Console.WriteLine("El producto fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el producto " + result.ErrorMessage);
            }
        }
        public static void DeleteL()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese ID del producto a eliminar:");
            int IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteLinq(IdProducto);

            if (result.Correct)
            {
                Console.WriteLine("El producto fue eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar el producto " + result.ErrorMessage);
            }
        }
        public static void GetAllL()
        {

            ML.Result result = BL.Producto.GetAllLinq();

            if (result.Correct)
            {
                Console.WriteLine("Estos son todos los registros");
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("IdProducto---------->" + producto.IdProducto);
                    Console.WriteLine("Nombre-------------->" + producto.Nombre);
                    Console.WriteLine("PrecioUnitario------>" + producto.PrecioUnitario);
                    Console.WriteLine("Stock--------------->" + producto.Stock);
                    Console.WriteLine("Id-Proveedor-------->" + producto.Proveedor.IdProveedor);
                    Console.WriteLine("Id-Departamento----->" + producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripcion--------->" + producto.Descripcion);
                    Console.WriteLine("Imagen-------------->" + producto.Imagen);
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al mostrar los registros " + result.ErrorMessage);
            }
            Console.ReadKey();
        }
        public static void GetByIdL()
        {
            Console.WriteLine("Ingrese el Id del producto que desee visualizar");

            ML.Producto producto = new ML.Producto();
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.GetByIdLinq(producto.IdProducto);

            if (result.Correct)
            {
                producto = (ML.Producto)result.Object;

                Console.WriteLine("");
                Console.WriteLine("IdProducto---------->" + producto.IdProducto);
                Console.WriteLine("Nombre-------------->" + producto.Nombre);
                Console.WriteLine("PrecioUnitario------>" + producto.PrecioUnitario);
                Console.WriteLine("Stock--------------->" + producto.Stock);
                Console.WriteLine("Id-Proveedor-------->" + producto.Proveedor.IdProveedor);
                Console.WriteLine("Id-Departamento----->" + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion--------->" + producto.Descripcion);
                Console.WriteLine("Imagen-------------->" + producto.Imagen);

            }

        }
    }
}
