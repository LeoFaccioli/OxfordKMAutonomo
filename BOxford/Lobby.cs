using KingMeServer;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Web;

namespace BOxford
{
    public partial class Lobby : Form
    {

        //
        // Exibindo graficamente --------------------------------------------------------------------
        //

        //Atribuindo a letra para uma imagem
        private Dictionary<string, Image> imagensCartas = new Dictionary<string, Image>();
        private void CarregarImagensCartas()
        {
            imagensCartas["A"] = Properties.Resources.CartaA;
            imagensCartas["B"] = Properties.Resources.CartaB;
            imagensCartas["C"] = Properties.Resources.CartaC;
            imagensCartas["D"] = Properties.Resources.CartaD;
            imagensCartas["E"] = Properties.Resources.CartaE;
            imagensCartas["G"] = Properties.Resources.CartaG;
            imagensCartas["H"] = Properties.Resources.CartaH;
            imagensCartas["K"] = Properties.Resources.CartaK;
            imagensCartas["L"] = Properties.Resources.CartaL;
            imagensCartas["M"] = Properties.Resources.CartaM;
            imagensCartas["Q"] = Properties.Resources.CartaQ;
            imagensCartas["R"] = Properties.Resources.CartaR;
            imagensCartas["T"] = Properties.Resources.CartaT;
        }


        public Lobby()
        {
            InitializeComponent();


            // Mostrar vers�o na tela
            lblVersao.Text = lblVersao.Text + " " + Jogo.versao;

            //Mostrar os personagens na tela
            string retorno = Jogo.ListarPersonagens();
            retorno = retorno.Replace("\r", "");
            string[] personagens = retorno.Split('\n');

            lstPersonagens.Items.Clear();
            for (int i = 0; i < personagens.Length; i++)
            {
                lstPersonagens.Items.Add(personagens[i]);
            }

            //Mostrar os setores na tela
            string retorno2 = Jogo.ListarSetores();
            retorno2 = retorno2.Replace("\r", "");
            string[] setores = retorno2.Split('\n');

            lstJogadores.Items.Clear();
            for (int i = 0; i < setores.Length; i++)
            {
                lstSetores.Items.Add(setores[i]);
            }

            //Op��es de filtro
            cboFiltro.Items.Add("Todas");
            cboFiltro.Items.Add("Aberta");
            cboFiltro.Items.Add("Jogando");
            cboFiltro.Items.Add("Encerradas");
            cboFiltro.SelectedIndex = 0;

            CarregarImagensCartas();
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
            if (erroIniciar.StartsWith("ERRO:"))
            {
                lblerro.Text = erroIniciar;
            }
            else
            {
                lblerro.Text = "";
            }
        }

        //Exibir cartas
        private void btnExibirCartas_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarCartas(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text);


            if (retorno.StartsWith("ERRO:"))
            {
                lblerro.Text = retorno;
            }
            else
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
                {'K', "Kelly"},
                {'L', "Leonardo"},
                {'M', "Mario"},
                {'Q', "Quintas"},
                {'R', "Ranulfo"},
                {'T', "Toshio"}
            };



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

        private void btnVerificarVez_Click(object sender, EventArgs e)
        {
            string partida = txtIDpartida.Text;
            int partidaId = Convert.ToInt32(partida);

            // Obt�m o ID do jogador que tem a vez
            string retorno = Jogo.VerificarVez(partidaId).Trim();
            string[] vez = retorno.Split(',');
            string[] linhas = retorno.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            lblIdVez.Text = vez[0]; // ID do jogador que tem a vez

            string estadoTabuleiro = string.Join("\n", linhas.Skip(1));


            // Obt�m a lista de jogadores
            string retorno2 = Jogo.ListarJogadores(partidaId).Trim();
            string[] jogadores = retorno2.Split('\n'); // Divide os jogadores por linha

            // Percorre os jogadores para encontrar o nome do jogador que tem a vez
            foreach (string jogador in jogadores)
            {
                string[] dadosJogador = jogador.Split(','); // Divide ID, Nome e Pontua��o

                if (dadosJogador.Length >= 2 && dadosJogador[0].Trim() == vez[0].Trim())
                {
                    lblNomeVez.Text = dadosJogador[1].Trim(); // Pega o Nome do jogador correspondente
                    break; // Sai do loop assim que encontrar
                }
            }

            AtualizarTabuleiro(estadoTabuleiro);


            // Caso n�o encontre o jogador, mostra um alerta
            if (string.IsNullOrEmpty(lblNomeVez.Text))
            {
                MessageBox.Show("Jogador com ID " + vez[0] + " n�o encontrado.");
            }
        }




