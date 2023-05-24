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
    public class Direccion
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {

                    DL_EF1.Direccion direccion = new DL_EF1.Direccion();

                    direccion.Calle = usuario.Direccion.Calle;
                    direccion.NumeroInterior = usuario.Direccion.NumeroInterior;
                    direccion.NumeroExterior = usuario.Direccion.NumeroExterior;
                    direccion.IdColonia = usuario.Direccion.Colonia.IdColonia;
                    direccion.IdUsuario = usuario.IdUsuario;
                    context.Direccions.Add(direccion);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La direccion no fue registrada";
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
            Result result = new Result();
            try
            {

                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var updateResult = context.DireccionUpdate(usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, usuario.IdUsuario);

                    if (updateResult >= 1)
                    {
                            result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó la direccion";
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

        public static ML.Result Delete(int IdUsuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = (from direccion in context.Direccions
                                 where direccion.IdUsuario == IdUsuario
                                 select direccion).SingleOrDefault();

                    context.Direccions.Remove(query);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La direccion no pudo ser eliminada";
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
