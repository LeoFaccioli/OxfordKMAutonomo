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
            tmrVerificaVez.Enabled = true;
            MessageBox.Show("Timer Iniciado");

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

        private string[] VerificarVez()
        {
            string partida = txtIDpartida.Text;
            int partidaId = Convert.ToInt32(partida);

            string retorno = Jogo.VerificarVez(partidaId).Trim();
            if (string.IsNullOrEmpty(retorno))
                return null;

            string[] linhas = retorno.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            if (linhas.Length == 0)
                return null;

            string[] vez = linhas[0].Split(',');
            if (vez.Length < 4) 
                return null;

            lblIdVez.Text = vez[0];
            string estadoTabuleiro = string.Join("\n", linhas.Skip(1));

            // Atualizar nome do jogador da vez
            string retorno2 = Jogo.ListarJogadores(partidaId).Trim();
            string[] jogadores = retorno2.Split('\n');

            foreach (string jogador in jogadores)
            {
                string[] dadosJogador = jogador.Split(',');
                if (dadosJogador.Length >= 2 && dadosJogador[0].Trim() == vez[0].Trim())
                {
                    lblNomeVez.Text = dadosJogador[1].Trim();
                    break;
                }
            }

            AtualizarTabuleiro(estadoTabuleiro);
            return vez;


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


        private void tmrVerificaVez_Tick(object sender, EventArgs e)
        {
            tmrVerificaVez.Enabled = false;

            try
            {
                SincronizarEstadoTabuleiro();
                string[] vez = VerificarVez();
                if (vez == null || vez.Length < 4) // Verifica se tem pelo menos 4 elementos
                {
                    tmrVerificaVez.Enabled = true;
                    return;
                }

                string idJogadorVez = vez[0];
                string faseAtual = vez[3].ToUpper();

                if (idJogadorVez == lblIdJogador.Text)
                {
                    if (faseAtual == "S")
                    {
                        string personagem = SortearPersonagemDisponivel();
                        if (personagem == null)
                        {
                            Console.WriteLine("Nenhum personagem dispon�vel para posicionar.");
                            tmrVerificaVez.Enabled = true;
                            return;
                        }
                        int setor = SortearSetorDisponivel();
                        if (setor == -1)
                        {
                            Console.WriteLine("Todos os setores v�lidos est�o cheios.");
                            tmrVerificaVez.Enabled = true;
                            return;
                        }

                        // Resetar listas se acabou de entrar na fase de setup
                        if (setores.Values.All(list => list.Count == 0))
                        {
                            personagensColocados.Clear();
                            foreach (var key in setores.Keys)
                            {
                                setores[key].Clear();
                            }
                        }
                        PosicionarPersonagem(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text,
                                   personagem, setor);
                    }
                    else if (faseAtual == "P")
                    {
                        PromoverPersonagens();
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

        private void PromoverPersonagens()
        {
            int idJogador = Convert.ToInt32(txtIDjogador.Text);
            string senha = txtSenha.Text;
            bool promocaoRealizada = false;

            // Ordem correta de verifica��o: do setor mais baixo (1) para o mais alto (5)
            for (int setorAtual = 1; setorAtual <= 5 && !promocaoRealizada; setorAtual++)
            {
                if (!setores.ContainsKey(setorAtual) || setores[setorAtual].Count == 0)
                    continue;

                // Verifica cada personagem no setor atual
                foreach (string personagem in setores[setorAtual].ToList())
                {
                    int proximoSetor = (setorAtual == 5) ? 10 : setorAtual + 1;

                    // Verifica se o pr�ximo setor existe e tem espa�o
                    if (proximoSetor == 10)
                    {
                        // Setor 10 (KingsMe!) s� permite 1 personagem
                        if (setores.ContainsKey(10) && setores[10].Count >= 1)
                            continue;
                    }
                    else
                    {
                        // Outros setores permitem at� 4 personagens
                        if (setores.ContainsKey(proximoSetor) && setores[proximoSetor].Count >= 4)
                            continue;
                    }

                    // Tenta promover no servidor
                    string resultado = Jogo.Promover(idJogador, senha, personagem);

                    if (!resultado.StartsWith("ERRO:"))
                    {
                        // Atualiza estruturas locais somente se a promo��o foi bem-sucedida no servidor
                        setores[setorAtual].Remove(personagem);

                        if (!setores.ContainsKey(proximoSetor))
                            setores[proximoSetor] = new List<string>();

                        setores[proximoSetor].Add(personagem);

                        lblControle.Text += $"Promovido: {personagem} ({setorAtual} -> {proximoSetor})\n";
                        promocaoRealizada = true;
                        break;
                    }
                    else
                    {
                        lblControle.Text += $"Falha ao promover {personagem}: {resultado}\n";
                    }
                }
            }

            if (!promocaoRealizada)
            {
                lblControle.Text += "Nenhuma promo��o poss�vel no momento.\n";
            }
        }
        private string SortearPersonagemDisponivel()
        {
            // Primeiro obt�m a lista atual de personagens do jogo
            string retorno = Jogo.ListarPersonagens();
            if (retorno.StartsWith("ERRO:"))
            {
                Console.WriteLine($"Erro ao listar personagens: {retorno}");
                return null;
            }

            retorno = retorno.Replace("\r", "");
            string[] todos = retorno.Split('\n');

            // Obt�m o estado atual do tabuleiro para verificar personagens j� posicionados
            string estadoTabuleiro = EstadoAtualTabuleiro();
            var personagensNoTabuleiro = ObterPersonagensNoTabuleiro(estadoTabuleiro);

            // Filtra personagens dispon�veis
            List<string> disponiveis = todos
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Where(p => !personagensNoTabuleiro.Contains(p.Trim()))
                .ToList();

            if (disponiveis.Count == 0)
            {
                Console.WriteLine("Todos os personagens j� foram posicionados.");
                return null;
            }

            return disponiveis[random.Next(disponiveis.Count)];
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

    }
    private void SincronizarEstadoTabuleiro()
        {
            string estadoTabuleiro = EstadoAtualTabuleiro();
            var personagensPorSetor = new Dictionary<int, List<string>>();

            string[] linhas = estadoTabuleiro.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                if (partes.Length == 2)
                {
                    int setor = int.Parse(partes[0].Trim());
                    string personagem = partes[1].Trim();

                    if (!personagensPorSetor.ContainsKey(setor))
                        personagensPorSetor[setor] = new List<string>();

                    personagensPorSetor[setor].Add(personagem);
                }
            }

            // Atualiza as estruturas locais
            setores = personagensPorSetor;
            personagensColocados = personagensPorSetor.Values.SelectMany(x => x).ToList();
        }
    }








