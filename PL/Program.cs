using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PL.Usuario.GetRolL();
            //Console.WriteLine("¿Que tabla deseas ver?");
            //Console.WriteLine("Usuario = 1");
            //Console.WriteLine("Producto = 2");
            //int Respuesta = int.Parse(Console.ReadLine());

            //switch (Respuesta)
            //{
            //    case 1:
            //        Console.WriteLine("TABLA USUARIO");
            //        Console.WriteLine("Que tipo de crud deseas usar");
            //        Console.WriteLine("Procedimientos Almacenados = 1");
            //        Console.WriteLine("Entity Framework Store = 2");
            //        Console.WriteLine("Entity Framework LinQ = 3");
            //        int crud = int.Parse(Console.ReadLine());
            //        switch (crud)
            //        {
            //            case 1:
            //                PL.Usuario.Menu1();
            //                break;
            //            case 2:
            //                PL.Usuario.Menu2();
            //                break;
            //            case 3:
            //                PL.Usuario.Menu3();
            //                break;
            //        }
            //        break;
            //    case 2:
            //        Console.WriteLine("TABLA PRODUCTO");
            //        Console.WriteLine("Que tipo de crud deseas usar");
            //        Console.WriteLine("Entity Framework Store = 1");
            //        Console.WriteLine("Entity Framework LinQ = 2");
            //        int crud2 = int.Parse(Console.ReadLine());
            //        switch (crud2)
            //        {
            //            case 1:
            //                PL.Producto.Menu1();
            //                break;
            //            case 2:
            //                PL.Producto.Menu2();
            //                break;
            //        }
            //                break;
            //        }
                    Console.ReadKey();
            }
    }
}
