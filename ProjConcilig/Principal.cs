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

namespace ProjConcilig
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void Form2_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            string connectionString = "Server=Bipe01;Database=ContratoFuncionarios;Trusted_Connection=True;";
            string query = "SELECT * FROM clientes";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt; // Exibe os dados no DataGridView
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            Form1 ImportCSV = new Form1();
            this.Hide();
            ImportCSV.Show();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            if (!string.IsNullOrEmpty(filtro))
            {
                dt.DefaultView.RowFilter = $"Nome LIKE '%{filtro}%' OR CONVERT(Data, 'System.String') LIKE '%{filtro}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = string.Empty; // Remove filtro quando o campo está vazio
            }
        }
    }
}
