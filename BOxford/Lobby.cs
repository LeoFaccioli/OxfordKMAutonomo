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
        private int rodadaAtual = 1;
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


            // Mostrar versão na tela
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

            //Opções de filtro
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

            // Obtém o ID do jogador que tem a vez
            string retorno = Jogo.VerificarVez(partidaId).Trim();
            string[] vez = retorno.Split(',');
            string[] linhas = retorno.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            lblIdVez.Text = vez[0]; // ID do jogador que tem a vez

            string estadoTabuleiro = string.Join("\n", linhas.Skip(1));


            // Obtém a lista de jogadores
            string retorno2 = Jogo.ListarJogadores(partidaId).Trim();
            string[] jogadores = retorno2.Split('\n'); // Divide os jogadores por linha

            // Percorre os jogadores para encontrar o nome do jogador que tem a vez
            foreach (string jogador in jogadores)
            {
                string[] dadosJogador = jogador.Split(','); // Divide ID, Nome e Pontuação

                if (dadosJogador.Length >= 2 && dadosJogador[0].Trim() == vez[0].Trim())
                {
                    lblNomeVez.Text = dadosJogador[1].Trim(); // Pega o Nome do jogador correspondente
                    break; // Sai do loop assim que encontrar
                }
            }

            AtualizarTabuleiro(estadoTabuleiro);


            // Caso não encontre o jogador, mostra um alerta
            if (string.IsNullOrEmpty(lblNomeVez.Text))
            {
                MessageBox.Show("Jogador com ID " + vez[0] + " não encontrado.");
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

            if (!posicoesSetores.ContainsKey(setor))
            {
                return;
            }

           
            int cartasNoSetor = Controls.OfType<PictureBox>().Count(p => p.Tag != null && (int)p.Tag == setor);

            Image imagem = ObterImagemDaCarta(carta);
            if (imagem == null)
            {
                return;
            }

            Bitmap bitmapImagem = new Bitmap(imagem);
            bitmapImagem.MakeTransparent();

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

            Controls.Add(cartaImg);
            cartaImg.BringToFront();
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

            // Obtém o ID do jogador que tem a vez
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

                if (JogadorDaVez())
                {
                    AtualizarMinhasCartas();
                }

                bool iniciada = vez.Length > 1 && vez[1].Trim().Equals("J");
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
        private static readonly Dictionary<string, int> rankingPersonagens = new Dictionary<string, int>
        {
            {"A", 7},  
            {"B", 6},  
            {"C", 5},  
            {"D", 4},  
            {"E", 3},  
            {"G", 2},  
            {"H", 1},  
            {"K", 5},  
            {"L", 4},  
            {"M", 3},  
            {"Q", 2},  
            {"R", 1},  
            {"T", 6} 
        };

        private List<string> minhasCartas = new List<string>();
        private List<string> personagensEmJogo = new List<string>();
        private void AtualizarMinhasCartas()
        {
            try
            {
                string retorno = Jogo.ListarCartas(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text);

                if (retorno.StartsWith("ERRO:"))
                {
                    return;
                }

                minhasCartas.Clear();
                foreach (char c in retorno.Trim())
                {
                    minhasCartas.Add(c.ToString());
                }

                var cartasDisponiveis = minhasCartas.Except(personagensColocados).ToList();

                minhasCartas = cartasDisponiveis
                    .OrderByDescending(c => rankingPersonagens.GetValueOrDefault(c, 0))
                    .ToList();

            }
            catch (Exception ex)
            {
            }
        }
        private bool reiEleito = false;
        private void tmrVerificaVez_Tick(object sender, EventArgs e)
        {
            tmrVerificaVez.Enabled = false;
            try
            {
                if (!JogadorConectado()) return;

                var (dadosVez, partidaIniciada) = VerificarVezCompleto();

                SincronizarEstadoTabuleiro();

                if (!partidaIniciada)
                {
                    tmrVerificaVez.Enabled = true;
                    return;
                }

                if (dadosVez != null && dadosVez.Length >= 4)
                {
                    char faseAtual = dadosVez[3][0];
                    string idJogadorVez = dadosVez[0];

                    lblIdVez.Text = idJogadorVez;

                    if (reiEleito && (!setores.ContainsKey(10) || setores[10].Count == 0))
                    {
                        reiEleito = false;
                        votacaoConcluida = false;
                        ReiniciarRodada();
                        tmrVerificaVez.Enabled = true;
                        return;
                    }

                    if (JogadorDaVez())
                    {
                        switch (faseAtual)
                        {
                            case 'S': // Setup
                                if (personagensColocados.Count < 13) 
                                {
                                    ProcessarSetup();
                                }
                                break;

                            case 'P': // Promoção
                                 AtualizarMinhasCartas();
                                 ProcessarPromocao();
                                break;

                            case 'V': // Votação
                                
                                AtualizarMinhasCartas();
                                ProcessarVotacao();
                                
                                break;
                        }

                        VerificarFimDeJogo();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                tmrVerificaVez.Enabled = true;
            }
        }
        private string EscolherVotoEstrategico(string cartaRei)
        {
            if (!JogadorConectado()) return "N";

            bool ehMinhaCarta = minhasCartas.Contains(cartaRei);
            int valorCarta = rankingPersonagens.GetValueOrDefault(cartaRei, 0);

            if (ehMinhaCarta)
            {
                return "S"; 
            }
            else if (valorCarta >= 6)
            {
                return "N"; 
            }
            else 
            {
                return random.Next(100) < 70 ? "S" : "N";
            }
        }
        private void VerificarFimDeJogo()
        {
            try
            {
                string estado = Jogo.VerificarVez(Convert.ToInt32(txtIDpartida.Text));
                if (estado.Contains(",E,"))
                {
                    tmrVerificaVez.Enabled = false;
                    string[] partes = estado.Split(',');

                    if (partes.Length > 4)
                    {
                        lblControle.Text += $"=== FIM DE JOGO ===\nVencedor: {partes[4]}\n";
                    }
                    else
                    {
                        lblControle.Text += "=== FIM DE JOGO ===\n";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void ReiniciarRodada()
        {
            try
            {
                personagensColocados.Clear();
                setores = new Dictionary<int, List<string>>()
                {
                    {1, new List<string>()},
                    {2, new List<string>()},
                    {3, new List<string>()},
                    {4, new List<string>()},
                    {5, new List<string>()},
                    {10, new List<string>()}
                };

                var cartas = Controls.OfType<PictureBox>().Where(p => p.Tag != null).ToList();
                foreach (var carta in cartas)
                {
                    Controls.Remove(carta);
                    carta.Dispose();
                }

                votacaoConcluida = false;
                reiEleito = false;
                ultimaCartaRei = "";

                rodadaAtual++;
                lblControle.Text = $"Rodada: {rodadaAtual}\n";
                lblControle.Text += "=== NOVA RODADA INICIADA ===\n";
            }
            catch (Exception ex)
            {
            }
        }
        private void SincronizarEstadoTabuleiro(bool forcarAtualizacao = false)
        {
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (!setores.ContainsKey(i))
                    {
                        setores[i] = new List<string>();
                    }
                }
                if (!setores.ContainsKey(10))
                {
                    setores[10] = new List<string>();
                }

                
            }
            catch (Exception ex)
            { 
            }
        }
        private void ProcessarSetup()
        {
            try
            {
                if (!JogadorDaVez()) return;

                AtualizarMinhasCartas();
                SincronizarEstadoTabuleiro();

                if (personagensColocados.Count >= 13)
                {
                    lblControle.Text += "Todos os personagens já foram posicionados.\n";
                    return;
                }

                string personagem = EscolherMelhorPersonagemDisponivel();
                if (personagem == null)
                {
                    lblControle.Text += "Todos os personagens já foram posicionados no tabuleiro.\n";
                    return;
                }

                int setor = EscolherMelhorSetorSetup();
                if (setor == -1)
                {
                    SincronizarEstadoTabuleiro(true);

                    setor = EscolherMelhorSetorSetup();

                    if (setor == -1)
                    {
                        lblControle.Text += "ERRO: Todos os setores de setup estão cheios. Verifique o jogo.\n";
                        return;
                    }
                }

                PosicionarPersonagem(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text, personagem, setor);
                lblControle.Text += $"Posicionado: {personagem} no setor {setor}\n";
                personagensColocados.Add(personagem);
            }
            catch (Exception ex)
            {
            }
        }
        private int EscolherMelhorSetorSetup()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (!setores.ContainsKey(i))
                {
                    setores[i] = new List<string>();
                }
            }

            var setoresDisponiveis = setores
                .Where(kv => kv.Key >= 1 && kv.Key <= 4)  
                .Where(kv => kv.Value.Count < 4)          
                .OrderBy(kv => kv.Value.Count)            
                .ThenBy(kv => kv.Key)                     
                .Select(kv => kv.Key)
                .ToList();

            return setoresDisponiveis.FirstOrDefault(-1);
        }
        private void AtualizarTabuleiroVisual()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(AtualizarTabuleiroVisual));
                return;
            }
            var cartas = Controls.OfType<PictureBox>().Where(p => p.Tag != null).ToList();
            foreach (var carta in cartas)
            {
                Controls.Remove(carta);
                carta.Dispose();
            }

            foreach (var setor in setores)
            {
                foreach (var carta in setor.Value)
                {
                    PosicionarCarta(setor.Key, carta);
                }
            }
        }
        private bool JogadorDaVez()
        {
            return lblIdJogador.Text == lblIdVez.Text;
        }
        private void ProcessarPromocao()
        {
            try
            {
                if (!JogadorDaVez()) return;

                AtualizarMinhasCartas();
                SincronizarEstadoTabuleiro();

                if (setores.ContainsKey(5) && setores[5].Count > 0 &&
                    (!setores.ContainsKey(10) || setores[10].Count == 0))
                { 
                    var melhorPersonagem = setores[5]
                        .OrderByDescending(p => rankingPersonagens.GetValueOrDefault(p, 0))
                        .FirstOrDefault();

                    if (melhorPersonagem != null)
                    {
                        string resultado = Jogo.Promover(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text, melhorPersonagem);

                        if (!resultado.StartsWith("ERRO:"))
                        {
                            lblControle.Text += $"Promovido estrategicamente para KingsMe: {melhorPersonagem}\n";
                            return;
                        }
                    }
                }
                for (int setorAtual = 1; setorAtual <= 4; setorAtual++)
                {
                    if (setores.ContainsKey(setorAtual) && setores[setorAtual].Count > 0)
                    {
                        int setorDestino = setorAtual + 1;

                        if (!setores.ContainsKey(setorDestino) || setores[setorDestino].Count < 4)
                        {
                            var melhorPersonagem = setores[setorAtual]
                                .OrderByDescending(p => rankingPersonagens.GetValueOrDefault(p, 0))
                                .FirstOrDefault();

                            if (melhorPersonagem != null)
                            {
                                string resultado = Jogo.Promover(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text, melhorPersonagem);

                                if (!resultado.StartsWith("ERRO:"))
                                {
                                    lblControle.Text += $"Promovido estrategicamente: {melhorPersonagem} (Setor {setorAtual}->{setorDestino})\n";
                                    return;
                                }
                            }
                        }
                    }
                }

                lblControle.Text += "Nenhuma promoção estratégica possível no momento.\n";
            }
            catch (Exception ex)
            {
            }
        }
        private bool votacaoEmAndamento = false;
        private string ultimaCartaRei = "";
        private bool votacaoConcluida = false;
        private void ProcessarVotacao()
        {
            try
            {
                if (!JogadorDaVez()) return;

                SincronizarEstadoTabuleiro();

                if (setores.ContainsKey(10) && setores[10].Count > 0)
                {
                    string cartaReiAtual = setores[10][0];

                    if (cartaReiAtual != ultimaCartaRei)
                    {
                        votacaoConcluida = false;
                        ultimaCartaRei = cartaReiAtual;
                        lblControle.Text += $"Nova votação iniciada para: {cartaReiAtual}\n";
                    }

                    if (!votacaoConcluida)
                    {
                        string voto = EscolherVotoEstrategico(cartaReiAtual);

                        string resultado = Jogo.Votar(
                            Convert.ToInt32(txtIDjogador.Text),
                            txtSenha.Text,
                            voto
                        );

                        if (!resultado.StartsWith("ERRO:"))
                        {
                            votacaoConcluida = true;
                            lblControle.Text += $"Voto registrado: {voto} para {cartaReiAtual}\n";

                            if (voto == "S")
                            {
                                reiEleito = true;
                            }
                        }
                        else
                        {
                            lblControle.Text += $"Erro ao votar: {resultado}\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private bool JogadorConectado()
        {
            return !string.IsNullOrEmpty(txtIDjogador.Text) &&
                   !string.IsNullOrEmpty(txtSenha.Text) &&
                   !string.IsNullOrEmpty(txtIDpartida.Text) &&
                   int.TryParse(txtIDjogador.Text, out _) &&
                   int.TryParse(txtIDpartida.Text, out _);
        }
        private void PosicionarPersonagem(int idJogador, string senha, string personagem, int setor)
        {
            try
            {
                if (setor < 1 || setor > 4)
                {
                    return;
                }
                if (setores.ContainsKey(setor) && setores[setor].Count >= 4)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(personagem))
                {
                    personagem = EscolherMelhorPersonagemDisponivel();
                    if (personagem == null)
                    {
                        return;
                    }
                }

                string inicial = personagem.Substring(0, 1);
                string estadoAtual = Jogo.ColocarPersonagem(idJogador, senha, setor, inicial);

                if (estadoAtual.StartsWith("ERRO:"))
                {
                    string proximoPersonagem = EscolherMelhorPersonagemDisponivel();
                    if (proximoPersonagem != null && proximoPersonagem != personagem)
                    {
                        PosicionarPersonagem(idJogador, senha, proximoPersonagem, setor);
                    }
                    return;
                }
                personagensColocados.Add(personagem);
                if (!setores.ContainsKey(setor))
                {
                    setores[setor] = new List<string>();
                }
                setores[setor].Add(personagem);

                lblControle.Text += $"Posicionado: {personagem} no setor {setor}\n";
                AtualizarTabuleiro(estadoAtual);
            }
            catch (Exception ex)
            {
            }
        }
        private void SincronizarEstadoTabuleiro()
        {
            try
            {
                string estadoTabuleiro = EstadoAtualTabuleiro();
                var novoEstado = new Dictionary<int, List<string>>();
                var linhas = estadoTabuleiro.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                personagensColocados.Clear();

                foreach (string linha in linhas)
                {
                    var partes = linha.Split(',');
                    if (partes.Length == 2 && int.TryParse(partes[0].Trim(), out int setor))
                    {
                        string personagem = partes[1].Trim();

                        if (!novoEstado.ContainsKey(setor))
                            novoEstado[setor] = new List<string>();

                        novoEstado[setor].Add(personagem);
                        personagensColocados.Add(personagem);
                    }
                }

                setores = novoEstado;
                AtualizarTabuleiroVisual();
            }
            catch (Exception ex)
            {
            }
        }
        private string EscolherMelhorPersonagemDisponivel()
        {
            try
            {
                var cartasDisponiveis = minhasCartas
                    .Except(personagensColocados)
                    .OrderByDescending(c => rankingPersonagens.GetValueOrDefault(c, 0))
                    .ToList();

                if (cartasDisponiveis.Count > 0)
                {
                    return cartasDisponiveis.First();
                }
                var todasCartas = rankingPersonagens.Keys.ToList();
                var todasDisponiveis = todasCartas
                    .Except(personagensColocados)
                    .OrderByDescending(c => rankingPersonagens.GetValueOrDefault(c, 0))
                    .ToList();

                return todasDisponiveis.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }
    }
}