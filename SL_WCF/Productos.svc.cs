using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Productos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Productos.svc or Productos.svc.cs at the Solution Explorer and start debugging.
    public class Productos : IProductos
    {
        public SL_WCF.Result Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddEF(producto);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public Result Delete(int producto)
        {
            ML.Result result = BL.Producto.DeleteEF(producto);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public Result GetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public Result GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetByIdLinq(IdProducto);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public Result Update(ML.Producto producto)
        {
            ML.Result result = BL.Producto.UpdateEF(producto);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

    }
}
