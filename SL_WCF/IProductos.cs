﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductos" in both code and config file together.
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Producto producto);

        [OperationContract]
        SL_WCF.Result Delete(int producto);

        [OperationContract]
        SL_WCF.Result Update(ML.Producto producto);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        SL_WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        SL_WCF.Result GetById(int IdProducto);
    }
}
