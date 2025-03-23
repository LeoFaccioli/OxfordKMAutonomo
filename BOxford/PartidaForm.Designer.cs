namespace BOxford
{
    partial class PartidaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartidaForm));
            btnVoltarLobby = new Button();
            lblCartas = new Label();
            btnExibirCartas = new Button();
            btnIniciarPartida = new Button();
            txtSenha = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtIDjogador = new TextBox();
            lblNomeVez = new Label();
            lblIdVez = new Label();
            lstSetores = new ListBox();
            lstPersonagens = new ListBox();
            btnVerificarVez = new Button();
            btnPosicionarPersonagem = new Button();
            lblPersonagemSetor = new Label();
            lblPersonagemAPosicionar = new Label();
            txtPersonagemSetor = new TextBox();
            txtPersonagemSelecionado = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            lblErro = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // btnVoltarLobby
            // 
            btnVoltarLobby.Location = new Point(26, 12);
            btnVoltarLobby.Name = "btnVoltarLobby";
            btnVoltarLobby.Size = new Size(165, 26);
            btnVoltarLobby.TabIndex = 0;
            btnVoltarLobby.Text = "Voltar para o lobby";
            btnVoltarLobby.UseVisualStyleBackColor = true;
            btnVoltarLobby.Click += btnVoltarLobby_Click;
            // 
            // lblCartas
            // 
            lblCartas.AutoSize = true;
            lblCartas.Location = new Point(113, 342);
            lblCartas.Name = "lblCartas";
            lblCartas.Size = new Size(83, 15);
            lblCartas.TabIndex = 48;
            lblCartas.Text = "Minhas cartas:";
            // 
            // btnExibirCartas
            // 
            btnExibirCartas.Location = new Point(26, 342);
            btnExibirCartas.Name = "btnExibirCartas";
            btnExibirCartas.Size = new Size(75, 53);
            btnExibirCartas.TabIndex = 47;
            btnExibirCartas.Text = "Exibir cartas";
            btnExibirCartas.UseVisualStyleBackColor = true;
            // 
            // btnIniciarPartida
            // 
            btnIniciarPartida.Location = new Point(26, 212);
            btnIniciarPartida.Name = "btnIniciarPartida";
            btnIniciarPartida.Size = new Size(170, 23);
            btnIniciarPartida.TabIndex = 46;
            btnIniciarPartida.Text = "Iniciar jogo";
            btnIniciarPartida.UseVisualStyleBackColor = true;
            btnIniciarPartida.Click += btnIniciarPartida_Click;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(26, 181);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(170, 23);
            txtSenha.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(26, 163);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 44;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(26, 119);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 43;
            label1.Text = "ID Jogador";
            // 
            // txtIDjogador
            // 
            txtIDjogador.Location = new Point(26, 137);
            txtIDjogador.Name = "txtIDjogador";
            txtIDjogador.Size = new Size(170, 23);
            txtIDjogador.TabIndex = 42;
            // 
            // lblNomeVez
            // 
            lblNomeVez.AutoSize = true;
            lblNomeVez.Location = new Point(926, 220);
            lblNomeVez.Name = "lblNomeVez";
            lblNomeVez.Size = new Size(49, 15);
            lblNomeVez.TabIndex = 63;
            lblNomeVez.Text = "Jogador";
            // 
            // lblIdVez
            // 
            lblIdVez.AutoSize = true;
            lblIdVez.Location = new Point(926, 205);
            lblIdVez.Name = "lblIdVez";
            lblIdVez.Size = new Size(17, 15);
            lblIdVez.TabIndex = 62;
            lblIdVez.Text = "Id";
            // 
            // lstSetores
            // 
            lstSetores.FormattingEnabled = true;
            lstSetores.ItemHeight = 15;
            lstSetores.Location = new Point(926, 286);
            lstSetores.Name = "lstSetores";
            lstSetores.Size = new Size(140, 229);
            lstSetores.TabIndex = 61;
            // 
            // lstPersonagens
            // 
            lstPersonagens.FormattingEnabled = true;
            lstPersonagens.ItemHeight = 15;
            lstPersonagens.Location = new Point(768, 286);
            lstPersonagens.Name = "lstPersonagens";
            lstPersonagens.Size = new Size(140, 229);
            lstPersonagens.TabIndex = 60;
            // 
            // btnVerificarVez
            // 
            btnVerificarVez.Location = new Point(810, 198);
            btnVerificarVez.Name = "btnVerificarVez";
            btnVerificarVez.Size = new Size(100, 45);
            btnVerificarVez.TabIndex = 59;
            btnVerificarVez.Text = "Verificar Vez";
            btnVerificarVez.UseVisualStyleBackColor = true;
            btnVerificarVez.Click += btnVerificarVez_Click;
            // 
            // btnPosicionarPersonagem
            // 
            btnPosicionarPersonagem.Location = new Point(926, 90);
            btnPosicionarPersonagem.Name = "btnPosicionarPersonagem";
            btnPosicionarPersonagem.Size = new Size(82, 72);
            btnPosicionarPersonagem.TabIndex = 58;
            btnPosicionarPersonagem.Text = "Posicionar Personagem";
            btnPosicionarPersonagem.UseVisualStyleBackColor = true;
            btnPosicionarPersonagem.Click += btnPosicionarPersonagem_Click;
            // 
            // lblPersonagemSetor
            // 
            lblPersonagemSetor.AutoSize = true;
            lblPersonagemSetor.Location = new Point(810, 119);
            lblPersonagemSetor.Name = "lblPersonagemSetor";
            lblPersonagemSetor.Size = new Size(34, 15);
            lblPersonagemSetor.TabIndex = 57;
            lblPersonagemSetor.Text = "Setor";
            // 
            // lblPersonagemAPosicionar
            // 
            lblPersonagemAPosicionar.AutoSize = true;
            lblPersonagemAPosicionar.Location = new Point(810, 75);
            lblPersonagemAPosicionar.Name = "lblPersonagemAPosicionar";
            lblPersonagemAPosicionar.Size = new Size(73, 15);
            lblPersonagemAPosicionar.TabIndex = 56;
            lblPersonagemAPosicionar.Text = "Personagem";
            // 
            // txtPersonagemSetor
            // 
            txtPersonagemSetor.Location = new Point(810, 137);
            txtPersonagemSetor.Name = "txtPersonagemSetor";
            txtPersonagemSetor.Size = new Size(100, 23);
            txtPersonagemSetor.TabIndex = 55;
            // 
            // txtPersonagemSelecionado
            // 
            txtPersonagemSelecionado.Location = new Point(810, 93);
            txtPersonagemSelecionado.Name = "txtPersonagemSelecionado";
            txtPersonagemSelecionado.Size = new Size(100, 23);
            txtPersonagemSelecionado.TabIndex = 54;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(307, 22);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(376, 82);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 66;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(307, 110);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(376, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 69;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(307, 198);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(376, 82);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 70;
            pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(307, 286);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(376, 82);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 71;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(307, 374);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(376, 82);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 72;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(307, 462);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(376, 82);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 73;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(307, 550);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(376, 82);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 74;
            pictureBox7.TabStop = false;
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.Location = new Point(26, 238);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(28, 15);
            lblErro.TabIndex = 75;
            lblErro.Text = "Erro";
            // 
            // PartidaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 661);
            Controls.Add(lblErro);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
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
            Controls.Add(lblCartas);
            Controls.Add(btnExibirCartas);
            Controls.Add(btnIniciarPartida);
            Controls.Add(txtSenha);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtIDjogador);
            Controls.Add(btnVoltarLobby);
            Name = "PartidaForm";
            Text = "PartidaForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVoltarLobby;
        private Label lblCartas;
        private Button btnExibirCartas;
        private Button btnIniciarPartida;
        private TextBox txtSenha;
        private Label label2;
        private Label label1;
        private TextBox txtIDjogador;
        private Label lblNomeVez;
        private Label lblIdVez;
        private ListBox lstSetores;
        private ListBox lstPersonagens;
        private Button btnVerificarVez;
        private Button btnPosicionarPersonagem;
        private Label lblPersonagemSetor;
        private Label lblPersonagemAPosicionar;
        private TextBox txtPersonagemSetor;
        private TextBox txtPersonagemSelecionado;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private Label lblErro;
    }
}