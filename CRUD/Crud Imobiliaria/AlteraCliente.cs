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
    /// Formulário de edição de clientes
    /// </summary>
    /// <remarks>
    /// "Buscar" recupera dados do banco, "Buscar Outro Cliente limpa as textboxes, "Alterar" e "Excluir" se referem respectivamente aos comandos UPDATE e DELETE, Fechar fecha o formulario
    /// </remarks>
    public partial class AlteraCliente : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public AlteraCliente()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBusca_Click(object sender, EventArgs e)
        {
            // Obtem o ID do cliente a ser consultado
            int idCliente;
            if (!int.TryParse(tbAltera.Text, out idCliente)) //confere se o valor inserivel pode ser convertido para int
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }

            tbCPF.ReadOnly = false;
            tbNome.ReadOnly = false;
            tbEmail.ReadOnly = false;
            tbTelefone.ReadOnly = false;
            tbEstCivil.ReadOnly = false;
            tbIdade.ReadOnly = false;

            // Cria a instrução SQL para buscar os dados do cliente
            string query = "SELECT * FROM Cliente WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona o parâmetro, mecanicamente igual a função de busca
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

        private void btBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            // Obtém o ID do cliente, evita erros caso o usuario tente alterar sem ter buscado por um id
            int idCliente;
            if (!int.TryParse(tbAltera.Text, out idCliente))
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }
            string novoNome = tbNome.Text;
            string novoEmail = tbEmail.Text;
            string novoCpf = tbCPF.Text;
            int novaIdade = int.Parse(tbIdade.Text);
            string novoEstadoCivil = tbEstCivil.Text;
            string novoTelefone = tbTelefone.Text;

            // Cria a instrução SQL para atualizar os dados do cliente
            string query = "UPDATE Cliente SET nome = @novoNome, email = @novoEmail, cpf = @novoCpf, idade = @novaIdade, estadoCivil = @novoEstadoCivil, telefone = @novoTelefone WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona os parâmetros e tenta executar a "query"
                    command.Parameters.AddWithValue("@ID", idCliente);
                    command.Parameters.AddWithValue("@novoNome", novoNome);
                    command.Parameters.AddWithValue("@novoEmail", novoEmail);
                    command.Parameters.AddWithValue("@novoCpf", novoCpf);
                    command.Parameters.AddWithValue("@novoTelefone", novoTelefone);
                    command.Parameters.AddWithValue("@novaIdade", novaIdade);
                    command.Parameters.AddWithValue("@novoEstadoCivil", novoEstadoCivil);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            
                            MessageBox.Show("Dados do cliente atualizados com sucesso!");
                            // Limpa os campos e define como somente leitura após a alteração
                            tbAltera.Clear();
                            tbCPF.Clear();
                            tbTelefone.Clear();
                            tbEmail.Clear();
                            tbIdade.Clear();
                            tbEstCivil.Clear();
                            tbNome.Clear();

                            tbCPF.ReadOnly = true;
                            tbNome.ReadOnly = true;
                            tbEmail.ReadOnly = true;
                            tbTelefone.ReadOnly = true;
                            tbEstCivil.ReadOnly = true;
                            tbIdade.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Nenhum cliente foi encontrado com o ID fornecido.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar os dados do cliente: " + ex.Message);
                    }
                }
            }
            }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            tbAltera.Clear();
            tbCPF.Clear();
            tbTelefone.Clear();
            tbEmail.Clear();
            tbIdade.Clear();
            tbEstCivil.Clear();
            tbNome.Clear();

            tbCPF.ReadOnly = true;
            tbNome.ReadOnly = true;
            tbEmail.ReadOnly = true;
            tbTelefone.ReadOnly = true;
            tbEstCivil.ReadOnly = true;
            tbIdade.ReadOnly = true;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {          
                // Obtém o ID do cliente a ser excluído
                int idCliente;
                if (!int.TryParse(tbAltera.Text, out idCliente))
                {
                    MessageBox.Show("Por favor, insira um ID válido.");
                    return;
                }

                try
                {
                    // Antes de excluir o cliente, verifica se existem contratos associados
                    if (ContratosAssociados(idCliente))
                    {
                        MessageBox.Show("Não é possível excluir o cliente porque existem contratos associados.");
                    }
                    else
                    {
                        // Continua  a exclusão do cliente
                        ExcluirCliente(idCliente);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir o cliente: " + ex.Message);
                }
            }

        private bool ContratosAssociados(int idCliente)
        {
            string query = "SELECT COUNT(*) FROM Contrato WHERE idCliente = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", idCliente);

                    try
                    {
                        connection.Open();
                        int numberOfContracts = (int)command.ExecuteScalar();
                        return numberOfContracts > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao verificar contratos associados: " + ex.Message);
                        return false;
                    }
                }
            }
        }

            private void ExcluirCliente(int idCliente)
            {
            // Cria a instrução SQL para excluir o cliente
            string query = "DELETE FROM Cliente WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona o parâmetro do ID
                    command.Parameters.AddWithValue("@ID", idCliente);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente excluído com sucesso!");

                            // Limpa os campos e define como somente leitura após a exclusão
                            tbAltera.Clear();
                            tbCPF.Clear();
                            tbTelefone.Clear();
                            tbEmail.Clear();
                            tbIdade.Clear();
                            tbEstCivil.Clear();
                            tbNome.Clear();

                            tbCPF.ReadOnly = true;
                            tbNome.ReadOnly = true;
                            tbEmail.ReadOnly = true;
                            tbTelefone.ReadOnly = true;
                            tbEstCivil.ReadOnly = true;
                            tbIdade.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Nenhum cliente foi encontrado com o ID fornecido.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir o cliente: " + ex.Message);
                    }
                }
            }
        }            
            }

        }
