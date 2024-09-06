using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Trabalho_Final_Prog2
{
    /// <summary>
    /// Formulário que fecha contratos de aluguel, funcionalmente igual aos demais cadastros
    /// </summary>
    public partial class ContratoAluguel : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public ContratoAluguel()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            tbCliente.Clear();
            tbImovel.Clear();
            tbDataFim.Clear();
            tbDataIni.Clear();
        }

        private void btConclui_Click(object sender, EventArgs e)
        {            
            // Cria a instrução SQL para inserir o novo contrato
            string query = "INSERT INTO Contrato (idCliente, idImovel, dataCompra, corretor, dataInicio, dataFim ) VALUES (@idCliente, @idImovel, @dataCompra, @corretor, @dataInicio, @dataFim)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                if ((!tbCliente.Text.Equals("")) && (!tbCorretor.Text.Equals("")) && (!tbDataFim.Text.Equals("")) && (!tbImovel.Text.Equals("")) && (!tbDataIni.Text.Equals("")))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Obtem as informações dos TextBox
                        string corretor = tbCorretor.Text;
                        string dataCompra = "nulo";
                        int idImovel = int.Parse(tbImovel.Text);
                        int idCliente = int.Parse(tbCliente.Text);
                        DateTime dataInicio = DateTime.Parse(tbDataIni.Text);
                        DateTime dataFim = DateTime.Parse(tbDataFim.Text);

                        // Adiciona os parâmetros e tenta executar a instrução
                        command.Parameters.AddWithValue("@idCliente", idCliente);
                        command.Parameters.AddWithValue("@idImovel", idImovel);
                        command.Parameters.AddWithValue("@dataCompra", dataCompra);
                        command.Parameters.AddWithValue("@corretor", corretor);
                        command.Parameters.AddWithValue("@dataInicio", dataInicio);
                        command.Parameters.AddWithValue("@dataFim", dataFim);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Contrato fechado com sucesso!");
                                tbCliente.Clear();
                                tbImovel.Clear();
                                tbDataFim.Clear();
                                tbDataIni.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Falha ao fechar o contrato.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao fechar o contrato: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
        }
    }
}
