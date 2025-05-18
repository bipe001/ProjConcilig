﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjConcilig.Model;

namespace ProjConcilig
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) //Botão Login que chama o método Autentica usuario
        {
            bool validado = ValidaCampos();
            if (validado)
            {
                AutenticaUsuario(txtUsername.Text, txtPassword.Text);
                
            }
        }



        private bool ValidaCampos() //Valida se os campos não estão vazios
        {
            if (string.IsNullOrEmpty(txtUsername.Text)
                || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return false;
            }
            else
                return true;
        }

        private void AutenticaUsuario(string username, string password) //Autentica se existe o usuário no banco de dados
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Username = @username AND Password = @password";

            using (SqlConnection connection = new SqlConnection(Global.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);

                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        Principal principal = new Principal(username);
                        this.Hide();
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos.");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) //Botão cancel, fecha a janela
        {
            TelaAutenticacao telaAutenticacao = new TelaAutenticacao();
            this.Close();
            telaAutenticacao.Show();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) //Método para ativar o btnLogin quando ENTER for pressionado
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
}
