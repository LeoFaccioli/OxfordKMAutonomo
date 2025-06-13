namespace BOxford
{
    partial class Lobby
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            btnListarPartidas = new Button();
            lstPartidas = new ListBox();
            lblVersao = new Label();
            lblCriarNova = new Label();
            lblNomePartida = new Label();
            lblSenhaPartida = new Label();
            txtNomePartida = new TextBox();
            txtNomeGrupo = new TextBox();
            txtSenhaPartida = new TextBox();
            cboFiltro = new ComboBox();
            groupBox1 = new GroupBox();
            lblDadosData = new Label();
            lblDadosID = new Label();
            lblDadosPartida = new Label();
            lstJogadores = new ListBox();
            label5 = new Label();
            lblNomeGrupo = new Label();
            btnCriarPartida = new Button();
            lblIDatual = new Label();
            lblLobby = new Label();
            lblNomeJogador = new Label();
            txtNomeJogador = new TextBox();
            btnEntrarPartida = new Button();
            lblIdJogador = new Label();
            lblSenhaJogador = new Label();
            txtIDpartida = new TextBox();
            txtIDjogador = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtSenha = new TextBox();
            btnIniciarPartida = new Button();
            btnExibirCartas = new Button();
            lblCartas = new Label();
            txtPersonagemSelecionado = new TextBox();
            txtPersonagemSetor = new TextBox();
            lblPersonagemAPosicionar = new Label();
            lblPersonagemSetor = new Label();
            btnPosicionarPersonagem = new Button();
            btnVerificarVez = new Button();
            lstPersonagens = new ListBox();
            lstSetores = new ListBox();
            lblIdVez = new Label();
            lblNomeVez = new Label();
            btnNovoLobby = new Button();
            lblTabuleiro = new Label();
            panel1 = new Panel();
            btnPromoverPersonagem = new Button();
            lblerro = new Label();
            tmrVerificaVez = new System.Windows.Forms.Timer(components);
            lblControle = new Label();
            lblStatus = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnListarPartidas
            // 
            btnListarPartidas.Location = new Point(213, 251);
            btnListarPartidas.Name = "btnListarPartidas";
            btnListarPartidas.Size = new Size(105, 23);
            btnListarPartidas.TabIndex = 4;
            btnListarPartidas.Text = "Listar Partidas";
            btnListarPartidas.UseVisualStyleBackColor = true;
            btnListarPartidas.Click += btnListarPartidas_Click;
            // 
            // lstPartidas
            // 
            lstPartidas.FormattingEnabled = true;
            lstPartidas.ItemHeight = 15;
            lstPartidas.Location = new Point(213, 280);
            lstPartidas.Name = "lstPartidas";
            lstPartidas.Size = new Size(224, 109);
            lstPartidas.TabIndex = 6;
            lstPartidas.SelectedIndexChanged += lstPartidas_SelectedIndexChanged;
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Location = new Point(1243, 672);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(41, 15);
            lblVersao.TabIndex = 3;
            lblVersao.Text = "versão";
            // 
            // lblCriarNova
            // 
            lblCriarNova.AutoSize = true;
            lblCriarNova.Font = new Font("Segoe UI", 14.25F);
            lblCriarNova.Location = new Point(24, 49);
            lblCriarNova.Name = "lblCriarNova";
            lblCriarNova.Size = new Size(210, 25);
            lblCriarNova.TabIndex = 4;
            lblCriarNova.Text = "Criar uma nova partida:";
            // 
            // lblNomePartida
            // 
            lblNomePartida.AutoSize = true;
            lblNomePartida.Font = new Font("Segoe UI", 9F);
            lblNomePartida.Location = new Point(27, 84);
            lblNomePartida.Name = "lblNomePartida";
            lblNomePartida.Size = new Size(99, 15);
            lblNomePartida.TabIndex = 6;
            lblNomePartida.Text = "Nome da partida:";
            // 
            // lblSenhaPartida
            // 
            lblSenhaPartida.AutoSize = true;
            lblSenhaPartida.Font = new Font("Segoe UI", 9F);
            lblSenhaPartida.Location = new Point(27, 128);
            lblSenhaPartida.Name = "lblSenhaPartida";
            lblSenhaPartida.Size = new Size(98, 15);
            lblSenhaPartida.TabIndex = 7;
            lblSenhaPartida.Text = "Senha da partida:";
            // 
            // txtNomePartida
            // 
            txtNomePartida.Location = new Point(27, 102);
            txtNomePartida.Name = "txtNomePartida";
            txtNomePartida.Size = new Size(165, 23);
            txtNomePartida.TabIndex = 0;
            // 
            // txtNomeGrupo
            // 
            txtNomeGrupo.Location = new Point(27, 190);
            txtNomeGrupo.Name = "txtNomeGrupo";
            txtNomeGrupo.ReadOnly = true;
            txtNomeGrupo.Size = new Size(165, 23);
            txtNomeGrupo.TabIndex = 2;
            txtNomeGrupo.Text = "Barões de Oxford";
            // 
            // txtSenhaPartida
            // 
            txtSenhaPartida.Location = new Point(27, 146);
            txtSenhaPartida.Name = "txtSenhaPartida";
            txtSenhaPartida.Size = new Size(165, 23);
            txtSenhaPartida.TabIndex = 1;
            // 
            // cboFiltro
            // 
            cboFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltro.FormattingEnabled = true;
            cboFiltro.Location = new Point(345, 251);
            cboFiltro.Name = "cboFiltro";
            cboFiltro.Size = new Size(92, 23);
            cboFiltro.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDadosData);
            groupBox1.Controls.Add(lblDadosID);
            groupBox1.Controls.Add(lblDadosPartida);
            groupBox1.Location = new Point(213, 408);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(224, 116);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados da partida:";
            // 
            // lblDadosData
            // 
            lblDadosData.AutoSize = true;
            lblDadosData.Location = new Point(6, 81);
            lblDadosData.Name = "lblDadosData";
            lblDadosData.Size = new Size(34, 15);
            lblDadosData.TabIndex = 2;
            lblDadosData.Text = "Data:";
            // 
            // lblDadosID
            // 
            lblDadosID.AutoSize = true;
            lblDadosID.Location = new Point(6, 23);
            lblDadosID.Name = "lblDadosID";
            lblDadosID.Size = new Size(21, 15);
            lblDadosID.TabIndex = 1;
            lblDadosID.Text = "ID:";
            // 
            // lblDadosPartida
            // 
            lblDadosPartida.AutoSize = true;
            lblDadosPartida.Location = new Point(6, 51);
            lblDadosPartida.Name = "lblDadosPartida";
            lblDadosPartida.Size = new Size(99, 15);
            lblDadosPartida.TabIndex = 0;
            lblDadosPartida.Text = "Nome da partida:";
            // 
            // lstJogadores
            // 
            lstJogadores.FormattingEnabled = true;
            lstJogadores.ItemHeight = 15;
            lstJogadores.Location = new Point(27, 488);
            lstJogadores.Name = "lstJogadores";
            lstJogadores.Size = new Size(161, 79);
            lstJogadores.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 460);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 8;
            label5.Text = "Jogadores:";
            // 
            // lblNomeGrupo
            // 
            lblNomeGrupo.AutoSize = true;
            lblNomeGrupo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNomeGrupo.Location = new Point(27, 172);
            lblNomeGrupo.Name = "lblNomeGrupo";
            lblNomeGrupo.Size = new Size(95, 15);
            lblNomeGrupo.TabIndex = 17;
            lblNomeGrupo.Text = "Nome do grupo:";
            // 
            // btnCriarPartida
            // 
            btnCriarPartida.Location = new Point(27, 269);
            btnCriarPartida.Name = "btnCriarPartida";
            btnCriarPartida.Size = new Size(167, 23);
            btnCriarPartida.TabIndex = 3;
            btnCriarPartida.Text = "Criar";
            btnCriarPartida.UseVisualStyleBackColor = true;
            btnCriarPartida.Click += btnCriarPartida_Click;
            // 
            // lblIDatual
            // 
            lblIDatual.AutoSize = true;
            lblIDatual.Font = new Font("Segoe UI", 9F);
            lblIDatual.Location = new Point(27, 219);
            lblIDatual.Name = "lblIDatual";
            lblIDatual.Size = new Size(77, 15);
            lblIDatual.TabIndex = 27;
            lblIDatual.Text = "ID da partida:";
            // 
            // lblLobby
            // 
            lblLobby.AutoSize = true;
            lblLobby.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLobby.Location = new Point(24, 9);
            lblLobby.Name = "lblLobby";
            lblLobby.Size = new Size(80, 32);
            lblLobby.TabIndex = 28;
            lblLobby.Text = "Lobby";
            // 
            // lblNomeJogador
            // 
            lblNomeJogador.AutoSize = true;
            lblNomeJogador.Location = new Point(27, 305);
            lblNomeJogador.Name = "lblNomeJogador";
            lblNomeJogador.Size = new Size(105, 15);
            lblNomeJogador.TabIndex = 29;
            lblNomeJogador.Text = "Nome do Jogador:";
            // 
            // txtNomeJogador
            // 
            txtNomeJogador.Location = new Point(27, 323);
            txtNomeJogador.Name = "txtNomeJogador";
            txtNomeJogador.Size = new Size(164, 23);
            txtNomeJogador.TabIndex = 30;
            // 
            // btnEntrarPartida
            // 
            btnEntrarPartida.Location = new Point(27, 363);
            btnEntrarPartida.Name = "btnEntrarPartida";
            btnEntrarPartida.Size = new Size(106, 35);
            btnEntrarPartida.TabIndex = 31;
            btnEntrarPartida.Text = "Entrar na Partida";
            btnEntrarPartida.UseVisualStyleBackColor = true;
            btnEntrarPartida.Click += btnEntrarPartida_Click;
            // 
            // lblIdJogador
            // 
            lblIdJogador.AutoSize = true;
            lblIdJogador.Location = new Point(30, 407);
            lblIdJogador.Name = "lblIdJogador";
            lblIdJogador.Size = new Size(79, 15);
            lblIdJogador.TabIndex = 32;
            lblIdJogador.Text = "ID do jogador";
            // 
            // lblSenhaJogador
            // 
            lblSenhaJogador.AutoSize = true;
            lblSenhaJogador.Location = new Point(30, 430);
            lblSenhaJogador.Name = "lblSenhaJogador";
            lblSenhaJogador.Size = new Size(39, 15);
            lblSenhaJogador.TabIndex = 33;
            lblSenhaJogador.Text = "Senha";
            // 
            // txtIDpartida
            // 
            txtIDpartida.Location = new Point(30, 239);
            txtIDpartida.Name = "txtIDpartida";
            txtIDpartida.Size = new Size(164, 23);
            txtIDpartida.TabIndex = 34;
            // 
            // txtIDjogador
            // 
            txtIDjogador.Location = new Point(213, 103);
            txtIDjogador.Name = "txtIDjogador";
            txtIDjogador.Size = new Size(224, 23);
            txtIDjogador.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(213, 85);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 36;
            label1.Text = "ID Jogador";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(213, 129);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 37;
            label2.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(213, 147);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(224, 23);
            txtSenha.TabIndex = 38;
            // 
            // btnIniciarPartida
            // 
            btnIniciarPartida.Location = new Point(213, 178);
            btnIniciarPartida.Name = "btnIniciarPartida";
            btnIniciarPartida.Size = new Size(224, 23);
            btnIniciarPartida.TabIndex = 39;
            btnIniciarPartida.Text = "Iniciar jogo";
            btnIniciarPartida.UseVisualStyleBackColor = true;
            btnIniciarPartida.Click += btnIniciarPartida_Click;
            // 
            // btnExibirCartas
            // 
            btnExibirCartas.Location = new Point(869, 38);
            btnExibirCartas.Name = "btnExibirCartas";
            btnExibirCartas.Size = new Size(75, 53);
            btnExibirCartas.TabIndex = 40;
            btnExibirCartas.Text = "Exibir cartas";
            btnExibirCartas.UseVisualStyleBackColor = true;
            btnExibirCartas.Click += btnExibirCartas_Click;
            // 
            // lblCartas
            // 
            lblCartas.AutoSize = true;
            lblCartas.Location = new Point(869, 94);
            lblCartas.Name = "lblCartas";
            lblCartas.Size = new Size(83, 15);
            lblCartas.TabIndex = 41;
            lblCartas.Text = "Minhas cartas:";
            // 
            // txtPersonagemSelecionado
            // 
            txtPersonagemSelecionado.Location = new Point(869, 293);
            txtPersonagemSelecionado.Name = "txtPersonagemSelecionado";
            txtPersonagemSelecionado.Size = new Size(138, 23);
            txtPersonagemSelecionado.TabIndex = 43;
            txtPersonagemSelecionado.Visible = false;
            // 
            // txtPersonagemSetor
            // 
            txtPersonagemSetor.Location = new Point(869, 338);
            txtPersonagemSetor.Name = "txtPersonagemSetor";
            txtPersonagemSetor.Size = new Size(138, 23);
            txtPersonagemSetor.TabIndex = 44;
            txtPersonagemSetor.Visible = false;
            // 
            // lblPersonagemAPosicionar
            // 
            lblPersonagemAPosicionar.AutoSize = true;
            lblPersonagemAPosicionar.Location = new Point(869, 275);
            lblPersonagemAPosicionar.Name = "lblPersonagemAPosicionar";
            lblPersonagemAPosicionar.Size = new Size(73, 15);
            lblPersonagemAPosicionar.TabIndex = 45;
            lblPersonagemAPosicionar.Text = "Personagem";
            lblPersonagemAPosicionar.Visible = false;
            // 
            // lblPersonagemSetor
            // 
            lblPersonagemSetor.AutoSize = true;
            lblPersonagemSetor.Location = new Point(869, 320);
            lblPersonagemSetor.Name = "lblPersonagemSetor";
            lblPersonagemSetor.Size = new Size(34, 15);
            lblPersonagemSetor.TabIndex = 46;
            lblPersonagemSetor.Text = "Setor";
            lblPersonagemSetor.Visible = false;
            // 
            // btnPosicionarPersonagem
            // 
            btnPosicionarPersonagem.Location = new Point(869, 368);
            btnPosicionarPersonagem.Name = "btnPosicionarPersonagem";
            btnPosicionarPersonagem.Size = new Size(138, 23);
            btnPosicionarPersonagem.TabIndex = 47;
            btnPosicionarPersonagem.Text = "Posicionar";
            btnPosicionarPersonagem.UseVisualStyleBackColor = true;
            btnPosicionarPersonagem.Visible = false;
            btnPosicionarPersonagem.Click += btnPosicionarPersonagem_Click;
            // 
            // btnVerificarVez
            // 
            btnVerificarVez.Location = new Point(1101, 35);
            btnVerificarVez.Name = "btnVerificarVez";
            btnVerificarVez.Size = new Size(100, 45);
            btnVerificarVez.TabIndex = 48;
            btnVerificarVez.Text = "Verificar Vez";
            btnVerificarVez.UseVisualStyleBackColor = true;
            btnVerificarVez.Click += btnVerificarVez_Click;
            // 
            // lstPersonagens
            // 
            lstPersonagens.ItemHeight = 15;
            lstPersonagens.Location = new Point(903, 460);
            lstPersonagens.Name = "lstPersonagens";
            lstPersonagens.Size = new Size(138, 229);
            lstPersonagens.TabIndex = 56;
            // 
            // lstSetores
            // 
            lstSetores.FormattingEnabled = true;
            lstSetores.ItemHeight = 15;
            lstSetores.Location = new Point(1061, 460);
            lstSetores.Name = "lstSetores";
            lstSetores.Size = new Size(140, 229);
            lstSetores.TabIndex = 51;
            // 
            // lblIdVez
            // 
            lblIdVez.AutoSize = true;
            lblIdVez.Location = new Point(1101, 83);
            lblIdVez.Name = "lblIdVez";
            lblIdVez.Size = new Size(17, 15);
            lblIdVez.TabIndex = 52;
            lblIdVez.Text = "Id";
            // 
            // lblNomeVez
            // 
            lblNomeVez.AutoSize = true;
            lblNomeVez.Location = new Point(1101, 102);
            lblNomeVez.Name = "lblNomeVez";
            lblNomeVez.Size = new Size(49, 15);
            lblNomeVez.TabIndex = 53;
            lblNomeVez.Text = "Jogador";
            // 
            // btnNovoLobby
            // 
            btnNovoLobby.Location = new Point(110, 16);
            btnNovoLobby.Name = "btnNovoLobby";
            btnNovoLobby.Size = new Size(23, 23);
            btnNovoLobby.TabIndex = 54;
            btnNovoLobby.Text = "+";
            btnNovoLobby.UseVisualStyleBackColor = true;
            btnNovoLobby.Click += btnNovoLobby_Click;
            // 
            // lblTabuleiro
            // 
            lblTabuleiro.AutoSize = true;
            lblTabuleiro.Location = new Point(1218, 91);
            lblTabuleiro.Name = "lblTabuleiro";
            lblTabuleiro.Size = new Size(0, 15);
            lblTabuleiro.TabIndex = 55;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Location = new Point(471, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(377, 550);
            panel1.TabIndex = 56;
            // 
            // btnPromoverPersonagem
            // 
            btnPromoverPersonagem.Location = new Point(869, 408);
            btnPromoverPersonagem.Name = "btnPromoverPersonagem";
            btnPromoverPersonagem.Size = new Size(138, 23);
            btnPromoverPersonagem.TabIndex = 58;
            btnPromoverPersonagem.Text = "Promover";
            btnPromoverPersonagem.UseVisualStyleBackColor = true;
            btnPromoverPersonagem.Visible = false;
            btnPromoverPersonagem.Click += btnPromoverPersonagem_Click;
            // 
            // lblerro
            // 
            lblerro.AutoSize = true;
            lblerro.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblerro.ForeColor = Color.Red;
            lblerro.Location = new Point(471, 35);
            lblerro.Name = "lblerro";
            lblerro.Size = new Size(0, 21);
            lblerro.TabIndex = 42;
            // 
            // tmrVerificaVez
            // 
            tmrVerificaVez.Enabled = true;
            tmrVerificaVez.Interval = 5000;
            tmrVerificaVez.Tick += tmrVerificaVez_Tick;
            // 
            // lblControle
            // 
            lblControle.AutoSize = true;
            lblControle.Location = new Point(1050, 146);
            lblControle.Name = "lblControle";
            lblControle.Size = new Size(20, 15);
            lblControle.TabIndex = 59;
            lblControle.Text = "Pe";
            lblControle.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(476, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 60;
            // 
            // Lobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 696);
            Controls.Add(lblStatus);
            Controls.Add(lblControle);
            Controls.Add(btnPromoverPersonagem);
            Controls.Add(lblTabuleiro);
            Controls.Add(btnNovoLobby);
            Controls.Add(lblNomeVez);
            Controls.Add(lblIdVez);
            Controls.Add(lstSetores);
            Controls.Add(lstPersonagens);
            Controls.Add(btnVerificarVez);
            Controls.Add(btnPosicionarPersonagem);
            Controls.Add(lblPersonagemSetor);
            Controls.Add(lblPersonagemAPosicionar);
            Controls.Add(txtPersonagemSetor);
            Controls.Add(txtPersonagemSelecionado);
            Controls.Add(lblerro);
            Controls.Add(lblCartas);
            Controls.Add(btnExibirCartas);
            Controls.Add(btnIniciarPartida);
            Controls.Add(txtSenha);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtIDjogador);
            Controls.Add(txtIDpartida);
            Controls.Add(lblSenhaJogador);
            Controls.Add(lblIdJogador);
            Controls.Add(btnEntrarPartida);
            Controls.Add(txtNomeJogador);
            Controls.Add(lblNomeJogador);
            Controls.Add(lblLobby);
            Controls.Add(lblIDatual);
            Controls.Add(btnCriarPartida);
            Controls.Add(lblNomeGrupo);
            Controls.Add(label5);
            Controls.Add(lstJogadores);
            Controls.Add(groupBox1);
            Controls.Add(cboFiltro);
            Controls.Add(txtSenhaPartida);
            Controls.Add(txtNomeGrupo);
            Controls.Add(txtNomePartida);
            Controls.Add(lblSenhaPartida);
            Controls.Add(lblNomePartida);
            Controls.Add(lblCriarNova);
            Controls.Add(lblVersao);
            Controls.Add(lstPartidas);
            Controls.Add(btnListarPartidas);
            Controls.Add(panel1);
            Name = "Lobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "King Me - Lobby";
            Load += Lobby_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListarPartidas;
        private ListBox lstPartidas;
        private Label lblVersao;
        private Label lblCriarNova;
        private Label lblNomePartida;
        private Label lblSenhaPartida;
        private TextBox txtNomePartida;
        private TextBox txtNomeGrupo;
        private TextBox txtSenhaPartida;
        private ComboBox cboFiltro;
        private GroupBox groupBox1;
        private ListBox lstJogadores;
        private Label label5;
        private Label lblNomeGrupo;
        private Button btnCriarPartida;
        private Label lblIDatual;
        private Label lblDadosData;
        private Label lblDadosID;
        private Label lblDadosPartida;
        private Label lblLobby;
        private Label lblNomeJogador;
        private TextBox txtNomeJogador;
        private Button btnEntrarPartida;
        private Label lblIdJogador;
        private Label lblSenhaJogador;
        private TextBox txtIDpartida;
        private TextBox txtIDjogador;
        private Label label1;
        private Label label2;
        private TextBox txtSenha;
        private Button btnIniciarPartida;
        private Button btnExibirCartas;
        private Label lblCartas;
        private TextBox txtPersonagemSelecionado;
        private TextBox txtPersonagemSetor;
        private Label lblPersonagemAPosicionar;
        private Label lblPersonagemSetor;
        private Button btnPosicionarPersonagem;
        private Button btnVerificarVez;
        private ListBox lstPersonagens;
        private ListBox lstSetores;
        private Label lblIdVez;
        private Label lblNomeVez;
        private Button btnNovoLobby;
        private Label lblTabuleiro;
        private Panel panel1;
        private Button btnPromoverPersonagem;
        private Label lblerro;
        private System.Windows.Forms.Timer tmrVerificaVez;
        private Label lblControle;
        private Label lblStatus;
    }
}
