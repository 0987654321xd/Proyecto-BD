using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class ProductoCP: Form
    {
        private static ProductoCP instancia = null;
        public static ProductoCP Instancia
        {
            get 
            { 
                if ((instancia==null) || (instancia.IsDisposed==true))
                {
                    instancia = new ProductoCP();
                }
                return instancia;
            }
            
        }
        public ProductoCP()
        {
            InitializeComponent();
        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {
            int idBuscar = Convert.ToInt32(txtId.Text);
            ProductoCN productoCN = new ProductoCN();
            ProductoCE productoCE = productoCN.getBuscarPorId(idBuscar);
            txtDescripcion.Text = productoCE.Descripcion;
            txtCategoria.Text = productoCE.Categoria;
            txtPrecio.Text = productoCE.Precio.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            txtDescripcion.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "0.0";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoCE productoCE = new ProductoCE();

            productoCE.Id = Convert.ToInt32(txtId.Text);
            productoCE.Descripcion = txtDescripcion.Text;
            productoCE.Categoria = txtCategoria.Text;
            productoCE.Precio = Convert.ToDouble(txtPrecio.Text);

            ProductoCN productoCN = new ProductoCN();

            if(productoCE.Id==0)
            {
                txtId.Text = productoCN.setInsertar(productoCE).ToString();
                MessageBox.Show("Registro Insertado !");
            }
            else
            {
                productoCN.setActualizar(productoCE);
                MessageBox.Show("Registro Actualizado !");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt32(txtId.Text);

            if (idEliminar > 0)
            {
                DialogResult rpta = MessageBox.Show("Esta seguro que desea eliminar?", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (rpta == DialogResult.Yes)
                {
                    ProductoCN productoCN = new ProductoCN();
                    productoCN.setEliminar(idEliminar);
                    btnNuevo_Click(null, null);
                    MessageBox.Show("Registro Eliminado");
                }
            }

        }

        private void btnBuscarDescripcion_Click(object sender, EventArgs e)
        {
            string descripcionBuscar = txtDescripcionBuscar.Text;
            ProductoCN productoCN = new ProductoCN();
            List<ProductoCE> listaProductosCE = productoCN.getBuscarPorDescripcion(descripcionBuscar);
            dgvProductos.DataSource = listaProductosCE;
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            int cantidad = dgvProductos.SelectedRows.Count;

            if (cantidad > 0)
            {
                DataGridViewRow fila = dgvProductos.SelectedRows[0];

                txtId.Text = fila.Cells["id"].Value.ToString();
                txtDescripcion.Text = fila.Cells["descripcion"].Value.ToString();
                txtCategoria.Text = fila.Cells["categoria"].Value.ToString();
                txtPrecio.Text = fila.Cells["precio"].Value.ToString();
            }

        }
    }
}
