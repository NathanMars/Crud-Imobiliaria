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
    /// Formulário de cadastro de clientes
    /// </summary>
    /// <remarks>
    /// Cadastrar instere dados do banco, Limpar limpa as textboxes, Fechar fecha o formulario
    /// </remarks>
    public partial class Cliente : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImobiliariaDB;Integrated Security=True;";

        public Cliente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            
            // Cria a instrução SQL para inserir as informações no novo cliente
            string query = "INSERT INTO Cliente (nome, email, idade, telefone, cpf, estadoCivil) VALUES (@nome, @email, @idade, @telefone, @cpf, @estadoCivil)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                if ((!tbNome.Text.Equals("")) && (!tbCPF.Text.Equals("")) && (!tbEmail.Text.Equals("")) && (!tbTelefone.Text.Equals("")) && (!tbEstCivil.Text.Equals("")) && (!tbIdade.Text.Equals("")))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Obtem as informações dos TextBox
                        string nome = tbNome.Text;
                        string email = tbEmail.Text;
                        string cpf = tbCPF.Text;
                        int idade = int.Parse(tbIdade.Text);
                        string estadoCivil = tbEstCivil.Text;
                        string telefone = tbTelefone.Text;

                        // Adiciona os parâmetros e executa a "query" (não é exatamente uma query por não ter retorno, por isso o Non em ExecuteNonQuery, o comando executa a instrução SQL)
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@idade", idade);
                        command.Parameters.AddWithValue("@telefone", telefone);
                        command.Parameters.AddWithValue("@cpf", cpf);
                        command.Parameters.AddWithValue("@estadoCivil", estadoCivil);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cliente cadastrado com sucesso!");
                                tbCPF.Clear();
                                tbEmail.Clear();
                                tbTelefone.Clear();
                                tbNome.Clear();
                                tbIdade.Clear();
                                tbEstCivil.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Falha ao cadastrar o cliente.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao cadastrar o cliente: " + ex.Message);
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
            tbCPF.Clear();
            tbEmail.Clear();
            tbTelefone.Clear();
            tbNome.Clear();
            tbIdade.Clear();
            tbEstCivil.Clear();

        }
    }
}
