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
    }
}
