using pryCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class PrincipalCP : Form
    {
        public PrincipalCP()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ProductoCP.Instancia.MdiParent = this;
            ProductoCP.Instancia.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteCP.Instancia.MdiParent = this;
            ClienteCP.Instancia.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentaDetalleCP.Instancia.MdiParent = this;
            VentaDetalleCP.Instancia.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
