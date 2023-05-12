using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF1.BAguirreProgramacionNCapasEntities context = new DL_EF1.BAguirreProgramacionNCapasEntities())
                {
                    var listProveedor = (from proveedor in context.Proveedors
                                   select new
                                   {
                                       IdProveedor = proveedor.IdProveedor,
                                       Telefono = proveedor.Telefono,
                                   }).ToList();

                    if (listProveedor != null)
                    {

                        if (listProveedor.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (var obj in listProveedor)
                            {
                                ML.Proveedor ProveedorItem = new ML.Proveedor();
                                ProveedorItem.IdProveedor = obj.IdProveedor;
                                ProveedorItem.Telefono = obj.Telefono;

                                result.Objects.Add(ProveedorItem);
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
