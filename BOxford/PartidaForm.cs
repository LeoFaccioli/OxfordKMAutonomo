using KingMeServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOxford
{
    public partial class PartidaForm : Form
    {
        public PartidaForm()
        {
            InitializeComponent();
        }

        private void btnVoltarLobby_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPosicionarPersonagem_Click(object sender, EventArgs e)
        {
            string estadoAtual = Jogo.ColocarPersonagem(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text,
                Convert.ToInt32(txtPersonagemSetor.Text), txtPersonagemSelecionado.Text);

        }

        private void btnVerificarVez_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            string erroIniciar = Jogo.Iniciar(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text);
            if (erroIniciar.StartsWith("ERRO:"))
            {
                lblErro.Text = erroIniciar;
            }
            else
            {
                lblErro.Text = "";
            }
        }
    }
}
