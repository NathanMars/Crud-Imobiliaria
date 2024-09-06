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
    /// Formulário de edição de imóveis
    /// </summary>
    /// <remarks>
    /// "Buscar" recupera dados do banco, "Buscar Outro Imóvel" limpa as textboxes, "Alterar" e "Excluir" se referem respectivamente aos comandos UPDATE e DELETE, Fechar fecha o formulario
    /// </remarks>
    public partial class AlteraImovel : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public AlteraImovel()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBusca_Click(object sender, EventArgs e)
        {
            // Obtem o ID do imovel a ser consultado
            int idImovel;
            if (!int.TryParse(tbAltera.Text, out idImovel)) //confere se o valor inserivel pode ser convertido para int
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }

            tbQuartos.ReadOnly = false;
            tbGaragem.ReadOnly = false;
            tbEndereco.ReadOnly = false;
            tbBanheiros.ReadOnly = false;
            tbTipo.ReadOnly = false;
            tbValAluguel.ReadOnly = false;
            tbValVenda.ReadOnly = false;


            // Cria a instrução SQL para buscar os dados do imovel
            string query = "SELECT * FROM Imovel WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona o parâmetro, funcionalmente igual a função de busca
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
                            MessageBox.Show("Imóvel não encontrado.");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar dados do imóvel: " + ex.Message);
                    }
                }
            }

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            // Obtém o ID do imovel, evita erros caso o usuario tente alterar sem ter buscado por um id
            int idImovel;
            if (!int.TryParse(tbAltera.Text, out idImovel))
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }
            string novoTipo = tbTipo.Text;
            string novoEndereco = tbEndereco.Text;
            int novoVagasGaragem = int.Parse(tbGaragem.Text);
            int novonQuartos = int.Parse(tbQuartos.Text);
            int novonBanheiros = int.Parse(tbBanheiros.Text);
            double novoValorVenda = double.Parse(tbValVenda.Text);
            double novoValorAluguel = double.Parse(tbValAluguel.Text);

            // Cria a instrução SQL para atualizar os dados do imovel
            string query = "UPDATE Imovel SET tipo = @novoTipo, endereco = @novoEndereco, vagasGaragem = @novoVagasGaragem, nQuartos = @novonQuartos, nBanheiros = @novonBanheiros, valorVenda = @novoValorVenda, valorAluguel = @novoValorAluguel WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona os parâmetros
                    command.Parameters.AddWithValue("@ID", idImovel);
                    command.Parameters.AddWithValue("@novoTipo", novoTipo);
                    command.Parameters.AddWithValue("@novoEndereco", novoEndereco);
                    command.Parameters.AddWithValue("@novoVagasGaragem", novoVagasGaragem);
                    command.Parameters.AddWithValue("@novonQuartos", novonQuartos);
                    command.Parameters.AddWithValue("@novonBanheiros", novonBanheiros);
                    command.Parameters.AddWithValue("@novoValorVenda", novoValorVenda);
                    command.Parameters.AddWithValue("@novoValorAluguel", novoValorAluguel);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dados do imóvel atualizados com sucesso!");
                            tbQuartos.ReadOnly = true;
                            tbGaragem.ReadOnly = true;
                            tbEndereco.ReadOnly = true;
                            tbBanheiros.ReadOnly = true;
                            tbTipo.ReadOnly = true;
                            tbValAluguel.ReadOnly = true;
                            tbValVenda.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Nenhum imóvel foi encontrado com o ID fornecido.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar os dados do imóvel: " + ex.Message);
                    }
                }
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            tbAltera.Clear();
            tbEndereco.Clear();
            tbTipo.Clear();
            tbQuartos.Clear();
            tbBanheiros.Clear();
            tbGaragem.Clear();
            tbValAluguel.Clear();
            tbValVenda.Clear();

            tbQuartos.ReadOnly = true;
            tbGaragem.ReadOnly = true;
            tbEndereco.ReadOnly = true;
            tbBanheiros.ReadOnly = true;
            tbTipo.ReadOnly = true;
            tbValAluguel.ReadOnly = true;
            tbValVenda.ReadOnly = true;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            // Obtém o ID do imóvel a ser excluído
            int idImovel;
            if (!int.TryParse(tbAltera.Text, out idImovel))
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }

            try
            {
                // Antes de excluir o imóvel, verifica se existem contratos associados
                if (ContratosAssociados(idImovel))
                {
                    MessageBox.Show("Não é possível excluir o imóvel porque existem contratos associados.");
                }
                else
                {
                    // Continua  a exclusão do imóvel
                    ExcluirImovel(idImovel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o imóvel: " + ex.Message);
            }
        }
        private bool ContratosAssociados(int idImovel)
        {
            string query = "SELECT COUNT(*) FROM Contrato WHERE idImovel = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", idImovel);

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

        private void ExcluirImovel(int idImovel)
        {
            // Cria a instrução SQL para excluir o imóvel
            string query = "DELETE FROM Imovel WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona o parâmetro do ID
                    command.Parameters.AddWithValue("@ID", idImovel);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Imóvel excluído com sucesso!");

                            // Limpa os campos e define como somente leitura após a exclusão
                            tbAltera.Clear();
                            tbEndereco.Clear();
                            tbTipo.Clear();
                            tbQuartos.Clear();
                            tbBanheiros.Clear();
                            tbGaragem.Clear();
                            tbValAluguel.Clear();
                            tbValVenda.Clear();

                            tbQuartos.ReadOnly = true;
                            tbGaragem.ReadOnly = true;
                            tbEndereco.ReadOnly = true;
                            tbBanheiros.ReadOnly = true;
                            tbTipo.ReadOnly = true;
                            tbValAluguel.ReadOnly = true;
                            tbValVenda.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Nenhum imóvel foi encontrado com o ID fornecido.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir o imóvel: " + ex.Message);
                    }
                }
            }
        }
    }
}