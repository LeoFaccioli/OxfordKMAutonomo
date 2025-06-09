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

            // Verifica se o setor existe
            if (!posicoesSetores.ContainsKey(setor))
            {
                Console.WriteLine($"Setor {setor} não encontrado no dicionário.");
                return;
            }

            // Conta quantas cartas já estão no setor
            int cartasNoSetor = Controls.OfType<PictureBox>()
                                        .Count(p => p.Tag != null && (int)p.Tag == setor);

            // Obtém a imagem da carta usando a função ObterImagemDaCarta
            Image imagem = ObterImagemDaCarta(carta);
            if (imagem == null)
            {
                Console.WriteLine($"Carta '{carta}' não encontrada no dicionário de imagens.");
                return;
            }

            // Define transparência na imagem
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

            // Adiciona ao formulário
            Controls.Add(cartaImg);
            cartaImg.BringToFront();

            Console.WriteLine($"Carta '{carta}' posicionada no setor {setor}, posição {cartasNoSetor + 1}.");
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

                // Atualiza minhas cartas sempre que verifica a vez
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

            // Obtém o ID do jogador que tem a vez
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
            {"A", 7},  // Adilson - mais valioso
            {"B", 6},  // Beatriz
            {"C", 5},  // Claro
            {"D", 4},  // Douglas
            {"E", 3},  // Eduardo
            {"G", 2},  // Guilherme
            {"H", 1},  // Heredia - menos valioso
            {"K", 5},  // Kelly
            {"L", 4},  // Leonardo
            {"M", 3},  // Mario
            {"Q", 2},  // Quintas
            {"R", 1},  // Ranulfo
            {"T", 6}   // Toshio
        };

        private List<string> minhasCartas = new List<string>();
        private List<string> personagensEmJogo = new List<string>();

        private bool VerificarCartaNoSetor10()
        {
            try
            {
                // Primeiro sincroniza com o estado real do servidor
                string estadoTabuleiro = EstadoAtualTabuleiro();
                var linhas = estadoTabuleiro.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string linha in linhas)
                {
                    var partes = linha.Split(',');
                    if (partes.Length == 2 && int.TryParse(partes[0].Trim(), out int setor) && setor == 10)
                    {
                        string carta = partes[1].Trim();
                        lblControle.Text += $"REI DETECTADO: {carta} no setor 10\n";
                        Console.WriteLine($"Carta {carta} chegou ao KingsMe");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar setor 10: {ex.Message}");
                return false;
            }
        }
        private bool PartidaFoiIniciada()
        {
            try
            {
                string retorno = Jogo.VerificarVez(Convert.ToInt32(txtIDpartida.Text));
                if (string.IsNullOrEmpty(retorno)) return false;

                // Verifica múltiplos indicadores de partida iniciada
                return retorno.Contains(",J,") ||  // Formato do servidor
                       retorno.Contains("Jogando") ||
                       !retorno.Contains("Aguardando");
            }
            catch
            {
                return false;
            }
        }
        private void AtualizarMinhasCartas()
        {
            try
            {
                string retorno = Jogo.ListarCartas(Convert.ToInt32(txtIDjogador.Text), txtSenha.Text);

                if (retorno.StartsWith("ERRO:"))
                {
                    Console.WriteLine($"Erro ao listar cartas: {retorno}");
                    return;
                }

                minhasCartas.Clear();
                foreach (char c in retorno.Trim())
                {
                    minhasCartas.Add(c.ToString());
                }

                // Remove cartas que já estão no tabuleiro
                var cartasDisponiveis = minhasCartas.Except(personagensColocados).ToList();

                // Ordena as cartas disponíveis pelo ranking
                minhasCartas = cartasDisponiveis
                    .OrderByDescending(c => rankingPersonagens.GetValueOrDefault(c, 0))
                    .ToList();

                Console.WriteLine($"Cartas disponíveis: {string.Join(",", minhasCartas)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em AtualizarMinhasCartas: {ex.Message}");
            }
        }
        private bool reiEleito = false;
        private void tmrVerificaVez_Tick(object sender, EventArgs e)
        {
            tmrVerificaVez.Enabled = false;
            try
            {
                if (!JogadorConectado()) return;

                // Atualiza primeiro o estado do jogo
                var (dadosVez, partidaIniciada) = VerificarVezCompleto();

                // Atualiza o tabuleiro visual
                SincronizarEstadoTabuleiro();

                // Verifica se a partida está em andamento
                if (!partidaIniciada)
                {
                    tmrVerificaVez.Enabled = true;
                    return;
                }

                if (dadosVez != null && dadosVez.Length >= 4)
                {
                    char faseAtual = dadosVez[3][0];
                    string idJogadorVez = dadosVez[0];

                    // Atualiza quem tem a vez
                    lblIdVez.Text = idJogadorVez;

                    // Verifica se houve reinício (setor 10 vazio após coroação)
                    if (reiEleito && (!setores.ContainsKey(10) || setores[10].Count == 0))
                    {
                        reiEleito = false;
                        votacaoConcluida = false;
                        ReiniciarRodada();
                        tmrVerificaVez.Enabled = true;
                        return;
                    }

                    // Processa cada fase do jogo de acordo com a estratégia
                    if (JogadorDaVez())
                    {
                        switch (faseAtual)
                        {
                            case 'S': // Setup
                                if (personagensColocados.Count < 13) // Ainda há personagens para colocar
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

                        // Verifica se o jogo terminou
                        VerificarFimDeJogo();
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
        private string EscolherVotoEstrategico(string cartaRei)
        {
            if (!JogadorConectado()) return "N";

            // 1. Verifica se a carta é do jogador
            bool ehMinhaCarta = minhasCartas.Contains(cartaRei);

            // 2. Obtém o valor da carta
            int valorCarta = rankingPersonagens.GetValueOrDefault(cartaRei, 0);

            // 3. Estratégia básica:
            if (ehMinhaCarta)
            {
                return "S"; // Sempre vota a favor das próprias cartas
            }
            else if (valorCarta >= 6) // Cartas muito valiosas
            {
                return "N"; // Vota contra para evitar que outros ganhem pontos
            }
            else // Cartas medianas ou fracas
            {
                // Chance 70% de votar Sim para cartas medianas/fracas
                return random.Next(100) < 70 ? "S" : "N";
            }
        }
        // Métodos auxiliares
        private int ObterNumeroJogadores()
        {
            try
            {
                string retorno = Jogo.ListarJogadores(Convert.ToInt32(txtIDpartida.Text));
                return retorno.Split('\n').Length - 1; // Ajuste conforme formato real
            }
            catch
            {
                return 4; // Default seguro
            }
        }
        private int ObterMeusVotosNao(int numJogadores)
        {
            return numJogadores switch
            {
                3 => 4,
                4 => 3,
                5 => 2,
                6 => 2,
                _ => 2 // Default
            };
        }
        // Estratégias específicas por número de jogadores
        private string EstrategiaPara3Jogadores(string cartaRei, bool ehMinhaCarta, int valorCarta, int meusVotosNao)
        {
            // Com 3 jogadores, cada um tem muito poder de veto (4 "Não")
            if (ehMinhaCarta)
            {
                // Se for minha carta, sempre voto "Sim" e guardo votos "Não"
                return "S";
            }

            // Para cartas muito valiosas (A, B, T) - tentar bloquear
            if (valorCarta >= 6 && meusVotosNao > 2)
            {
                return "N";
            }

            // Para cartas medianas, economizar votos
            return "S";
        }
        private string EstrategiaPara4Jogadores(string cartaRei, bool ehMinhaCarta, int valorCarta, int meusVotosNao)
        {
            // Com 4 jogadores, o equilíbrio é mais delicado (3 "Não" cada)
            if (ehMinhaCarta)
            {
                return "S"; // Sempre apoie suas próprias cartas
            }

            // Cartas muito boas: use "Não" se tiver votos suficientes
            if (valorCarta >= 6 && meusVotosNao > 1)
            {
                return "N";
            }

            // Cartas ruins: deixe passar para eliminar personagens fracos
            if (valorCarta <= 2)
            {
                return "S";
            }

            // Padrão: economize votos para cartas realmente perigosas
            return new Random().NextDouble() > 0.7 ? "N" : "S";
        }
        private string EstrategiaPara5Jogadores(string cartaRei, bool ehMinhaCarta, int valorCarta, int meusVotosNao)
        {
            // Com 5 jogadores, cada um tem apenas 2 "Não" (e 2 sobram)
            if (ehMinhaCarta)
            {
                return "S";
            }

            // Só vale a pena votar "Não" em cartas extremamente valiosas
            if (valorCarta >= 7 && meusVotosNao > 0)
            {
                return "N";
            }

            // Para cartas medianas/fracas, deixe passar
            return "S";
        }
        private string EstrategiaPara6Jogadores(string cartaRei, bool ehMinhaCarta, int valorCarta, int meusVotosNao)
        {
            // Com 6 jogadores, cada um tem apenas 2 "Não"
            if (ehMinhaCarta)
            {
                return "S";
            }

            // Só use "Não" se for absolutamente necessário
            if (valorCarta >= 7 && meusVotosNao == 2)
            {
                return "N";
            }

            // Economize votos para o final do jogo
            return "S";
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
                Console.WriteLine($"Erro ao verificar fim de jogo: {ex.Message}");
            }
        }
        private void ReiniciarRodada()
        {
            try
            {
                // Limpa o estado local
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

                // Limpa o tabuleiro visual
                var cartas = Controls.OfType<PictureBox>().Where(p => p.Tag != null).ToList();
                foreach (var carta in cartas)
                {
                    Controls.Remove(carta);
                    carta.Dispose();
                }

                // Reseta variáveis de votação
                votacaoConcluida = false;
                reiEleito = false;
                ultimaCartaRei = "";

                // Atualiza a interface
                rodadaAtual++;
                lblControle.Text = $"Rodada: {rodadaAtual}\n";
                lblControle.Text += "=== NOVA RODADA INICIADA ===\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reiniciar rodada: {ex.Message}");
            }
        }
        private void SincronizarEstadoTabuleiro(bool forcarAtualizacao = false)
        {
            try
            {
                // Inicializa os setores se não existirem
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

                // Restante do método...
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao sincronizar tabuleiro: {ex.Message}");
            }
        }

        private bool EstadosSaoIguais(Dictionary<int, List<string>> estado1, Dictionary<int, List<string>> estado2)
        {
            // Comparação simplificada sem usar DictionaryEqual
            if (estado1.Keys.Count != estado2.Keys.Count) return false;

            foreach (var kvp in estado1)
            {
                if (!estado2.ContainsKey(kvp.Key)) return false;
                if (!estado2[kvp.Key].SequenceEqual(kvp.Value)) return false;
            }

            return true;
        }
        private void ProcessarNovaRodada()
        {
            // 1. Limpar estado visual
            Controls.OfType<PictureBox>().ToList().ForEach(p => Controls.Remove(p));

            // 2. Reiniciar estruturas de dados
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

            // 3. Sincronizar com servidor
            SincronizarEstadoTabuleiro();

            // 4. Processar primeiro movimento
            ProcessarSetup();
        }
        private void ProcessarSetup()
        {
            try
            {
                if (!JogadorDaVez()) return;

                AtualizarMinhasCartas();
                SincronizarEstadoTabuleiro();

                // Verifica se todos os personagens já foram colocados
                if (personagensColocados.Count >= 13) // Total de personagens no jogo
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
                    // Se não há setores disponíveis, verifica se é um erro de sincronização
                    SincronizarEstadoTabuleiro(true); // Força atualização

                    setor = EscolherMelhorSetorSetup(); // Tenta novamente

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
                Console.WriteLine($"Erro no ProcessarSetup: {ex.Message}");
            }
        }
        private int EscolherMelhorSetorSetup()
        {
            // Garante que os setores existam no dicionário
            for (int i = 1; i <= 4; i++)
            {
                if (!setores.ContainsKey(i))
                {
                    setores[i] = new List<string>();
                }
            }

            var setoresDisponiveis = setores
                .Where(kv => kv.Key >= 1 && kv.Key <= 4)  // Apenas setores 1-4 no setup
                .Where(kv => kv.Value.Count < 4)          // Com espaço disponível (máx 4 cartas)
                .OrderBy(kv => kv.Value.Count)            // Preferir setores menos ocupados
                .ThenBy(kv => kv.Key)                     // Em caso de empate, escolher o menor número
                .Select(kv => kv.Key)
                .ToList();

            return setoresDisponiveis.FirstOrDefault(-1); // Retorna -1 se nenhum setor disponível
        }
        private void AtualizarTabuleiroVisual()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(AtualizarTabuleiroVisual));
                return;
            }

            // Remove apenas as PictureBox de cartas
            var cartas = Controls.OfType<PictureBox>().Where(p => p.Tag != null).ToList();
            foreach (var carta in cartas)
            {
                Controls.Remove(carta);
                carta.Dispose();
            }

            // Recria todas as cartas baseadas no estado atual
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

                // Prioridade 1: Promover para o KingsMe se possível
                if (setores.ContainsKey(5) && setores[5].Count > 0 &&
                    (!setores.ContainsKey(10) || setores[10].Count == 0))
                {
                    // Escolhe o melhor personagem no setor 5
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

                // Prioridade 2: Promover personagens valiosos em setores inferiores
                for (int setorAtual = 1; setorAtual <= 4; setorAtual++)
                {
                    if (setores.ContainsKey(setorAtual) && setores[setorAtual].Count > 0)
                    {
                        int setorDestino = setorAtual + 1;

                        // Verifica se o setor de destino tem espaço
                        if (!setores.ContainsKey(setorDestino) || setores[setorDestino].Count < 4)
                        {
                            // Escolhe o melhor personagem neste setor
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
                Console.WriteLine($"Erro em ProcessarPromocao: {ex.Message}");
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

                // Verifica se há uma nova carta no KingsMe (setor 10)
                if (setores.ContainsKey(10) && setores[10].Count > 0)
                {
                    string cartaReiAtual = setores[10][0];

                    // Resetar estado se é uma nova votação
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
                Console.WriteLine($"Erro em ProcessarVotacao: {ex.Message}");
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
        private void PromoverPersonagens()
        {
            try
            {
                // Primeiro sincroniza com o estado real do servidor
                SincronizarEstadoTabuleiro();

                int idJogador = Convert.ToInt32(txtIDjogador.Text);
                string senha = txtSenha.Text;

                // Lista de prioridade: tenta promover para o KingsMe primeiro
                if (setores.ContainsKey(5) && setores[5].Count > 0 &&
                    (!setores.ContainsKey(10) || setores[10].Count == 0))
                {
                    string personagem = setores[5][0];
                    string resultado = Jogo.Promover(idJogador, senha, personagem);

                    if (!resultado.StartsWith("ERRO:"))
                    {
                        lblControle.Text += $"Promovido para KingsMe: {personagem}\n";
                        return;
                    }
                }

                // Se não conseguiu promover para KingsMe, tenta promover nos outros setores
                for (int setorAtual = 1; setorAtual <= 4; setorAtual++)
                {
                    if (setores.ContainsKey(setorAtual) && setores[setorAtual].Count > 0)
                    {
                        int setorDestino = setorAtual + 1;

                        // Verifica se o setor de destino tem espaço
                        if (!setores.ContainsKey(setorDestino))
                            setores[setorDestino] = new List<string>();

                        if (setores[setorDestino].Count < 4)
                        {
                            string personagem = setores[setorAtual][0];
                            string resultado = Jogo.Promover(idJogador, senha, personagem);

                            if (!resultado.StartsWith("ERRO:"))
                            {
                                lblControle.Text += $"Promovido: {personagem} (Setor {setorAtual} -> {setorDestino})\n";
                                return;
                            }
                        }
                    }
                }

                lblControle.Text += "Nenhuma promoção possível no momento.\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em PromoverPersonagens: {ex.Message}");
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

                // Obter personagens já no tabuleiro diretamente do estado atual
                var estadoTabuleiro = EstadoAtualTabuleiro();
                var personagensNoTabuleiro = ObterPersonagensNoTabuleiro(estadoTabuleiro);

                // Debug: Mostrar personagens disponíveis
                Console.WriteLine("Todos os personagens: " + string.Join(",", todos));
                Console.WriteLine("Personagens no tabuleiro: " + string.Join(",", personagensNoTabuleiro));

                List<string> disponiveis = todos
                    .Where(p => !string.IsNullOrWhiteSpace(p))
                    .Select(p => p.Trim())
                    .Where(p => !personagensNoTabuleiro.Contains(p))
                    .ToList();

                // Debug: Mostrar personagens disponíveis após filtro
                Console.WriteLine("Personagens disponíveis: " + string.Join(",", disponiveis));

                if (disponiveis.Count == 0)
                {
                    Console.WriteLine("Nenhum personagem disponível para posicionar.");
                    return null;
                }

                // Seleção verdadeiramente aleatória
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

        // Método auxiliar para extrair personagens do tabuleiro
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
            // Durante a fase de setup, só permitir setores 1-4
            var setoresValidos = setores
                .Where(kv => kv.Key >= 1 && kv.Key <= 4)  // Apenas setores 1-4
                .Where(kv => kv.Value.Count < 4)          // Com espaço disponível
                .Select(kv => kv.Key)
                .ToList();

            if (setoresValidos.Count == 0)
                return -1;

            return setoresValidos[random.Next(setoresValidos.Count)];
        }

        private void PosicionarPersonagem(int idJogador, string senha, string personagem, int setor)
        {
            try
            {
                if (setor < 1 || setor > 4)
                {
                    Console.WriteLine($"Setor {setor} inválido para fase de setup.");
                    return;
                }

                // Verifica se o setor tem espaço
                if (setores.ContainsKey(setor) && setores[setor].Count >= 4)
                {
                    Console.WriteLine($"Setor {setor} já está cheio.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(personagem))
                {
                    personagem = EscolherMelhorPersonagemDisponivel();
                    if (personagem == null)
                    {
                        Console.WriteLine("Nenhum personagem disponível para posicionar.");
                        return;
                    }
                }

                string inicial = personagem.Substring(0, 1);
                string estadoAtual = Jogo.ColocarPersonagem(idJogador, senha, setor, inicial);

                if (estadoAtual.StartsWith("ERRO:"))
                {
                    Console.WriteLine($"Erro ao posicionar: {estadoAtual}");

                    // Tenta o próximo personagem disponível
                    string proximoPersonagem = EscolherMelhorPersonagemDisponivel();
                    if (proximoPersonagem != null && proximoPersonagem != personagem)
                    {
                        PosicionarPersonagem(idJogador, senha, proximoPersonagem, setor);
                    }
                    return;
                }

                // Atualiza as estruturas locais
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
                Console.WriteLine($"Erro em PosicionarPersonagem: {ex.Message}");
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
                Console.WriteLine($"Erro ao sincronizar tabuleiro: {ex.Message}");
            }
        }
        private string EscolherMelhorPersonagemDisponivel()
        {
            try
            {
                // Primeiro verifica nas cartas do jogador
                var cartasDisponiveis = minhasCartas
                    .Except(personagensColocados)
                    .OrderByDescending(c => rankingPersonagens.GetValueOrDefault(c, 0))
                    .ToList();

                if (cartasDisponiveis.Count > 0)
                {
                    return cartasDisponiveis.First();
                }

                // Se não tiver mais cartas nas mãos, verifica todas as cartas do jogo
                var todasCartas = rankingPersonagens.Keys.ToList();
                var todasDisponiveis = todasCartas
                    .Except(personagensColocados)
                    .OrderByDescending(c => rankingPersonagens.GetValueOrDefault(c, 0))
                    .ToList();

                return todasDisponiveis.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em EscolherMelhorPersonagemDisponivel: {ex.Message}");
                return null;
            }
        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }
    }
}