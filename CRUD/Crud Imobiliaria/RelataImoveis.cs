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
    public partial class RelataImoveis : Form
    {
        public RelataImoveis()
        {
            InitializeComponent();
        }

        private void RelataImoveis_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'imobiliariaDBDataSet2.Imovel' table. You can move, or remove it, as needed.
            this.imovelTableAdapter1.Fill(this.imobiliariaDBDataSet2.Imovel);
            // TODO: This line of code loads data into the 'imobiliariaDBDataSet.Imovel' table. You can move, or remove it, as needed.
            this.imovelTableAdapter.Fill(this.imobiliariaDBDataSet.Imovel);
            // TODO: This line of code loads data into the 'imobiliariaDBDataSet.Contrato' table. You can move, or remove it, as needed.
            this.contratoTableAdapter.Fill(this.imobiliariaDBDataSet.Contrato);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
