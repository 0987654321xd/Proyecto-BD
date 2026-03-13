using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class ClienteCN
    {
        public ClienteCE getBuscarPorId(int idBuscar) 
        {
            ClienteCD clienteCD = new ClienteCD();
            ClienteCE clienteCE = clienteCD.getBuscarPorId(idBuscar);
            return clienteCE;
        }
        public List<ClienteCE> getBuscarPorNombre(string descripcionBuscar) 
        {
            ClienteCD clienteCD = new ClienteCD();
            List<ClienteCE> listaClientesCE = clienteCD.getBuscarPorNombre(descripcionBuscar);
            return listaClientesCE;
        }

        public int setInsertar(ClienteCE clienteCE) 
        {
            ClienteCD clienteCD = new ClienteCD();
            int nuevoId = clienteCD.setInsertar(clienteCE);
            return nuevoId;
        }

        public void setActualizar(ClienteCE clienteCE) 
        {
            ClienteCD clienteCD = new ClienteCD();
            clienteCD.setActualizar(clienteCE);
        }

        public void setEliminar(int idEliminar) 
        {
            ClienteCD clienteCD = new ClienteCD();
            clienteCD.setEliminar(idEliminar);
        }
    }
}
