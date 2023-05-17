using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = context.MunicipioGetByIdEstado(IdEstado).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = obj.IdMunicipio;
                            municipio.Nombre = obj.NombreMunicipio;
                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = obj.IdEstado.Value;
                            municipio.Estado.Nombre = obj.NombreEstado;
                            result.Objects.Add(municipio);
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
    }
}
