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
    public partial class RelataContratos : Form
    {
        public RelataContratos()
        {
            InitializeComponent();
        }

        private void RelataContratos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'imobiliariaDBDataSet1.Contrato' table. You can move, or remove it, as needed.
            this.contratoTableAdapter1.Fill(this.imobiliariaDBDataSet1.Contrato);
            // TODO: This line of code loads data into the 'imobiliariaDBDataSet.Contrato' table. You can move, or remove it, as needed.
            this.contratoTableAdapter.Fill(this.imobiliariaDBDataSet.Contrato);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
