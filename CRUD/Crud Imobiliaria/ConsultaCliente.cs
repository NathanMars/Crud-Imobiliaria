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
    /// Formulário de visualização de clientes
    /// </summary>
    /// <remarks>
    /// Consultar recupera dados do banco, "Nova Consulta" limpa as textboxes, Fechar fecha o formulario
    /// </remarks>
    public partial class ConsultaCliente : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public ConsultaCliente()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {

            // Obtem o ID do cliente a ser consultado
            int idCliente;
            if (!int.TryParse(tbBusca.Text, out idCliente)) //confere se o valor inserido pode ser convertido para int
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }

            // Cria a instrução SQL para buscar os dados do cliente
            string query = "SELECT * FROM Cliente WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona o parâmetro e executa a "query"
                    command.Parameters.AddWithValue("@ID", idCliente);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Se houver resultados, preenche os TextBoxes
                            tbNome.Text = reader["nome"].ToString();
                            tbEmail.Text = reader["email"].ToString();
                            tbTelefone.Text = reader["telefone"].ToString();
                            tbCPF.Text = reader["cpf"].ToString();
                            tbEstCivil.Text = reader["estadoCivil"].ToString();
                            tbIdade.Text = reader["idade"].ToString();

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
            tbCPF.Clear();
            tbTelefone.Clear();
            tbEmail.Clear();
            tbIdade.Clear();
            tbEstCivil.Clear();
            tbNome.Clear();
        }
    }
}
