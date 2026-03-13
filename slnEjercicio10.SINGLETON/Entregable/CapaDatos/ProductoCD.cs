using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Habilitar los namespace
using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class ProductoCD
    {
        public ProductoCE getBuscarPorId(int idBuscar)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from producto where id=@idBuscar;";
            cmd.Parameters.AddWithValue("@idBuscar", idBuscar);

            SqlDataReader dr = cmd.ExecuteReader(); // SELECT

            bool existeFila = dr.Read();

            ProductoCE productoCE = new ProductoCE();

            if (existeFila)
            {
                productoCE.Id = Convert.ToInt32(dr["id"]);
                productoCE.Descripcion = Convert.ToString(dr["descripcion"]);
                productoCE.Categoria = Convert.ToString(dr["categoria"]);
                productoCE.Precio = Convert.ToDouble(dr["precio"]);

            }
            else
            {
                productoCE.Id = 0;
                productoCE.Descripcion = "- No existe -";
                productoCE.Categoria = "";
                productoCE.Precio = 0.0;

            }
            cnx.Close();

            return productoCE;
        }
        public List<ProductoCE> getBuscarPorDescripcion(string descripcionBuscar)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from producto where descripcion LIKE '%'+ @descripcionBuscar +'%';";
            cmd.Parameters.AddWithValue("@descripcionBuscar", descripcionBuscar);

            SqlDataReader dr = cmd.ExecuteReader(); 

            List<ProductoCE> listaProductosCE = new List<ProductoCE>();


            while (dr.Read())
            {
                ProductoCE productoCE = new ProductoCE();

                productoCE.Id = Convert.ToInt32(dr["id"]);
                productoCE.Descripcion = Convert.ToString(dr["descripcion"]);
                productoCE.Categoria = Convert.ToString(dr["categoria"]);
                productoCE.Precio = Convert.ToDouble(dr["precio"]);

                listaProductosCE.Add(productoCE);

            }

            cnx.Close();

            return listaProductosCE;
        }
        public int setInsertar(ProductoCE productoCE)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into producto (descripcion, categoria, precio) values (@descripcion, @categoria, @precio)";
            cmd.Parameters.AddWithValue("@descripcion", productoCE.Descripcion);
            cmd.Parameters.AddWithValue("@categoria", productoCE.Categoria);
            cmd.Parameters.AddWithValue("@precio", productoCE.Precio);

            cmd.ExecuteNonQuery();

            cmd.CommandText = "select max(id) as nuevoId from producto;";

            SqlDataReader dr = cmd.ExecuteReader();

            bool existeFila = dr.Read();

            int nuevoId;

            if (existeFila)
            {
                nuevoId = Convert.ToInt32(dr["nuevoId"]);
            }
            else
            {
                nuevoId = 0;
            }

            cnx.Close();

            return nuevoId;
        }
        public void setActualizar(ProductoCE productoCE)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update producto set descripcion=@descripcion, categoria=@categoria, precio=@precio where id=@id";
            cmd.Parameters.AddWithValue("@descripcion", productoCE.Descripcion);
            cmd.Parameters.AddWithValue("@categoria", productoCE.Categoria);
            cmd.Parameters.AddWithValue("@precio", productoCE.Precio);
            cmd.Parameters.AddWithValue("@id", productoCE.Id);


            cmd.ExecuteNonQuery();

            cnx.Close();
        }
        public void setEliminar(int idEliminar)
        {
            SqlConnection cnx = ConexionCD.getConectarSqlServer();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from producto where id=@id";
            cmd.Parameters.AddWithValue("@id", idEliminar);

            cmd.ExecuteNonQuery(); 

            cnx.Close();
        }
        
    }
}
