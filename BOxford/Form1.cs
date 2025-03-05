using KingMeServer;

namespace BOxford
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Mostrar versão na tela
            lblVersao.Text = lblVersao.Text + " " + Jogo.versao;

            //Opções de filtro
            cboFiltro.Items.Add("Todas");
            cboFiltro.Items.Add("Aberta");
            cboFiltro.Items.Add("Jogando");
            cboFiltro.Items.Add("Encerrada");
            cboFiltro.SelectedIndex = 0;
        }



        //Listar partidas
        private void btnListarPartidas_Click(object sender, EventArgs e)
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

            string ID = Jogo.CriarPartida(txtNomePartida.Text, txtSenhaPartida.Text, txtSenhaPartida.Text);
            lblIDatual.Text = "ID da partida: " + ID;
        }


        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dividir os itens
            string dadosPartidaTotal = lstPartidas.SelectedItem.ToString();
            string[] dadosPartida = dadosPartidaTotal.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string data = dadosPartida[2];

            lblDadosID.Text = "ID: " + idPartida.ToString();
            lblDadosPartida.Text = "Nome da partida: " + nomePartida;
            lblDadosData.Text = "Data: " + data;

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



        private void lstJogadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






    }
}





