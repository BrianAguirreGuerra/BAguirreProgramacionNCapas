using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = obj.IdEstado;
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = obj.IdPais.Value;
                            estado.Pais.Nombre = obj.NombrePais;
                            estado.Nombre = obj.NombreEstado;
                            result.Objects.Add(estado);
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
