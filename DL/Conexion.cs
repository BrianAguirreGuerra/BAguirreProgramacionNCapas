using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["BAguirreProgramacionNCapas"].ConnectionString;
            return cadenaConexion;
        }
    }
}
