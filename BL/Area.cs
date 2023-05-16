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

    }
}
