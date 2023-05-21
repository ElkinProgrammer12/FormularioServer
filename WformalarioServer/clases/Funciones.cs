using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WformalarioServer.clases
{
    internal class Funciones
    {
        //El siguiente bloque de código representa el método para insertar nueva información en la base de datos.
        public static int insertarDatos(Usuarios add)
        {

            int estado = 0;

            SqlCommand comando = new SqlCommand(string.Format("insert into tlbAsistencia values(@intID,@strNOMBRE,@intEDAD,@strGRADO,@intTELEFONO,@strINSTITUCION,@strCORREO,@strGENERO)",
               add.IntID, add.StrNOMBRE, add.IntEDAD, add.StrGRADO, add.StrTELEFONO, add.StrINSTITUCION, add.StrCORREO, add.StrGENERO), Conexion.crearConexion());

            comando.Parameters.AddWithValue("@intID", add.IntID);
            comando.Parameters.AddWithValue("@strNOMBRE", add.StrNOMBRE);
            comando.Parameters.AddWithValue("@intEDAD", add.IntEDAD);
            comando.Parameters.AddWithValue("@strGRADO", add.StrGRADO);
            comando.Parameters.AddWithValue("@intTELEFONO", add.StrTELEFONO);
            comando.Parameters.AddWithValue("@strINSTITUCION", add.StrINSTITUCION);
            comando.Parameters.AddWithValue("@strCORREO", add.StrCORREO);
            comando.Parameters.AddWithValue("@strGENERO", add.StrGENERO);

            estado = comando.ExecuteNonQuery();

            return estado;
        }

        //Es necesario crear un método para mostrar información que ya en la base de datos.
        public static List<Usuarios> mostrarRegistro()
        {
            //Se obtiene los datos de la clase usuarios, donde estan todos los contructores 
            List<Usuarios> lista = new List<Usuarios>();
            //Hacemos la consulta en la tabla de datos.
            SqlCommand comando = new SqlCommand(string.Format("select * from tlbAsistencia"), Conexion.crearConexion());
            //Aparece un data reader para leer esa informacion que nos manda la información de comando.
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                Usuarios datos = new Usuarios();

                datos.IntID = leer.GetInt32(0);
                datos.StrNOMBRE = leer.GetString(1);
                datos.IntEDAD = leer.GetInt32(2);
                datos.StrGRADO = leer.GetString(3);
                datos.StrTELEFONO = leer.GetString(4);
                datos.StrINSTITUCION = leer.GetString(5);
                datos.StrCORREO = leer.GetString(6);
                datos.StrGENERO = leer.GetString(7);

                lista.Add(datos);

            }

            return lista;
        }

        //Se establece un método para hacer una busqueda dentro de la base de datos.
        public static List<Usuarios> buscar(int id)
        {
            List<Usuarios> lista = new List<Usuarios>();

            SqlCommand comando = new SqlCommand(string.Format("select * from tlbAsistencia where id = '{0}'", id), Conexion.crearConexion());

            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {

                Usuarios datos = new Usuarios();

                datos.IntID = leer.GetInt32(0);
                datos.StrNOMBRE = leer.GetString(1);
                datos.IntEDAD = leer.GetInt32(2);
                datos.StrGRADO = leer.GetString(3);
                datos.StrTELEFONO = leer.GetString(4);
                datos.StrINSTITUCION = leer.GetString(5);
                datos.StrCORREO = leer.GetString(6);
                datos.StrGENERO = leer.GetString(7);

                lista.Add(datos);

            }

            return lista;
        }
        //Crear metodo para obtener la info del usuario seleccionado

        //Metodo para elminar registro
        public static int eliminarUsuario(int id)
        {
            SqlCommand comando = new SqlCommand(string.Format("DELETE FROM tlbAsistencia WHERE ID = '{0}'", id), Conexion.crearConexion());
            int eliminar = comando.ExecuteNonQuery();
            return eliminar;
        }
        
    }
}
