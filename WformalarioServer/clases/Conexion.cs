using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WformalarioServer.clases
{
    internal class Conexion
    { 
        //Bloque de código para establecer la conexíón entre nuestro programa y la base de datos que aparece con el botón MOSTRAR dentro de la interfaz gráfica.
        public static SqlConnection crearConexion()
        {
            SqlConnection conexion = new SqlConnection("server=DESKTOP-V71UB8P\\SQLEXPRESS; Initial Catalog=dboBases; Integrated Security = true");
            conexion.Open();
            return conexion;
        }
    }
}
