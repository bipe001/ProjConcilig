using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjConcilig
{
    public partial class Principal : Form
    {
        DataTable dt;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            dt = new DataTable();

        }

         //gridImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        private void CarregarDados()
        {
            string connectionString = "Server=Bipe01;Database=ContratoFuncionarios;Trusted_Connection=True;";
            string query = "SELECT nome, CPF, Contrato, Produto, Vencimento, Valor FROM clientes";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dt.Clear(); // Limpa os dados antigos
                adapter.Fill(dt);
                gridImport.DataSource = dt; // Exibe os dados no DataGridView
            }
        }


        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            //Form1 ImportCSV = new Form1();
            //this.Hide();
            //ImportCSV.Show();

            // Cria uma instância do OpenFileDialog pra permitir que o usuário selecione um arquivo CSV
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Selecione o arquivo CSV"
            };
            // Exibe o diálogo e verifica se o usuário selecionou um arquivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportarCSV(filePath);
            }
            Principal principal = new Principal();
            this.Hide();
            principal.Show();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            if (!string.IsNullOrEmpty(filtro))
            {
                dt.DefaultView.RowFilter = $"Nome LIKE '%{filtro}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = string.Empty; // Remove filtro quando o campo está vazio
            }
        }

        private void ImportarCSV(string filePath)
        {
            // Define a string de conexão com o banco de dados SQL Server
            string connectionString = "Server=Bipe01;Database=ContratoFuncionarios;Trusted_Connection=True;";

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Lê a primeira linha do arquivo CSV (cabeçalho) e ignora
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    // Lê cada linha do arquivo CSV e divide os valores usando o delimitador ";"
                    string linha = reader.ReadLine();
                    string[] valores = linha.Split(';');
                    string query = "INSERT INTO Clientes (Nome, CPF, Contrato, Produto, Vencimento, Valor) VALUES (@Nome, @CPF, @Contrato, @Produto, @Vencimento, @Valor)";

                    // Cria uma conexão com o banco de dados e executa o comando SQL para adicionar as informações na tabela
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", valores[0]);
                            command.Parameters.AddWithValue("@CPF", valores[1]);
                            command.Parameters.AddWithValue("@Contrato", valores[2]);
                            command.Parameters.AddWithValue("@Produto", valores[3]);
                            command.Parameters.AddWithValue("@Vencimento", valores[4]);
                            command.Parameters.AddWithValue("@Valor", valores[5]);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
