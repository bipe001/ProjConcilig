using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjConcilig.Model;

namespace ProjConcilig
{
    public partial class Principal : Form
    {
        DataTable dt;
        DataTable dtConsulta;
        string _user;
        string _nomeUsuario;

        public Principal(string user)
        {
            InitializeComponent();
            _user = user;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dtConsulta = new DataTable();
            _nomeUsuario = BuscaNome(_user);

            CarregarDados();

        }


        private void CarregarDados() //Busca no Banco e alimenta o Datasource para importar no Grid
        {
            string query = "SELECT Nome, CPF, Contrato, Produto, Vencimento, Valor, [Nome Arquivo], [Usuario Importacao] FROM clientes";

            using (SqlConnection conn = new SqlConnection(Global.connectionString))
            {
                gridImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dt.Clear(); // Limpa os dados antigos
                adapter.Fill(dt);
                gridImport.DataSource = dt; // Exibe os dados no DataGridView
            }
        }


        private void btnImportCSV_Click(object sender, EventArgs e) //Botão importa o CSV
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Selecione o arquivo CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                // Valida o nome do arquivo antes de importar
                bool ValidarNomeArquivo = ValidaNomeArquivo(fileName);

                if (!ValidarNomeArquivo)
                {
                    // Valida o layout antes de importar
                    if (ValidarLayoutCSV(filePath))
                    {
                        bool RetornoImport = ImportarCSV(filePath, fileName, _nomeUsuario);
                        if (RetornoImport == true)
                            MessageBox.Show("Arquivo importado.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show("Erro.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                            CarregarDados();
                    }
                    else
                    {
                        MessageBox.Show("O layout do CSV está incorreto. Certifique-se de que contém as colunas: Nome, CPF, Contrato, Produto, Vencimento e Valor.","ATENÇÃO!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("CSV já importado!","ATENÇÃO!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidarLayoutCSV(string filePath)
        {
            string[] colunasEsperadas = { "Nome", "CPF", "Contrato", "Produto", "Vencimento", "Valor" };

            using (var reader = new StreamReader(filePath))
            {
                string primeiraLinha = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(primeiraLinha))
                    return false;

                // Divide a linha e remove espaços extras e entradas vazias
                string[] colunasCSV = primeiraLinha.Split(';')
                                                   .Select(coluna => coluna.Trim()) // Remove espaços extras
                                                   .Where(coluna => !string.IsNullOrEmpty(coluna)) // Remove colunas vazias
                                                   .ToArray();

                return colunasEsperadas.SequenceEqual(colunasCSV);
            }
        }



        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            if (!string.IsNullOrEmpty(filtro))
            {
                dt.DefaultView.RowFilter = $"Nome LIKE '%{filtro}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = string.Empty; // Remove filtro quando o campo está vazio
            }
        }

        private bool ImportarCSV(string filePath, string nomeArquivo, string username)
        {
            // Define a string de conexão com o banco de dados SQL Server
            Encoding encodingBrasil = Encoding.GetEncoding("iso-8859-1");

            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("iso-8859-1")))
            {
                // Lê a primeira linha do arquivo CSV (cabeçalho) e ignora
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    // Lê cada linha do arquivo CSV e divide os valores usando o delimitador ";"
                    string linha = reader.ReadLine();
                    string[] valores = linha.Split(';');
                    string query = "INSERT INTO Clientes (Nome, CPF, Contrato, Produto, Vencimento, Valor, [Nome Arquivo], [Usuario Importacao]) " +
                        "VALUES (@Nome, @CPF, @Contrato, @Produto, @Vencimento,  @Valor, @NomeArquivo, @UsuarioImportacao)";

                    // Cria uma conexão com o banco de dados e executa o comando SQL para adicionar as informações na tabela
                    using (SqlConnection connection = new SqlConnection(Global.connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", valores[0]);
                            command.Parameters.AddWithValue("@CPF", valores[1]);
                            command.Parameters.AddWithValue("@Contrato", valores[2]);
                            command.Parameters.AddWithValue("@Produto", valores[3]);
                            command.Parameters.AddWithValue("@Vencimento", Convert.ToDateTime(valores[4]).ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@Valor", Convert.ToDecimal(valores[5]));
                            command.Parameters.AddWithValue("@NomeArquivo", nomeArquivo);
                            command.Parameters.AddWithValue("@UsuarioImportacao", username);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }  
                }
                return true;
            }
        }

        private string BuscaNome(string username) //Busca o nome de acordo com o Username cadastrado
        {
            string query = "select top 1 nome from Usuarios where Username = @username";

            using (SqlConnection conn = new SqlConnection(Global.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    conn.Open();

                    string userCount = (string)command.ExecuteScalar();
                    return userCount;

                }
            }
        }

        private void CarregaConsulta() //Carrega o Grida da tela Consulta, na telaPrincipal
        {
            dtConsulta = new DataTable();
            

            string query = "SELECT DISTINCT\r\n    Nome,\r\n    CPF,\r\n    SUM(CAST(Valor AS DECIMAL(18,2))) AS TotalContrato,\r\n    MAX(DATEDIFF(DAY, Vencimento, GETDATE())) AS MaiorDiasAtraso\r\nFROM Clientes\r\nWHERE TRY_CAST(Vencimento AS DATE) IS NOT NULL AND Valor IS NOT NULL\r\nGROUP BY Nome, CPF\r\nORDER BY Nome;\r\n";

            using (SqlConnection conn = new SqlConnection(Global.connectionString))
            {
                gridConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dtConsulta.Clear(); // Limpa os dados antigos
                adapter.Fill(dtConsulta);
                gridConsulta.DataSource = dtConsulta; // Exibe os dados no DataGridView
            }

        }

        private void tabControlPrincipal_Click(object sender, EventArgs e)
        {
            if (tabControlPrincipal.SelectedTab == tabConsulta)
            {
                CarregaConsulta();
            }   
        }

        private bool ValidaNomeArquivo(string nomeArquivo) //Valida o nome do arquivo para que não ocorra duplicados
        {
            string query = "SELECT COUNT(*) FROM Clientes WHERE [Nome Arquivo] = @nomeArquivo";

            using (SqlConnection connection = new SqlConnection(Global.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nomeArquivo", nomeArquivo);

                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void txtFiltroConsulta_TextChanged(object sender, EventArgs e) //Filtro da tela Consulta
        {
            string filtro = txtFiltroConsulta.Text.Trim();
            if (!string.IsNullOrEmpty(filtro))
            {
                dtConsulta.DefaultView.RowFilter = $"Nome LIKE '%{filtro}%'";
            }
            else
            {
                dtConsulta.DefaultView.RowFilter = string.Empty; ; // Remove filtro quando o campo está vazio
            }
        }
    }
}
