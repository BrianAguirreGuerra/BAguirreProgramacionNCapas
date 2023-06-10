using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        //Menus
        public static void Menu1()
        {
            Console.WriteLine("Menu CON PROCEDIMIENTOS");
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
                    PL.Usuario.AddProcedure();
                    break;
                case 2:
                    PL.Usuario.UpdateProcedure();
                    break;
                case 3:
                    PL.Usuario.DeleteProcedure();
                    break;
                case 4:
                    PL.Usuario.GetAllProcedure();
                    break;
                case 5:
                    PL.Usuario.GetByIdProcedure();
                                        break;
            }
        }
        public static void Menu2()
        {
            Console.WriteLine("Menú ENTITY FRAMEWORK STORE");
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
                    PL.Usuario.AddEF();
                    break;
                case 2:
                    PL.Usuario.UpdateEF();
                    break;
                case 3:
                    PL.Usuario.DeleteEF();
                    break;
                case 4:
                    PL.Usuario.GetAllEF();
                    break;
                case 5:
                    PL.Usuario.GetByIdEF();
                    break;
            }
        }
        public static void Menu3()
        {
            Console.WriteLine("Menu ENTITY FRAMEWORK LINQ");
            Console.WriteLine("¿Que deseas hacer?");
            Console.WriteLine("Agregar registro = 1");
            Console.WriteLine("Actualizar Registro = 2");
            Console.WriteLine("Eliminar registro = 3");
            int Respuesta = int.Parse(Console.ReadLine());

            switch (Respuesta)
            {
                case 1:
                    PL.Usuario.AddL();
                    break;
                case 2:
                    PL.Usuario.UpDateL();
                    break;
                case 3:
                    PL.Usuario.DeleteL();
                    break;
                case 4:
                    PL.Usuario.GetAllL();
                    break;
                case 5:
                    PL.Usuario.GetByIdL();
                    break;
            }
        }
        //Pruebas
        public static void Add()
        {
            ML.Usuario usuario= new ML.Usuario();

            Console.WriteLine("Ingrese su primer nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno:");
            usuario.ApellidoMaterno= Console.ReadLine();

            Console.WriteLine("Introduce un nombre de usuario:");
            usuario.UserName= Console.ReadLine();

            Console.WriteLine("Ingrese su email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
            //usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce número celular:");
            usuario.Celular= Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introducir ID del rol de usuario");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue registrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al registrar el usuario " + result.ErrorMessage);
            }
        }
        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nuevo primer nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo apelllido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo apelllido materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo nombre de usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una nuevo contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce nuevo sexo:");
           // usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce nueva CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introducir nuevo ID del rol de usuario");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir nuevo ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Update(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar al usuario " + result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a eliminar:");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Delete(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar al usuario " + result.ErrorMessage);
            }
        }
        //Con Procedures
        public static void AddProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese su primer nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Introduce un nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
           // usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introduce tu fecha de nacimiento en un formato dd/MM/yyyy:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Introducir ID del rol de usuario:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.AddProcedure(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue registrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al registrar el usuario " + result.ErrorMessage);
            }
        }
        public static void UpdateProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a modificar:");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su nuevo nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Introduce un nuevo nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una nueva contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
            //usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introduce tu fecha de nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Introducir nuevo ID del rol de usuario:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir nuevo ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.UpdateProcedure(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar al usuario " + result.ErrorMessage);
            }
        }
        public static void DeleteProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a eliminar:");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.DeleteProcedure(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar al usuario " + result.ErrorMessage);
            }
        }
        public static void GetAllProcedure()
        {

            ML.Result result = BL.Usuario.GetAllProcedure();

            if (result.Correct)
            {
                Console.WriteLine("Estos son todos los registros");
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("IdUsuario----------->" + usuario.IdUsuario);
                    Console.WriteLine("Nombre-------------->" + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno----->" + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno----->" + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName------------>" + usuario.UserName);
                    Console.WriteLine("Email--------------->" + usuario.Email);
                    Console.WriteLine("Contraseña---------->" + usuario.Password);
                    Console.WriteLine("Sexo---------------->" + usuario.Sexo);
                    Console.WriteLine("Telefono------------>" + usuario.Telefono);
                    Console.WriteLine("Celular------------->" + usuario.Celular);
                    Console.WriteLine("CURP---------------->" + usuario.CURP);
                    Console.WriteLine("FechaNacimiento----->" + usuario.FechaNacimiento);
                    Console.WriteLine("Imagen-------------->" + usuario.Imagen);
                    Console.WriteLine("IdRol--------------->" + usuario.Rol.IdRol);
                    Console.WriteLine("IdUsuarioModificado->" + usuario.IdUsuarioModificado);
                    Console.WriteLine("FechaCreacion------->" + usuario.FechaCreacion);
                    Console.WriteLine("FechaModificacion--->" + usuario.FechaModificacion);
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al mostrar los registros " + result.ErrorMessage);
            }
            Console.ReadKey();
        }
        public static void GetByIdProcedure()
        {
            Console.WriteLine("Ingrese el Id que desee visualizar");

            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdProcedure(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;

                Console.WriteLine("");
                Console.WriteLine("IdUsuario----------->" + usuario.IdUsuario);
                Console.WriteLine("Nombre-------------->" + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno----->" + usuario.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno----->" + usuario.ApellidoMaterno);
                Console.WriteLine("UserName------------>" + usuario.UserName);
                Console.WriteLine("Email--------------->" + usuario.Email);
                Console.WriteLine("Contraseña---------->" + usuario.Password);
                Console.WriteLine("Sexo---------------->" + usuario.Sexo);
                Console.WriteLine("Telefono------------>" + usuario.Telefono);
                Console.WriteLine("Celular------------->" + usuario.Celular);
                Console.WriteLine("CURP---------------->" + usuario.CURP);
                Console.WriteLine("FechaNacimiento----->" + usuario.FechaNacimiento);
                Console.WriteLine("Imagen-------------->" + usuario.Imagen);
                Console.WriteLine("IdRol--------------->" + usuario.Rol.IdRol);
                Console.WriteLine("IdUsuarioModificado->" + usuario.IdUsuarioModificado);
                Console.WriteLine("FechaCreacion------->" + usuario.FechaCreacion);
                Console.WriteLine("FechaModificacion--->" + usuario.FechaModificacion);

            }

        }
        //Con EF
        public static void AddEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese su primer nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Introduce un nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
            //usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introduce tu fecha de nacimiento en un formato dd/MM/yyyy:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Introducir ID del rol de usuario:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue registrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al registrar el usuario " + result.ErrorMessage);
            }
        }
        public static void UpdateEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a modificar:");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su nuevo nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Introduce un nuevo nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una nueva contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
            //usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introduce tu fecha de nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Introducir nuevo ID del rol de usuario:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir nuevo ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar al usuario " + result.ErrorMessage);
            }
        }
        public static void DeleteEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a eliminar:");
            int IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar al usuario " + result.ErrorMessage);
            }
        }
        public static void GetAllEF()
        {

            ML.Result result = BL.Usuario.GetAllEF();

            if (result.Correct)
            {
                Console.WriteLine("Estos son todos los registros");
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("IdUsuario----------->" + usuario.IdUsuario);
                    Console.WriteLine("Nombre-------------->" + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno----->" + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno----->" + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName------------>" + usuario.UserName);
                    Console.WriteLine("Email--------------->" + usuario.Email);
                    Console.WriteLine("Contraseña---------->" + usuario.Password);
                    Console.WriteLine("Sexo---------------->" + usuario.Sexo);
                    Console.WriteLine("Telefono------------>" + usuario.Telefono);
                    Console.WriteLine("Celular------------->" + usuario.Celular);
                    Console.WriteLine("CURP---------------->" + usuario.CURP);
                    Console.WriteLine("FechaNacimiento----->" + usuario.FechaNacimiento);
                    Console.WriteLine("Imagen-------------->" + usuario.Imagen);
                    Console.WriteLine("IdRol--------------->" + usuario.Rol.IdRol);
                    Console.WriteLine("IdUsuarioModificado->" + usuario.IdUsuarioModificado);
                    Console.WriteLine("FechaCreacion------->" + usuario.FechaCreacion);
                    Console.WriteLine("FechaModificacion--->" + usuario.FechaModificacion);
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al mostrar los registros " + result.ErrorMessage);
            }
            Console.ReadKey();
        }
        public static void GetByIdEF()
        {
            Console.WriteLine("Ingrese el Id que desee visualizar");

            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;

                Console.WriteLine("");
                Console.WriteLine("IdUsuario----------->" + usuario.IdUsuario);
                Console.WriteLine("Nombre-------------->" + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno----->" + usuario.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno----->" + usuario.ApellidoMaterno);
                Console.WriteLine("UserName------------>" + usuario.UserName);
                Console.WriteLine("Email--------------->" + usuario.Email);
                Console.WriteLine("Contraseña---------->" + usuario.Password);
                Console.WriteLine("Sexo---------------->" + usuario.Sexo);
                Console.WriteLine("Telefono------------>" + usuario.Telefono);
                Console.WriteLine("Celular------------->" + usuario.Celular);
                Console.WriteLine("CURP---------------->" + usuario.CURP);
                Console.WriteLine("FechaNacimiento----->" + usuario.FechaNacimiento);
                Console.WriteLine("Imagen-------------->" + usuario.Imagen);
                Console.WriteLine("IdRol--------------->" + usuario.Rol.IdRol);
                Console.WriteLine("IdUsuarioModificado->" + usuario.IdUsuarioModificado);
                Console.WriteLine("FechaCreacion------->" + usuario.FechaCreacion);
                Console.WriteLine("FechaModificacion--->" + usuario.FechaModificacion);

            }

        }
        //Con Linq
        public static void AddL()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese su primer nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Introduce un nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
            //usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introduce tu fecha de nacimiento en un formato dd/MM/yyyy:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Introducir ID del rol de usuario:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.AddLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue registrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al registrar el usuario " + result.ErrorMessage);
            }
        }
        public static void UpDateL()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a modificar:");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su nuevo nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Introduce un nuevo nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Introduzca una nueva contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Introduce tu sexo:");
            //usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número de telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Introduce nuevo número celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Introduce tu CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Introduce tu fecha de nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Introducir nuevo ID del rol de usuario:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Introducir nuevo ID de usuario que esta modificando:");
            usuario.IdUsuarioModificado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.UpdateLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar al usuario " + result.ErrorMessage);
            }
        }
        public static void DeleteL()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese ID de registro a eliminar:");
            int IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.DeleteLinq(IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar al usuario " + result.ErrorMessage);
            }
        }
        public static void GetAllL()
        {

            ML.Result result = BL.Usuario.GetAllLinq();

            if (result.Correct)
            {
                Console.WriteLine("Estos son todos los registros");
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("IdUsuario----------->" + usuario.IdUsuario);
                    Console.WriteLine("Nombre-------------->" + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno----->" + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno----->" + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName------------>" + usuario.UserName);
                    Console.WriteLine("Email--------------->" + usuario.Email);
                    Console.WriteLine("Contraseña---------->" + usuario.Password);
                    Console.WriteLine("Sexo---------------->" + usuario.Sexo);
                    Console.WriteLine("Telefono------------>" + usuario.Telefono);
                    Console.WriteLine("Celular------------->" + usuario.Celular);
                    Console.WriteLine("CURP---------------->" + usuario.CURP);
                    Console.WriteLine("FechaNacimiento----->" + usuario.FechaNacimiento);
                    Console.WriteLine("Imagen-------------->" + usuario.Imagen);
                    Console.WriteLine("IdRol--------------->" + usuario.Rol.IdRol);
                    Console.WriteLine("IdUsuarioModificado->" + usuario.IdUsuarioModificado);
                    Console.WriteLine("FechaCreacion------->" + usuario.FechaCreacion);
                    Console.WriteLine("FechaModificacion--->" + usuario.FechaModificacion);
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
                Console.WriteLine("Ingrese el Id que desee visualizar");

                ML.Usuario usuario = new ML.Usuario();
                usuario.IdUsuario = int.Parse(Console.ReadLine());

                ML.Result result = BL.Usuario.GetByIdLinq(usuario.IdUsuario);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

                    Console.WriteLine("");
                    Console.WriteLine("IdUsuario----------->" + usuario.IdUsuario);
                    Console.WriteLine("Nombre-------------->" + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno----->" + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno----->" + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName------------>" + usuario.UserName);
                    Console.WriteLine("Email--------------->" + usuario.Email);
                    Console.WriteLine("Contraseña---------->" + usuario.Password);
                    Console.WriteLine("Sexo---------------->" + usuario.Sexo);
                    Console.WriteLine("Telefono------------>" + usuario.Telefono);
                    Console.WriteLine("Celular------------->" + usuario.Celular);
                    Console.WriteLine("CURP---------------->" + usuario.CURP);
                    Console.WriteLine("FechaNacimiento----->" + usuario.FechaNacimiento);
                    Console.WriteLine("Imagen-------------->" + usuario.Imagen);
                    Console.WriteLine("IdRol--------------->" + usuario.Rol.IdRol);
                    Console.WriteLine("IdUsuarioModificado->" + usuario.IdUsuarioModificado);
                    Console.WriteLine("FechaCreacion------->" + usuario.FechaCreacion);
                    Console.WriteLine("FechaModificacion--->" + usuario.FechaModificacion);

                }

            }
        public static void GetRolL()
        {
            Console.WriteLine("Ingrese el Id que desee visualizar");

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetRolLinq(usuario.Rol.IdRol);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;

                Console.WriteLine("");
                Console.WriteLine("Nombre-------------->" + usuario.Rol.Nombre);

            }

        }

    }
}