        private void btnPosicionarPersonagem_Click(object sender, EventArgs e)
        {
            string estadoAtual = Jogo.ColocarPersonagem(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text,
               Convert.ToInt32(txtPersonagemSetor.Text), txtPersonagemSelecionado.Text);

            AtualizarTabuleiro(estadoAtual);
        }


        private void AtualizarTabuleiro(string estadoTabuleiro)
        {
            string[] linhas = estadoTabuleiro.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            Controls.OfType<PictureBox>().ToList().ForEach(p => Controls.Remove(p));

            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                if (partes.Length != 2) continue;

                int setor = int.Parse(partes[0].Trim());
                string carta = partes[1].Trim();

                PosicionarCarta(setor, carta);
            }

        }

        private void PosicionarCarta(int setor, string carta)
        {
            Dictionary<int, Point> posicoesSetores = new Dictionary<int, Point>
    {
        { 0, new Point(555, 520) },
        { 1, new Point(555, 440) },
        { 2, new Point(555, 360) },
        { 3, new Point(555, 280) },
        { 4, new Point(555, 200) },
        { 5, new Point(555, 120) },
        { 10, new Point(634, 51) }
    };

            // Verifica se o setor existe
            if (!posicoesSetores.ContainsKey(setor))
            {
                Console.WriteLine($"Setor {setor} n�o encontrado no dicion�rio.");
                return;
            }

            // Conta quantas cartas j� est�o no setor
            int cartasNoSetor = Controls.OfType<PictureBox>()
                                        .Count(p => p.Tag != null && (int)p.Tag == setor);

            // Obt�m a imagem da carta usando a fun��o ObterImagemDaCarta
            Image imagem = ObterImagemDaCarta(carta);
            if (imagem == null)
            {
                Console.WriteLine($"Carta '{carta}' n�o encontrada no dicion�rio de imagens.");
                return;
            }

            // Define transpar�ncia na imagem
            Bitmap bitmapImagem = new Bitmap(imagem);
            bitmapImagem.MakeTransparent();

            // Cria a PictureBox da carta
            PictureBox cartaImg = new PictureBox
            {
                Size = new Size(50, 80),
                Location = new Point(
                    posicoesSetores[setor].X + (cartasNoSetor * 55),
                    posicoesSetores[setor].Y
                ),
                BackgroundImage = bitmapImagem,
                BackgroundImageLayout = ImageLayout.Stretch,
                Tag = setor,
                BackColor = Color.Transparent
            };

            // Adiciona ao formul�rio
            Controls.Add(cartaImg);
            cartaImg.BringToFront();

            Console.WriteLine($"Carta '{carta}' posicionada no setor {setor}, posi��o {cartasNoSetor + 1}.");
        }

        private Image ObterImagemDaCarta(string carta)
        {
            return imagensCartas.ContainsKey(carta) ? imagensCartas[carta] : null;
        }




        private void btnNovoLobby_Click(object sender, EventArgs e)
        {
            Form novoFormulario = new Lobby();
            novoFormulario.Show();
        }

        private void btnPromoverPersonagem_Click(object sender, EventArgs e)
        {
            Jogo.Promover(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text, txtPersonagemSelecionado.Text);

            string partida = txtIDpartida.Text;
            int partidaId = Convert.ToInt32(partida);

            // Obt�m o ID do jogador que tem a vez
            string retorno = Jogo.VerificarVez(partidaId).Trim();
            string[] vez = retorno.Split(',');
            string[] linhas = retorno.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            string estadoTabuleiro = string.Join("\n", linhas.Skip(1));

            AtualizarTabuleiro(estadoTabuleiro);
        }

        private (string[] dadosVez, bool partidaIniciada) VerificarVezCompleto()
        {
            try
            {
                string partida = txtIDpartida.Text;
                if (string.IsNullOrEmpty(partida)) return (null, false);

                int partidaId = Convert.ToInt32(partida);
                string retorno = Jogo.VerificarVez(partidaId).Trim();

                if (string.IsNullOrEmpty(retorno)) return (null, false);

                string[] linhas = retorno.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                if (linhas.Length == 0) return (null, false);

                string[] vez = linhas[0].Split(',');

                bool iniciada = vez.Length > 4 && vez[1].Trim().Equals("J");
                return (vez, iniciada);
            }
            catch
            {
                return (null, false);
            }
        }
        private string EstadoAtualTabuleiro()
        {
            string partida = txtIDpartida.Text;
            int partidaId = Convert.ToInt32(partida);

            // Obt�m o ID do jogador que tem a vez
            string retorno = Jogo.VerificarVez(partidaId).Trim();
            string[] vez = retorno.Split(',');
            string[] linhas = retorno.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);


            string estadoTabuleiro = string.Join("\n", linhas.Skip(1));

            return estadoTabuleiro;
        }

        List<string> personagensColocados = new List<string>();

        Dictionary<int, List<string>> setores = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
            { 10, new List<string>()}
        };

        Random random = new Random();

        private bool VerificarCartaNoSetor10()
        {
            if (setores.ContainsKey(10) && setores[10].Count > 0)
            {
                string cartaRei = setores[10][0]; // Pega a primeira carta do setor 10
                lblControle.Text += $"Carta {cartaRei} alcan�ou o KingsMe! Iniciando vota��o...\n";
                return true;
            }
            return false;
        }
        private bool PartidaFoiIniciada()
        {
            try
            {
                string retorno = Jogo.VerificarVez(Convert.ToInt32(txtIDpartida.Text));
                if (retorno.Contains(",J,")) // Verifica se cont�m ",J," (Jogando)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }
        private void tmrVerificaVez_Tick(object sender, EventArgs e)
        {
            tmrVerificaVez.Enabled = false;
            try
            {
                Console.WriteLine("--- In�cio do Tick ---");

                if (!JogadorConectado())
                {
                    Console.WriteLine("Jogador n�o conectado");
                    return;
                }

                var (dadosVez, partidaIniciada) = VerificarVezCompleto();

                if (!partidaIniciada)
                {
                    lblStatus.Text = "Aguardando in�cio da partida...";
                    return;
                }

                lblStatus.Text = "Partida em andamento!";
                SincronizarEstadoTabuleiro();

                if (dadosVez != null && dadosVez.Length >= 4)
                {
                    string idJogadorVez = dadosVez[0];
                    string faseAtual = dadosVez[3].ToUpper();

                    if (idJogadorVez == lblIdJogador.Text)
                    {
                        switch (faseAtual)
                        {
                            case "S":
                                ProcessarSetup();
                                break;
                            case "P":
                                ProcessarPromocao();
                                break;
                            case "V":
                                ProcessarVotacao();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no timer: {ex.Message}");
            }
            finally
            {
                tmrVerificaVez.Enabled = true;
            }
        }
        private void ProcessarSetup()
        {
            string personagem = SortearPersonagemDisponivel();
            if (personagem == null) return;

            int setor = SortearSetorDisponivel();
            if (setor == -1) return;

            PosicionarPersonagem(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text, personagem, setor);
        }

        private void ProcessarPromocao()
        {
            PromoverPersonagens();
        }

        private void ProcessarVotacao()
        {
            if (VerificarCartaNoSetor10())
            {
                VotarAutomaticamente();
            }
        }
        private bool JogadorConectado()
        {
            return !string.IsNullOrEmpty(txtIDjogador.Text) &&
                   !string.IsNullOrEmpty(txtSenha.Text) &&
                   !string.IsNullOrEmpty(txtIDpartida.Text);
        }
        private void VotarAutomaticamente()
        {
            int idJogador = Convert.ToInt32(txtIDjogador.Text);
            string senha = txtSenha.Text;
            string cartaRei = setores[10][0];

            // Estrat�gia 1: Votar sempre Sim (para testes)
            string voto = "S";

            // Estrat�gia 2: Votar aleatoriamente
            // bool voto = random.Next(2) == 0; 

            // Estrat�gia 3: Votar baseado em regras do jogo
            // bool voto = DeveAprovarCarta(cartaRei);

            string resultado = Jogo.Votar(idJogador, senha, voto);

            if (!resultado.StartsWith("ERRO:"))
            {
                lblControle.Text += $"Voto registrado: para {cartaRei}\n";

                if (resultado.Contains("ELEITA"))
                {
                    lblControle.Text += $"{cartaRei} foi eleita Rei!\n";
                    // L�gica adicional p�s-elei��o
                }
            }
            else
            {
                lblControle.Text += $"Erro ao votar: {resultado}\n";
            }
        }

        private void PromoverPersonagens()
        {
            int idJogador = Convert.ToInt32(txtIDjogador.Text);
            string senha = txtSenha.Text;

            // Lista todos os personagens que podem ser promovidos
            var candidatosPromocao = new List<(int setor, string personagem)>();

            for (int setorAtual = 1; setorAtual <= 5; setorAtual++)
            {
                if (!setores.ContainsKey(setorAtual) || setores[setorAtual].Count == 0)
                    continue;

                int proximoSetor = (setorAtual == 5) ? 10 : setorAtual + 1;

                // Verifica se o pr�ximo setor tem espa�o
                bool podePromover = (proximoSetor == 10) ?
                    (!setores.ContainsKey(10) || setores[10].Count < 1) :
                    (!setores.ContainsKey(proximoSetor) || setores[proximoSetor].Count < 4);

                if (podePromover)
                {
                    // Adiciona todos os personagens deste setor como candidatos
                    candidatosPromocao.AddRange(
                        setores[setorAtual].Select(p => (setorAtual, p))
                    );
                }
            }

            if (candidatosPromocao.Count == 0)
            {
                lblControle.Text += "Nenhuma promo��o poss�vel no momento.\n";
                return;
            }

            // Seleciona aleatoriamente um candidato
            var (setorOrigem, personagem) = candidatosPromocao[random.Next(candidatosPromocao.Count)];
            int setorDestino = (setorOrigem == 5) ? 10 : setorOrigem + 1;

            string resultado = Jogo.Promover(idJogador, senha, personagem);

            if (!resultado.StartsWith("ERRO:"))
            {
                setores[setorOrigem].Remove(personagem);

                if (!setores.ContainsKey(setorDestino))
                    setores[setorDestino] = new List<string>();

                setores[setorDestino].Add(personagem);

                lblControle.Text += $"Promovido aleatoriamente: {personagem} ({setorOrigem}->{setorDestino})\n";
            }
            else
            {
                lblControle.Text += $"Falha ao promover {personagem}: {resultado}\n";
            }
        }
        private string SortearPersonagemDisponivel()
        {
            try
            {
                string retorno = Jogo.ListarPersonagens();
                if (retorno.StartsWith("ERRO:"))
                {
                    Console.WriteLine($"Erro ao listar personagens: {retorno}");
                    return null;
                }

                retorno = retorno.Replace("\r", "").Trim();
                string[] todos = retorno.Split('\n');

                // Obter personagens j� no tabuleiro diretamente do estado atual
                var estadoTabuleiro = EstadoAtualTabuleiro();
                var personagensNoTabuleiro = ObterPersonagensNoTabuleiro(estadoTabuleiro);

                // Debug: Mostrar personagens dispon�veis
                Console.WriteLine("Todos os personagens: " + string.Join(",", todos));
                Console.WriteLine("Personagens no tabuleiro: " + string.Join(",", personagensNoTabuleiro));

                List<string> disponiveis = todos
                    .Where(p => !string.IsNullOrWhiteSpace(p))
                    .Select(p => p.Trim())
                    .Where(p => !personagensNoTabuleiro.Contains(p))
                    .ToList();

                // Debug: Mostrar personagens dispon�veis ap�s filtro
                Console.WriteLine("Personagens dispon�veis: " + string.Join(",", disponiveis));

                if (disponiveis.Count == 0)
                {
                    Console.WriteLine("Nenhum personagem dispon�vel para posicionar.");
                    return null;
                }

                // Sele��o verdadeiramente aleat�ria
                int index = random.Next(disponiveis.Count);
                string selecionado = disponiveis[index];
                Console.WriteLine($"Personagem selecionado aleatoriamente: {selecionado}");

                return selecionado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em SortearPersonagemDisponivel: {ex.Message}");
                return null;
            }
        }

        // M�todo auxiliar para extrair personagens do tabuleiro
        private HashSet<string> ObterPersonagensNoTabuleiro(string estadoTabuleiro)
        {
            var personagens = new HashSet<string>();
            string[] linhas = estadoTabuleiro.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                if (partes.Length == 2)
                {
                    personagens.Add(partes[1].Trim());
                }
            }

            return personagens;
        }

        private int SortearSetorDisponivel()
        {
            // Durante a fase de setup, s� permitir setores 1-4
            var setoresValidos = setores
                .Where(kv => kv.Key >= 1 && kv.Key <= 4)  // Apenas setores 1-4
                .Where(kv => kv.Value.Count < 4)          // Com espa�o dispon�vel
                .Select(kv => kv.Key)
                .ToList();

            if (setoresValidos.Count == 0)
                return -1;

            return setoresValidos[random.Next(setoresValidos.Count)];
        }

        private void PosicionarPersonagem(int idJogador, string senha, string personagem, int setor)
        {
            if (string.IsNullOrWhiteSpace(personagem))
            {
                Console.WriteLine("Personagem inv�lido sorteado.");
                return;
            }

            string inicial = personagem.Substring(0, 1);
            string estadoAtual = Jogo.ColocarPersonagem(idJogador, senha, setor, inicial);

            if (estadoAtual.StartsWith("ERRO:"))
            {
                Console.WriteLine($"Erro ao posicionar: {estadoAtual}");
                return;
            }

            // Atualiza as estruturas locais
            personagensColocados.Add(personagem.Trim());
            if (!setores.ContainsKey(setor))
            {
                setores[setor] = new List<string>();
            }
            setores[setor].Add(personagem.Trim());

            lblControle.Text += $"Colocando personagem '{personagem}' no setor {setor}.\n";
            AtualizarTabuleiro(estadoAtual);
        }

        private void SincronizarEstadoTabuleiro()
        {
            try
            {
                string estadoTabuleiro = EstadoAtualTabuleiro();
                var novoEstado = new Dictionary<int, List<string>>();
                var linhas = estadoTabuleiro.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string linha in linhas)
                {
                    var partes = linha.Split(',');
                    if (partes.Length == 2 && int.TryParse(partes[0].Trim(), out int setor))
                    {
                        if (!novoEstado.ContainsKey(setor))
                            novoEstado[setor] = new List<string>();
                        novoEstado[setor].Add(partes[1].Trim());
                    }
                }
                setores = novoEstado;
                personagensColocados = novoEstado.Values.SelectMany(x => x).Distinct().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao sincronizar tabuleiro: {ex.Message}");
            }
        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }
    }
}







