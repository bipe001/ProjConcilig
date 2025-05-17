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
    public partial class TelaCriacaoUsuario : Form
    {
        public TelaCriacaoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool retornoCampo = ValidaCampos();


            if (retornoCampo)
            {
                AutenticaUsuario(txtbNome.Text, txtbUsuario.Text, txtbSenha.Text);
            }
            else
            {

            }
        }


        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(txtbNome.Text)
                || string.IsNullOrEmpty(txtbUsuario.Text)
                || string.IsNullOrEmpty(txtbSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return false;
            }
            else
                return true;
        }


        private void AutenticaUsuario(string nome, string username, string password)
        {
            string connectionString = "Server=Bipe01;Database=ContratoFuncionarios;Trusted_Connection=True;";
            string query = "INSERT INTO Usuarios (nome, username, password) VALUES (@nome, @username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", txtbNome.Text);
                    command.Parameters.AddWithValue("@username", txtbUsuario.Text);
                    command.Parameters.AddWithValue("@password", txtbSenha.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Usuário criado com sucesso!");
            this.Close();

        }

    }
}
