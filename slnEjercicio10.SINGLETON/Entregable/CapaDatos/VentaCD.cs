using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class VentaCD
    {
        public int setInsertar(VentaCE venta)
        {
            int nuevoId = 0;
            using (SqlConnection cnx = ConexionCD.getConectarSqlServer())
            {
                cnx.Open();

                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO venta (fecventa, idCliente) " +
                                  "VALUES (@fecventa, @idCliente); " +
                                  "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@fecventa", venta.FechaVenta);
                cmd.Parameters.AddWithValue("@idCliente", venta.IdCliente);

                using (SqlTransaction tr = cnx.BeginTransaction())
                {
                    cmd.Transaction = tr;

                    try
                    {
                        nuevoId = Convert.ToInt32(cmd.ExecuteScalar());

                        tr.Commit();
                    }
                    catch (Exception)
                    {
                        tr.Rollback();
                        nuevoId = 0;
                    }
                }
            }
            return nuevoId;
        }

    }
}
