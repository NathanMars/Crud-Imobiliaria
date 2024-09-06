using System;
using System.Windows.Forms;


namespace Trabalho_Final_Prog2
{
    /// <summary>
    /// Classe do menu principal, abre diferentes formularios através de Menustrip
    /// </summary>
    /// <remarks>
    /// Função de Relatórios depende da Extensão RDLC e o pacote NuGet Microsoft.ReportingServices.ReportViewerControl.Winforms
    /// </remarks>
    public partial class Forms1 : Form
    {
        public Forms1()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente Ccad = new Cliente();
            Ccad.ShowDialog();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Imovel Icad = new Imovel();
            Icad.ShowDialog();
        }

        private void novoContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratoCompra ConCom = new ContratoCompra();
            ConCom.ShowDialog();
        }

        private void novoContratoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ContratoAluguel ConAlu = new ContratoAluguel();
            ConAlu.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCliente consultaCliente = new ConsultaCliente();
            consultaCliente.ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaImovel consultaImovel = new ConsultaImovel();
            consultaImovel.ShowDialog();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteraCliente alteraCliente = new AlteraCliente();
            alteraCliente.ShowDialog();
        }

        private void alterarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlteraImovel alteraImovel = new AlteraImovel();
            alteraImovel.ShowDialog();
        }

        private void consultarContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelataClientes relataClientess = new RelataClientes();
            relataClientess.ShowDialog();
        }

        private void imóveisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelataImoveis relataImoveis = new RelataImoveis();
            relataImoveis.ShowDialog();
        }

        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelataContratos relataContratos = new RelataContratos();
            relataContratos.ShowDialog();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
