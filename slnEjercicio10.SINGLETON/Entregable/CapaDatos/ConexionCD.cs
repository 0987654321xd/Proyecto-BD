using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionCD
    {
        public static SqlConnection getConectarSqlServer()
        {
            SqlConnectionStringBuilder sqlGenerardorCadenas = new SqlConnectionStringBuilder();

            sqlGenerardorCadenas.DataSource = "localhost\\SQLEXPRESS"; 
            sqlGenerardorCadenas.InitialCatalog = "BD401"; 
            sqlGenerardorCadenas.UserID = "sa";
            sqlGenerardorCadenas.Password = "123"; 

            string cadenaConexion = sqlGenerardorCadenas.ConnectionString;

            SqlConnection sqlConexion = new SqlConnection(cadenaConexion);

            return sqlConexion;
        }
    }
}
