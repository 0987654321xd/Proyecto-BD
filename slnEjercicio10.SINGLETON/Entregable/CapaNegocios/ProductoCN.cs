using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class ProductoCN
    {
        public ProductoCE getBuscarPorId(int idBuscar) 
        { 
            ProductoCD productoCD = new ProductoCD();
            ProductoCE productoCE = productoCD.getBuscarPorId(idBuscar);
            return productoCE;
        }
        public List<ProductoCE> getBuscarPorDescripcion(string descripcionBuscar) 
        {
            ProductoCD productoCD = new ProductoCD();
            List<ProductoCE> listaProductosCE = productoCD.getBuscarPorDescripcion(descripcionBuscar);
            return listaProductosCE;
        }

        public int setInsertar(ProductoCE productoCE) 
        {
            ProductoCD productoCD = new ProductoCD();
            int nuevoId = productoCD.setInsertar(productoCE);
            return nuevoId;
        }

        public void setActualizar(ProductoCE productoCE) 
        {
            ProductoCD productoCD = new ProductoCD();
            productoCD.setActualizar(productoCE);
        }

        public void setEliminar(int idEliminar) 
        {
            ProductoCD productoCD = new ProductoCD();
            productoCD.setEliminar(idEliminar);
        }
    }
}
