using KingMeServer;
using Microsoft.Data.SqlClient;

namespace BOxford
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();

            // Mostrar versão na tela
            lblVersao.Text = lblVersao.Text + " " + Jogo.versao;

            //Opções de filtro
            cboFiltro.Items.Add("Todas");
            cboFiltro.Items.Add("Aberta");
            cboFiltro.Items.Add("Jogando");
            cboFiltro.Items.Add("Encerradas");
            cboFiltro.SelectedIndex = 0;
        }

        //Listar partidas
        public void btnListarPartidas_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas(cboFiltro.Text.Substring(0, 1));
            retorno = retorno.Replace("\r", "");

            retorno = retorno.Substring(0, retorno.Length - 1);

            string[] partidas = retorno.Split('\n');

            lstPartidas.Items.Clear();
            for (int i = 0; i < partidas.Length; i++)
            {

                lstPartidas.Items.Add(partidas[i]);

            }

        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            // Criar partida
            string id = Jogo.CriarPartida(txtNomePartida.Text, txtSenhaPartida.Text, txtNomeGrupo.Text);
            txtIDpartida.Text = id;

        }

        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dividir os itens
            string dadosPartidaTotal = lstPartidas.SelectedItem.ToString();
            string[] dadosPartida = dadosPartidaTotal.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string dataPartida = dadosPartida[2];

            lblDadosID.Text = $"ID: {idPartida}";
            lblDadosPartida.Text = $"Nome da partida: {nomePartida}";
            lblDadosData.Text = $"Data: {dataPartida}";

            //Listar jogadores:
            string retorno = Jogo.ListarJogadores(idPartida);
            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');

            lstJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                lstJogadores.Items.Add(jogadores[i]);
            }

        }

        //Entrar na partida:
        public void btnEntrarPartida_Click(object sender, EventArgs e)
        {

            string retorno = Jogo.Entrar(Convert.ToInt32(txtIDpartida.Text), txtNomeJogador.Text, txtSenhaPartida.Text);

            if (retorno.StartsWith("ERRO:"))
            {
                lblerro.Text = retorno;
            }
            else
            {
                lblerro.Text = "";

                string[] idsenha = retorno.Split(',');

                if (idsenha.Length == 2)
                {
                    string idjogador = idsenha[0];
                    string senhajogador = idsenha[1];

                    lblIdJogador.Text = idjogador;
                    lblSenhaJogador.Text = senhajogador;

                    txtIDjogador.Text = idjogador;
                    txtSenha.Text = senhajogador;

                }

                else if (idsenha.Length == 1)
                {
                    string idjogador = idsenha[0];

                }



            }

        }

        // Iniciar partida
        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            string erroIniciar = Jogo.Iniciar(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text);
            lblerro.Text = erroIniciar;

        }

        //Exibir cartas
        private void btnExibirCartas_Click(object sender, EventArgs e)
        {
            Dictionary<char, string> mapaCartas = new Dictionary<char, string>()
            {
                {'A', "Adilson"},
                {'B', "Beatriz"},
                {'C', "Claro"},
                {'D', "Douglas"},
                {'E', "Eduardo"},
                {'G', "Guilherme"},
                {'H', "Heredia"},
                {'K', "Karin"},
                {'L', "Leonardo"},
                {'M', "Marios"},
                {'Q', "Quintas"},
                {'R', "Ranulfo"},
                {'T', "Toshio"}
            };

            string retorno = Jogo.ListarCartas(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text);

            List<string> nomesConvertidos = new List<string>();

            foreach (char inicial in retorno) 
            {
                if (mapaCartas.ContainsKey(inicial))
                {
                    nomesConvertidos.Add(mapaCartas[inicial]); 
                }
            }

            lblCartas.Text = "Minhas cartas:\n" + string.Join("\n", nomesConvertidos);

        }
    }
}






