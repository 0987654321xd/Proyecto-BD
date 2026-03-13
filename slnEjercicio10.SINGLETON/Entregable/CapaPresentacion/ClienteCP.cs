using CapaEntidad;
using CapaNegocios;
using CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCliente
{
    public partial class ClienteCP : Form
    {
        private static ClienteCP instancia = null;
        public static ClienteCP Instancia
        {
            get
            {
                if ((instancia == null) || (instancia.IsDisposed == true))
                {
                    instancia = new ClienteCP();
                }
                return instancia;
            }

        }
        public ClienteCP()
        {
            InitializeComponent();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            int idBuscar = Convert.ToInt32(txtCodigo.Text);
            ClienteCN clienteCN = new ClienteCN();
            ClienteCE clienteCE = clienteCN.getBuscarPorId(idBuscar);
            txtNombre.Text = clienteCE.Nombre;
            txtRUC.Text = clienteCE.Numruc;
            txtDireccion.Text = clienteCE.Direccion;
            txtTelefono.Text = clienteCE.Telefono;
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            string descripcionBuscar = txtNombreBuscar.Text;
            ClienteCN clienteCN = new ClienteCN();
            List<ClienteCE> listaClientesCE = clienteCN.getBuscarPorNombre(descripcionBuscar);
            dgvClientes.DataSource = listaClientesCE;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtRUC.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtNombreBuscar.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteCE clienteCE = new ClienteCE();

            clienteCE.Id = Convert.ToInt32(txtCodigo.Text);
            clienteCE.Nombre = txtNombre.Text;
            clienteCE.Numruc = txtRUC.Text;
            clienteCE.Direccion = txtDireccion.Text;
            clienteCE.Telefono = txtTelefono.Text;

            ClienteCN clienteCN = new ClienteCN();

            if (clienteCE.Id == 0)
            {
                txtCodigo.Text = clienteCN.setInsertar(clienteCE).ToString();

                MessageBox.Show("Registro Insertado !");
            }
            else
            {
                clienteCN.setActualizar(clienteCE);
                MessageBox.Show("Registro Actualizado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt32(txtCodigo.Text);

            if (idEliminar > 0)
            {
                DialogResult rpta = MessageBox.Show("Esta seguro que desea eliminar?", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (rpta == DialogResult.Yes)
                {
                    ClienteCN clienteCN = new ClienteCN();
                    clienteCN.setEliminar(idEliminar);
                    btnNuevo_Click(null, null);
                    MessageBox.Show("Registro Eliminado");
                }
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int cantidad = dgvClientes.SelectedRows.Count;

            if (cantidad > 0)
            {
                DataGridViewRow fila = dgvClientes.SelectedRows[0];

                txtCodigo.Text = fila.Cells["codigo"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtRUC.Text = fila.Cells["numruc"].Value.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
            }
        }
    }
}
