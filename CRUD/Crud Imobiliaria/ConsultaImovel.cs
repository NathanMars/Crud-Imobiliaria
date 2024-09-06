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
    /// Formulário de visualização de imóveis
    /// </summary>
    /// <remarks>
    /// Consultar recupera dados do banco, "Nova Consulta" limpa as textboxes, Fechar fecha o formulario
    /// </remarks>
    public partial class ConsultaImovel : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public ConsultaImovel()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            // Obtem o ID do imovel a ser consultado
            int idImovel;
            if (!int.TryParse(tbBusca.Text, out idImovel)) //confere se o valor inserido pode ser convertido para int
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }

            // Cria a instrução SQL para buscar os dados do imovel
            string query = "SELECT * FROM Imovel WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona o parâmetro
                    command.Parameters.AddWithValue("@ID", idImovel);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Se houver resultados, preenche os TextBoxes
                            tbEndereco.Text = reader["endereco"].ToString();
                            tbTipo.Text = reader["tipo"].ToString();
                            tbValVenda.Text = reader["valorVenda"].ToString();
                            tbValAluguel.Text = reader["valorAluguel"].ToString();
                            tbGaragem.Text = reader["vagasGaragem"].ToString();
                            tbQuartos.Text = reader["nQuartos"].ToString();
                            tbBanheiros.Text = reader["nBanheiros"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado.");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar dados do cliente: " + ex.Message);
                    }
                }
            }
            }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            tbBusca.Clear();
            tbEndereco.Clear();
            tbTipo.Clear();
            tbQuartos.Clear();
            tbBanheiros.Clear();
            tbGaragem.Clear();   
            tbValAluguel.Clear();
            tbValVenda.Clear();
        }
    }
}
