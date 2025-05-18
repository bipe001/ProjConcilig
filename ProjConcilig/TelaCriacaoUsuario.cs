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
using ProjConcilig.Model;

namespace ProjConcilig
{
    public partial class TelaCriacaoUsuario : Form
    {
        public TelaCriacaoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e) //Botão para criar o usuário caso ele passe pelo método de Validar usuário existente
        {
            bool retornoCampo = ValidaCampos();


            if (retornoCampo)
            {
                bool usuarioValidado = ValidaUsuarioExistente(txtbUsuario.Text);

                if (!usuarioValidado)
                    CriarUsuario(txtbNome.Text, txtbUsuario.Text, txtbSenha.Text);
                else
                {
                    MessageBox.Show("Usuário já existe!");
                    txtbUsuario.Clear();
                }
            }
            else
            {

            }
        }


        private bool ValidaCampos() //Validar se os campos estão vazios ou não
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


        private void CriarUsuario(string nome, string username, string password) //Método para criar o usuário no banco
        {
            string query = "INSERT INTO Usuarios (nome, username, password) VALUES (@nome, @username, @password)";

            using (SqlConnection connection = new SqlConnection(Global.connectionString))
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

        private bool ValidaUsuarioExistente(string username) //Validar se o usuário que está sendo criado já existe.
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Username = @username";

            using (SqlConnection connection = new SqlConnection(Global.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

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
    }
}
