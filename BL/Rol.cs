using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var listRol = (from rol in context.Rols
                                         select new
                                         {
                                             IdRol = rol.IdRol,
                                             Nombre = rol.Nombre,
                                         }).ToList();

                    if (listRol != null)
                    {

                        if (listRol.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listRol)
                            {
                                ML.Rol semestreItem = new ML.Rol();
                                semestreItem.IdRol = obj.IdRol;
                                semestreItem.Nombre = obj.Nombre;

                                result.Objects.Add(semestreItem);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La tabla Rol no tiene registros";
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
