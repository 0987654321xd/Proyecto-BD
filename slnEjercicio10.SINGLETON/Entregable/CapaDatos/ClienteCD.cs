using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class ClienteCD
    {
        public ClienteCE getBuscarPorId(int idBuscar)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM cliente where id = @idBuscar;";
            cmd.Parameters.AddWithValue("@idBuscar", idBuscar);

            SqlDataReader dr = cmd.ExecuteReader();

            bool existeFila = dr.Read();

            ClienteCE clienteCE = new ClienteCE();

            if (existeFila)
            {
                clienteCE.Id = Convert.ToInt32(dr["id"]);
                clienteCE.Nombre = Convert.ToString(dr["nombre"]);
                clienteCE.Numruc = Convert.ToString(dr["numruc"]);
                clienteCE.Direccion = Convert.ToString(dr["direccion"]);
                clienteCE.Telefono = Convert.ToString(dr["telefono"]);
            }
            else
            {
                clienteCE.Id = 0;
                clienteCE.Nombre = "No existe";
                clienteCE.Numruc = "";
                clienteCE.Direccion = "";
                clienteCE.Telefono = "";
            }
            cnx.Close();

            return clienteCE;
        }
        public List<ClienteCE> getBuscarPorNombre(string nombreBuscar)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM cliente where nombre LIKE '%'+ @nombreBuscar +'%';";
            cmd.Parameters.AddWithValue("@nombreBuscar", nombreBuscar);

            SqlDataReader dr = cmd.ExecuteReader();

            List<ClienteCE> listaClientesCE = new List<ClienteCE>();

            while (dr.Read())
            {
                ClienteCE clienteCE = new ClienteCE();

                clienteCE.Id = Convert.ToInt32(dr["id"]);
                clienteCE.Nombre = Convert.ToString(dr["nombre"]);
                clienteCE.Numruc = Convert.ToString(dr["numruc"]);
                clienteCE.Direccion = Convert.ToString(dr["direccion"]);
                clienteCE.Telefono = Convert.ToString(dr["telefono"]);

                listaClientesCE.Add(clienteCE);
            }
            cnx.Close();

            return listaClientesCE;
        }
        public int setInsertar(ClienteCE clienteCE)
        {
            int nuevoId = 0;

            using (SqlConnection cnx = ConexionCD.getConectarSqlServer())
            {
                cnx.Open();

                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO cliente (nombre, numruc, direccion, telefono) " +
                                  "VALUES (@nombre, @numruc, @direccion, @telefono);";

                cmd.Parameters.AddWithValue("@nombre", clienteCE.Nombre);
                cmd.Parameters.AddWithValue("@numruc", clienteCE.Numruc);
                cmd.Parameters.AddWithValue("@direccion", clienteCE.Direccion);
                cmd.Parameters.AddWithValue("@telefono", clienteCE.Telefono);

                using (SqlTransaction tr = cnx.BeginTransaction())
                {
                    cmd.Transaction = tr;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        tr.Commit();
                        cmd.CommandText = "SELECT MAX(id) AS nuevoId FROM cliente;";
                        cmd.Parameters.Clear();

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            nuevoId = Convert.ToInt32(dr["nuevoId"]);
                        }
                        dr.Close();
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

        public void setActualizar(ClienteCE clienteCE)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE cliente SET nombre = @nombre, numruc = @numruc, direccion = @direccion, telefono = @telefono where id = @id";
            cmd.Parameters.AddWithValue("@nombre", clienteCE.Nombre);
            cmd.Parameters.AddWithValue("@numruc", clienteCE.Numruc);
            cmd.Parameters.AddWithValue("@direccion", clienteCE.Direccion);
            cmd.Parameters.AddWithValue("@telefono", clienteCE.Telefono);
            cmd.Parameters.AddWithValue("@id", clienteCE.Id);

            cmd.ExecuteNonQuery();

            cnx.Close();
        }
        public void setEliminar(int idEliminar)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM cliente WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", idEliminar);

            cmd.ExecuteNonQuery();

            cnx.Close();
        }
    }

}
