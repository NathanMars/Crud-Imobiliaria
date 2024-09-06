using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Final_Prog2
{
    public partial class RelataClientes : Form
    {
        public RelataClientes()
        {
            InitializeComponent();
        }

        private void RelataClientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'imobiliariaDBDataSet.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.imobiliariaDBDataSet.Cliente);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer3_Load(object sender, EventArgs e)
        {

        }
    }
}
