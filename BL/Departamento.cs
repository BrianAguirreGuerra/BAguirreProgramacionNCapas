using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var listDepartamento = (from departamento in context.Departamentoes
                                         select new
                                         {
                                             IdDepartamento = departamento.IdDepartamento,
                                             Nombre = departamento.Nombre,
                                         }).ToList();

                    if (listDepartamento != null)
                    {

                        if (listDepartamento.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listDepartamento)
                            {
                                ML.Departamento ProveedorItem = new ML.Departamento();
                                ProveedorItem.IdDepartamento = obj.IdDepartamento;
                                ProveedorItem.Nombre = obj.Nombre;

                                result.Objects.Add(ProveedorItem);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La tabla Departamento no tiene registros";
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
