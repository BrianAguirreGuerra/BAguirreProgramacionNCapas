using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var listArea = (from area in context.Areas
                                            select new
                                            {
                                                IdArea = area.IdArea,
                                                Nombre = area.Nombre,
                                            }).ToList();

                    if (listArea != null)
                    {

                        if (listArea.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listArea)
                            {
                                ML.Area AreaItem = new ML.Area();
                                AreaItem.IdArea = obj.IdArea;
                                AreaItem.Nombre = obj.Nombre;

                                result.Objects.Add(AreaItem);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La tabla Area no tiene registros";
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

        public static ML.Result GetByIdArea(int IdArea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var query = context.GetByIdArea(IdArea).ToList();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Departamento.Nombre = obj.Nombre;
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
    }
}
