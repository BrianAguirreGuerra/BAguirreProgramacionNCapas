using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using ML;
using System.Collections;
using DL_EF1;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Data.Entity.Core.Objects;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO Usuario (Nombre,ApellidoPaterno,ApellidoMaterno,UserName,Email,Pass,Sexo,Telefono,Celular,CURP,IdRol,IdUsuarioModificado) VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@UserName,@Email,@Pass,@Sexo,@Telefono,@Celular,@Curp,@IdRol,@IdUsuarioModificado)";
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Pass", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@Curp", usuario.CURP);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                        cmd.Parameters.AddWithValue("@IdUsuarioModificado", usuario.IdUsuarioModificado);
                        context.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo registrar el usuario";
                        }
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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UPDATE Usuario SET Nombre = @Nombre, ApellidoPaterno  = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno, UserName = @UserName, Email = @Email, Pass = @Pass, Sexo = @Sexo, Telefono = @Telefono, Celular = @Celular, Curp = @Curp, IdRol = @IdRol, IdUsuarioModificado = @IdUsuarioModificado WHERE IdUsuario = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Pass", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@Curp", usuario.CURP);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                        cmd.Parameters.AddWithValue("@IdUsuarioModificado", usuario.IdUsuarioModificado);
                        context.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No se pudo actualizar el usuario";
                        }
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
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "delete from Usuario where IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        context.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No se pudo eliminar el usuario";
                        }
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

        //Con Procedimientos Almacenados
        public static ML.Result GetAllProcedure()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetAll";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable GetAllUsuarios = new DataTable();
                            adapter.Fill(GetAllUsuarios);

                            result.Objects = new List<object>();


                            foreach (DataRow lineas in GetAllUsuarios.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(lineas[0].ToString());
                                usuario.Nombre = lineas[1].ToString();
                                usuario.ApellidoPaterno = lineas[2].ToString();
                                usuario.ApellidoMaterno = lineas[3].ToString();
                                usuario.UserName = lineas[4].ToString();
                                usuario.Email = lineas[5].ToString();
                                usuario.Password = lineas[6].ToString();
                                usuario.Sexo = char.Parse(lineas[7].ToString());
                                usuario.Telefono = lineas[8].ToString();
                                usuario.Celular = lineas[9].ToString();
                                usuario.CURP = lineas[10].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = (lineas[11].ToString() != "") ? byte.Parse(lineas[11].ToString()) : byte.Parse("0");
                                usuario.IdUsuarioModificado = (lineas[12].ToString() != "") ? int.Parse(lineas[12].ToString()) : int.Parse("0");
                                usuario.FechaNacimiento = (lineas[13].ToString() != "") ? lineas[13].ToString() : "0";
                                usuario.Imagen = Encoding.ASCII.GetBytes(lineas[14].ToString());
                                usuario.FechaCreacion = (lineas[15].ToString() != "") ? lineas[15].ToString() : "0";
                                usuario.FechaModificacion = (lineas[16].ToString() != "") ? lineas[16].ToString() : "0";
                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }


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
        public static ML.Result GetByIdProcedure(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetById";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable GetByIdUsuario = new DataTable();

                            da.Fill(GetByIdUsuario);

                            if (GetByIdUsuario.Rows.Count > 0)
                            {
                                DataRow lineas = GetByIdUsuario.Rows[0];

                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(lineas[0].ToString());
                                usuario.Nombre = lineas[1].ToString();
                                usuario.ApellidoPaterno = lineas[2].ToString();
                                usuario.ApellidoMaterno = lineas[3].ToString();
                                usuario.UserName = lineas[4].ToString();
                                usuario.Email = lineas[5].ToString();
                                usuario.Password = lineas[6].ToString();
                                usuario.Sexo = char.Parse(lineas[7].ToString());
                                usuario.Telefono = lineas[8].ToString();
                                usuario.Celular = lineas[9].ToString();
                                usuario.CURP = lineas[10].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = (lineas[11].ToString() != "") ? byte.Parse(lineas[11].ToString()) : byte.Parse("0");
                                usuario.IdUsuarioModificado = (lineas[12].ToString() != "") ? int.Parse(lineas[12].ToString()) : int.Parse("0");
                                usuario.FechaNacimiento = (lineas[13].ToString() != "") ? lineas[13].ToString() : "0";
                                usuario.Imagen = Encoding.ASCII.GetBytes(lineas[14].ToString());
                                usuario.FechaCreacion = (lineas[15].ToString() != "") ? lineas[15].ToString() : "0";
                                usuario.FechaModificacion = (lineas[16].ToString() != "") ? lineas[16].ToString() : "0";
                                result.Object = usuario;//Boxing

                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "La tabla materia no tiene registros";
                            }


                            result.Correct = true;
                        }
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
        public static ML.Result AddProcedure(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "EXECUTE UsuarioAdd @Nombre,@ApellidoPaterno,@ApellidoMaterno,@UserName,@Email,@Pass,@Sexo,@Telefono,@Celular,@Curp,@IdRol,@IdUsuarioModificado,@FechaNacimiento,@Imagen";
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Pass", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@Curp", usuario.CURP);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                        cmd.Parameters.AddWithValue("@IdUsuarioModificado", usuario.IdUsuarioModificado);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.Add("@Imagen", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                        context.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo registrar el usuario";
                        }
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
        public static ML.Result UpdateProcedure(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "EXECUTE UsuarioUpdate @Nombre,@ApellidoPaterno,@ApellidoMaterno,@UserName,@Email,@Pass,@Sexo,@Telefono,@Celular,@Curp,@IdRol,@IdUsuarioModificado,@FechaNacimiento,@Imagen,@IdUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Pass", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@Curp", usuario.CURP);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                        cmd.Parameters.AddWithValue("@IdUsuarioModificado", usuario.IdUsuarioModificado);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.Add("@Imagen", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        context.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No se pudo actualizar el usuario";
                        }
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
        public static ML.Result DeleteProcedure(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "EXECUTE UsuarioDelete @IdUsuario";
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        context.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No se pudo eliminar el usuario";
                        }
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

        //En Entity Framework
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                    DateTime dt = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    
                    ObjectParameter IdUsuario = new ObjectParameter("IdUsuario", typeof(int));

                    var query = context.UsuarioAdd(IdUsuario,
                                                   usuario.Nombre,
                                                   usuario.ApellidoPaterno,
                                                   usuario.ApellidoMaterno,
                                                   usuario.UserName,
                                                   usuario.Email,
                                                   usuario.Password,
                                                   usuario.Sexo.ToString(),
                                                   usuario.Telefono,
                                                   usuario.Celular,
                                                   usuario.CURP,
                                                   usuario.Rol.IdRol,
                                                   usuario.IdUsuarioModificado,
                                                   dt,
                                                   usuario.Imagen);

                    context.SaveChanges();

                    if ((int)IdUsuario.Value > 0)
                    {
                        usuario.IdUsuario = (int)IdUsuario.Value;

                        ML.Result resultDireccion = BL.Direccion.Add(usuario);

                        if (resultDireccion.Correct)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = resultDireccion.ErrorMessage;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static Result DeleteEF(int IdUsuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                    var query = context.UsuarioDelete(IdUsuario);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static Result UpdateEF(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {

                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    DateTime dt = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var updateResult = context.UsuarioUpdate(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo.ToString(), usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, dt, usuario.Imagen, usuario.IdUsuario);
                    
                    if (updateResult >= 1)
                    {
                        ML.Result resultDireccion = BL.Direccion.Update(usuario);

                        if (resultDireccion.Correct)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = resultDireccion.ErrorMessage;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el usuario";
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

                    var usuarios1 = context.UsuarioGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios1 != null)
                    {
                        foreach (var obj in usuarios1)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.UsuarioNombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = (obj.ApellidoMaterno != null) ? obj.ApellidoMaterno : "0";
                            usuario.UserName = obj.UserName;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Pass;
                            string sexo = obj.Sexo;
                            usuario.Sexo = char.Parse(sexo.Replace(" ",""));
                            usuario.SexoNombre = obj.SexoNombre;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = (obj.Celular != null) ? obj.Celular : "0";
                            usuario.CURP = (obj.CURP != null) ? obj.CURP : "0";
                            usuario.FechaNacimiento = (obj.FechaNacimiento != null) ? obj.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "0";
                            usuario.Imagen = obj.Imagen;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (obj.IdRol != null) ? obj.IdRol.Value : byte.Parse("0");
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.Nombre = (obj.RolNombre != null) ? obj.RolNombre : "0";
                            usuario.IdUsuarioModificado = (obj.IdUsuarioModificado != null) ? obj.IdUsuarioModificado.Value : int.Parse("0");
                            usuario.FechaCreacion = (obj.FechaCreacion != null) ? obj.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm:ss") : "0";
                            usuario.FechaModificacion = (obj.FechaModificacion != null) ? obj.FechaModificacion.Value.ToString("dd/MM/yyyy HH:mm:ss") : "0";
                            usuario.Estatus = (obj.Estatus != null) ? obj.Estatus.Value : false;
                            result.Objects.Add(usuario);
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
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var usuarios1 = context.UsuarioGetById(IdUsuario).SingleOrDefault();

                    if (usuarios1 != null)
                    {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = usuarios1.IdUsuario;
                            usuario.Nombre = usuarios1.Nombre;
                            usuario.ApellidoPaterno = usuarios1.ApellidoPaterno;
                            usuario.ApellidoMaterno = usuarios1.ApellidoMaterno;
                            usuario.UserName = usuarios1.UserName;
                            usuario.Email = usuarios1.Email;
                            usuario.Password = usuarios1.Pass;
                            //usuario.Sexo = char.Parse(usuarios1.Sexo);
                            usuario.Telefono = usuarios1.Telefono;
                            usuario.Celular = usuarios1.Celular;
                            usuario.CURP = usuarios1.CURP;
                            usuario.FechaNacimiento = usuarios1.FechaNacimiento.ToString();
                            usuario.Imagen = usuarios1.Imagen;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (byte)usuarios1.IdRol;
                            //usuario.IdUsuarioModificado = (int)usuarios1.IdUsuarioModificado;
                            usuario.FechaCreacion = usuarios1.FechaCreacion.ToString();
                            usuario.FechaModificacion = usuarios1.FechaModificacion.ToString();
                            result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }


                    result.Correct = true;
                        }
                    }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;

        }
        public static ML.Result GetRolEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var usuarios1 = context.UsuarioGetRol(IdUsuario).SingleOrDefault();

                    if (usuarios1 != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.Nombre = usuarios1;
                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }


                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;

        }

        public static ML.Result EstatusUpdate(int IdUsuario, bool Estatus)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var usuarios1 = context.EstatusUpdate(Estatus, IdUsuario);

                    if (usuarios1 >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el estatus.";
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
        public static ML.Result AddLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                    DL_EF1.Usuario usuarioDL = new DL_EF1.Usuario();


                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Pass = usuario.Password;
                    usuarioDL.Sexo = usuario.Sexo.ToString();
                    usuarioDL.Telefono= usuario.Telefono;
                    usuarioDL.Celular= usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;
                    usuarioDL.IdRol = usuario.Rol.IdRol;
                    usuarioDL.IdUsuarioModificado = usuario.IdUsuarioModificado;
                    DateTime dt = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    usuarioDL.FechaNacimiento = dt;
                    usuarioDL.Imagen = usuario.Imagen;
                    usuarioDL.FechaCreacion = DateTime.Now;
                    usuarioDL.FechaModificacion = DateTime.Now;
                    context.Usuarios.Add(usuarioDL);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El usuario no fue insertado";
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
        public static ML.Result UpdateLinq(ML.Usuario usuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from tablausuario in context.Usuarios
                                 where tablausuario.IdUsuario == usuario.IdUsuario
                                 select tablausuario).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.UserName = usuario.UserName;
                        query.Email = usuario.Email;
                        query.Pass = usuario.Password;
                        query.Sexo = usuario.Sexo.ToString();
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;
                        //query.IdUsuarioModificado = usuario.IdUsuarioModificado;
                        DateTime dt = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        query.FechaNacimiento = dt;
                        query.Imagen = usuario.Imagen;
                        query.FechaModificacion = DateTime.Now;

                        int rowsAffected = context.SaveChanges();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no fue actualizado";
                        }
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el grupo" + usuario.IdUsuario;
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
        public static ML.Result DeleteLinq(int IdUsuario)
        {
            Result result = new Result();
            ML.Result resultDireccion = BL.Direccion.Delete(IdUsuario);
            if (resultDireccion.Correct)
            {
                try
                {
                    using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                    {
                        var query = (from Usuario in context.Usuarios
                                     where Usuario.IdUsuario == IdUsuario
                                     select Usuario).SingleOrDefault();

                        context.Usuarios.Remove(query);
                        int rowsAffected = context.SaveChanges();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no fue eliminado";
                        }
                    }
                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "El usuario no fue eliminado";
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
                    var query = (from usuario in context.Usuarios
                                 select new { IdUsuario = usuario.IdUsuario, Nombre = usuario.Nombre, ApellidoPaterno = usuario.ApellidoPaterno, ApellidoMaterno = usuario.ApellidoMaterno, UserName = usuario.UserName, Email = usuario.Email, Password = usuario.Pass, Sexo = usuario.Sexo, Telefono = usuario.Telefono, Celular = usuario.Celular, CURP = usuario.CURP, IdRol = usuario.IdRol, IdUsuarioModificado = usuario.IdUsuarioModificado, FechaNacimiento = usuario.FechaNacimiento, Imagen = usuario.Imagen, FechaCreacion = usuario.FechaCreacion, FechaModificacion = usuario.FechaModificacion});

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuariolista = new ML.Usuario();
                            usuariolista.IdUsuario = obj.IdUsuario;
                            usuariolista.Nombre = obj.Nombre;
                            usuariolista.ApellidoPaterno= obj.ApellidoPaterno;
                            usuariolista.ApellidoMaterno = (obj.ApellidoMaterno != null) ? obj.ApellidoMaterno : "0";
                            usuariolista.UserName= obj.UserName;
                            usuariolista.Email = obj.Email;
                            usuariolista.Password= obj.Password;
                            usuariolista.Sexo= char.Parse(obj.Sexo); //Masculino
                            usuariolista.Telefono= obj.Telefono;
                            usuariolista.Celular= (obj.Celular != null) ? obj.Celular : "0";
                            usuariolista.CURP= (obj.CURP != null) ? obj.CURP : "0";
                            usuariolista.Rol = new ML.Rol();
                            usuariolista.Rol.IdRol = (obj.IdRol != null) ? obj.IdRol.Value : byte.Parse("0");
                            usuariolista.IdUsuarioModificado = (obj.IdUsuarioModificado != null) ? obj.IdUsuarioModificado.Value : int.Parse("0");
                            usuariolista.FechaNacimiento = (obj.FechaNacimiento != null) ? obj.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "0";
                            usuariolista.Imagen = obj.Imagen;
                            usuariolista.FechaCreacion = (obj.FechaCreacion != null) ? obj.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm:ss") : "0";
                            usuariolista.FechaModificacion = (obj.FechaModificacion != null) ? obj.FechaModificacion.Value.ToString("dd/MM/yyyy HH:mm:ss") : "0";
                            result.Objects.Add(usuariolista);

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
        public static ML.Result GetByIdLinq(int IdUsuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from usuario in context.Usuarios
                                 join direccion in context.Direccions on usuario.IdUsuario equals direccion.IdUsuario
                                 join colonia in context.Colonias on direccion.IdColonia equals colonia.IdColonia
                                 join municipio in context.Municipios on colonia.IdMunicipio equals municipio.IdMunicipio
                                 join estado in context.Estadoes on municipio.IdEstado equals estado.IdEstado
                                 join pais in context.Pais on estado.IdPais equals pais.IdPais
                                 where usuario.IdUsuario == IdUsuario
                                 select new { IdUsuario = usuario.IdUsuario, Nombre = usuario.Nombre, ApellidoPaterno = usuario.ApellidoPaterno, ApellidoMaterno = usuario.ApellidoMaterno, UserName = usuario.UserName, Email = usuario.Email, Password = usuario.Pass, Sexo = usuario.Sexo, Telefono = usuario.Telefono, Celular = usuario.Celular, CURP = usuario.CURP, IdRol = usuario.IdRol, IdUsuarioModificado = usuario.IdUsuarioModificado, FechaNacimiento = usuario.FechaNacimiento, Imagen = usuario.Imagen, FechaCreacion = usuario.FechaCreacion, FechaModificacion = usuario.FechaModificacion, IdDireccion = direccion.IdDireccion, Calle = direccion.Calle, NumeroInterior = direccion.NumeroInterior, NumeroExterior = direccion.NumeroExterior, IdColonia = direccion.IdColonia, IdMunicipio = colonia.IdMunicipio, IdEstado = municipio.IdEstado, IdPais = estado.IdPais }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuariolista = new ML.Usuario();
                        usuariolista.IdUsuario = query.IdUsuario;
                        usuariolista.Nombre = query.Nombre;
                        usuariolista.ApellidoPaterno = query.ApellidoPaterno;
                        usuariolista.ApellidoMaterno = (query.ApellidoMaterno != null) ? query.ApellidoMaterno : "0";
                        usuariolista.UserName = query.UserName;
                        usuariolista.Email = query.Email;
                        usuariolista.Password = query.Password;
                        string sexo = query.Sexo;
                        usuariolista.Sexo = char.Parse(sexo.Replace(" ", ""));
                        usuariolista.Telefono = query.Telefono;
                        usuariolista.Celular = (query.Celular != null) ? query.Celular : "0";
                        usuariolista.CURP = (query.CURP != null) ? query.CURP : "0";
                        usuariolista.Rol = new ML.Rol();
                        usuariolista.Rol.IdRol = (query.IdRol != null) ? query.IdRol.Value : byte.Parse("0");
                        usuariolista.IdUsuarioModificado = (query.IdUsuarioModificado != null) ? query.IdUsuarioModificado.Value : int.Parse("0");
                        usuariolista.FechaNacimiento = (query.FechaNacimiento != null) ? query.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "0";
                        usuariolista.Imagen = query.Imagen;
                        usuariolista.FechaCreacion = (query.FechaCreacion != null) ? query.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm:ss") : "0";
                        usuariolista.FechaModificacion = (query.FechaModificacion != null) ? query.FechaModificacion.Value.ToString("dd/MM/yyyy HH:mm:ss") : "0";
                        usuariolista.Direccion = new ML.Direccion();
                        usuariolista.Direccion.IdDireccion = (query.IdDireccion != null) ? query.IdDireccion : int.Parse("0");
                        usuariolista.Direccion.Calle = (query.Calle != null) ? query.Calle : "0";
                        usuariolista.Direccion.NumeroInterior = (query.NumeroInterior != null) ? query.NumeroInterior : "0";
                        usuariolista.Direccion.NumeroExterior = (query.NumeroExterior != null) ? query.NumeroExterior : "0";
                        usuariolista.Direccion.Colonia = new ML.Colonia();
                        usuariolista.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuariolista.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuariolista.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuariolista.Direccion.Colonia.IdColonia = (query.IdColonia != null) ? query.IdColonia.Value : int.Parse("0");
                        usuariolista.Direccion.Colonia.Municipio.IdMunicipio = (query.IdMunicipio != null) ? query.IdMunicipio.Value : int.Parse("0");  
                        usuariolista.Direccion.Colonia.Municipio.Estado.IdEstado = (query.IdEstado != null) ? query.IdEstado.Value : int.Parse("0");
                        usuariolista.Direccion.Colonia.Municipio.Estado.Pais.IdPais = (query.IdPais != null) ? query.IdPais.Value : int.Parse("0");
                        result.Object = usuariolista;
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
        public static ML.Result GetRolLinq(int IdUsuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from usuario in context.Usuarios
                                 join rol in context.Rols
                                 on usuario.IdRol equals rol.IdRol
                                 where usuario.IdUsuario == IdUsuario
                                 select new { Nombre = rol.Nombre}).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuariolista = new ML.Usuario();
                        usuariolista.Rol = new ML.Rol();
                        usuariolista.Rol.Nombre = (query.Nombre != null) ? query.Nombre : "0";
                        result.Object = usuariolista;
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
