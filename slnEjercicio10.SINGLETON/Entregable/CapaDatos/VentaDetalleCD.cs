using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class VentaDetalleCD
    {
        public ClienteCE BuscarClientePorId(int idCliente)
        {
            using (SqlConnection cnx = ConexionCD.getConectarSqlServer())
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM cliente WHERE id = @id", cnx);
                cmd.Parameters.AddWithValue("@id", idCliente);
                SqlDataReader dr = cmd.ExecuteReader();
                ClienteCE cliente = new ClienteCE();

                if (dr.Read())
                {
                    cliente.Id = Convert.ToInt32(dr["id"]);
                    cliente.Nombre = dr["nombre"].ToString();
                }
                else
                {
                    cliente.Id = 0;
                    cliente.Nombre = "- No existe -";
                }
                return cliente;
            }
        }
        public ProductoCE BuscarProductoPorId(int idProducto)
        {
            using (SqlConnection cnx = ConexionCD.getConectarSqlServer())
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, descripcion, precio FROM producto WHERE id = @id", cnx);
                cmd.Parameters.AddWithValue("@id", idProducto);
                SqlDataReader dr = cmd.ExecuteReader();
                ProductoCE producto = new ProductoCE();

                if (dr.Read())
                {
                    producto.Id = Convert.ToInt32(dr["id"]);
                    producto.Descripcion = dr["descripcion"].ToString();
                    producto.Precio = Convert.ToDouble(dr["precio"]);
                }
                else
                {
                    producto.Id = 0;
                    producto.Descripcion = "- No existe -";
                    producto.Precio = 0.0;
                }
                return producto;
            }
        }
        public int setInsertarDetalle(VentaDetalleCE ventaDetalle, int idVenta)
        {
            using (SqlConnection cnx = ConexionCD.getConectarSqlServer())
            {
                cnx.Open();

                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO detalle (idventa, idproducto, cantidad) " +
                                  "VALUES (@idVenta, @idProducto, @cantidad); " +
                                  "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@idProducto", ventaDetalle.Producto.Id);
                cmd.Parameters.AddWithValue("@cantidad", ventaDetalle.Cantidad);

                int nuevoId = 0;

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
                return nuevoId;
            }
        }

    }

}
