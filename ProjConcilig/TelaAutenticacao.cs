using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjConcilig
{
    public partial class TelaAutenticacao : Form
    {
        public TelaAutenticacao()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TelaLogin login = new TelaLogin();
            this.Hide();
            login.Show();
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            TelaCriacaoUsuario criarUsuario = new TelaCriacaoUsuario();
            criarUsuario.Show();
        }
    }
}
