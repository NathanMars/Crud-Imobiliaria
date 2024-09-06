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

namespace Trabalho_Final_Prog2
{
    /// <summary>
    /// Formulário de cadastro de imóveis
    /// </summary>
    /// <remarks>
    /// Cadastrar instere dados do banco, Limpar limpa as textboxes, Fechar fecha o formulario
    /// </remarks>
    public partial class Imovel : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public Imovel()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            // Cria a instrução SQL para inserir o novo imovel
            string query = "INSERT INTO Imovel (tipo, valorVenda, valorAluguel, endereco, nQuartos, nBanheiros, vagasGaragem) VALUES (@tipo, @valorVenda, @valorAluguel, @endereco, @nQuartos, @nBanheiros, @vagasGaragem)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                if ((!tbTipo.Text.Equals("")) && (!tbEndereco.Text.Equals("")) && (!tbValVenda.Text.Equals("")) && (!tbValAluguel.Text.Equals("")) && (!tbQuartos.Text.Equals("")) && (!tbBanheiros.Text.Equals("")) && (!tbGaragem.Text.Equals("")))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Obtem as informações dos TextBox
                        string tipo = tbTipo.Text;
                        string endereco = tbEndereco.Text;
                        double valorVenda = double.Parse(tbValVenda.Text);
                        double valorAluguel = double.Parse(tbValAluguel.Text);
                        int nQuartos = int.Parse(tbQuartos.Text);
                        int nBanheiros = int.Parse(tbBanheiros.Text);
                        int vagasGaragem = int.Parse(tbGaragem.Text);

                        // Adiciona os parâmetros
                        command.Parameters.AddWithValue("@tipo", tipo);
                        command.Parameters.AddWithValue("@valorVenda", valorVenda);
                        command.Parameters.AddWithValue("@valorAluguel", valorAluguel);
                        command.Parameters.AddWithValue("@nQuartos", nQuartos);
                        command.Parameters.AddWithValue("@nBanheiros", nBanheiros);
                        command.Parameters.AddWithValue("@endereco", endereco);
                        command.Parameters.AddWithValue("@vagasGaragem", vagasGaragem);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Imóvel cadastrado com sucesso!");
                                tbGaragem.Clear();
                                tbBanheiros.Clear();
                                tbQuartos.Clear();
                                tbTipo.Clear();
                                tbEndereco.Clear();
                                tbValAluguel.Clear();
                                tbValVenda.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Falha ao cadastrar o imóvel.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao cadastrar o imóvel: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            tbGaragem.Clear();
            tbBanheiros.Clear();
            tbQuartos.Clear();
            tbTipo.Clear();
            tbEndereco.Clear();
            tbValAluguel.Clear();
            tbValVenda.Clear();

        }
    }
}
