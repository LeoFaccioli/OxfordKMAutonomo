namespace BOxford
{
    partial class Form1
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
            btnListarPartidas = new Button();
            lstPartidas = new ListBox();
            lblVersao = new Label();
            lblCriarNova = new Label();
            label2 = new Label();
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
            label4 = new Label();
            lblIDatual = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnListarPartidas
            // 
            btnListarPartidas.Location = new Point(557, 116);
            btnListarPartidas.Name = "btnListarPartidas";
            btnListarPartidas.Size = new Size(182, 23);
            btnListarPartidas.TabIndex = 0;
            btnListarPartidas.Text = "Listar Partidas";
            btnListarPartidas.UseVisualStyleBackColor = true;
            btnListarPartidas.Click += btnListarPartidas_Click;
            // 
            // lstPartidas
            // 
            lstPartidas.FormattingEnabled = true;
            lstPartidas.ItemHeight = 15;
            lstPartidas.Location = new Point(557, 145);
            lstPartidas.Name = "lstPartidas";
            lstPartidas.Size = new Size(366, 109);
            lstPartidas.TabIndex = 2;
            lstPartidas.SelectedIndexChanged += lstPartidas_SelectedIndexChanged;
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Location = new Point(949, 9);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(41, 15);
            lblVersao.TabIndex = 3;
            lblVersao.Text = "versão";
            // 
            // lblCriarNova
            // 
            lblCriarNova.AutoSize = true;
            lblCriarNova.Font = new Font("Segoe UI", 14.25F);
            lblCriarNova.Location = new Point(24, 82);
            lblCriarNova.Name = "lblCriarNova";
            lblCriarNova.Size = new Size(210, 25);
            lblCriarNova.TabIndex = 4;
            lblCriarNova.Text = "Criar uma nova partida:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 26);
            label2.Name = "label2";
            label2.Size = new Size(258, 40);
            label2.TabIndex = 5;
            label2.Text = "Barões de Oxford";
            // 
            // lblNomePartida
            // 
            lblNomePartida.AutoSize = true;
            lblNomePartida.Font = new Font("Segoe UI", 9F);
            lblNomePartida.Location = new Point(27, 117);
            lblNomePartida.Name = "lblNomePartida";
            lblNomePartida.Size = new Size(99, 15);
            lblNomePartida.TabIndex = 6;
            lblNomePartida.Text = "Nome da partida:";
            // 
            // lblSenhaPartida
            // 
            lblSenhaPartida.AutoSize = true;
            lblSenhaPartida.Font = new Font("Segoe UI", 9F);
            lblSenhaPartida.Location = new Point(28, 161);
            lblSenhaPartida.Name = "lblSenhaPartida";
            lblSenhaPartida.Size = new Size(98, 15);
            lblSenhaPartida.TabIndex = 7;
            lblSenhaPartida.Text = "Senha da partida:";
            // 
            // txtNomePartida
            // 
            txtNomePartida.Location = new Point(27, 135);
            txtNomePartida.Name = "txtNomePartida";
            txtNomePartida.Size = new Size(373, 23);
            txtNomePartida.TabIndex = 9;
            // 
            // txtNomeGrupo
            // 
            txtNomeGrupo.Location = new Point(27, 223);
            txtNomeGrupo.Name = "txtNomeGrupo";
            txtNomeGrupo.Size = new Size(373, 23);
            txtNomeGrupo.TabIndex = 10;
            // 
            // txtSenhaPartida
            // 
            txtSenhaPartida.Location = new Point(27, 179);
            txtSenhaPartida.Name = "txtSenhaPartida";
            txtSenhaPartida.Size = new Size(373, 23);
            txtSenhaPartida.TabIndex = 11;
            // 
            // cboFiltro
            // 
            cboFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltro.FormattingEnabled = true;
            cboFiltro.Location = new Point(784, 115);
            cboFiltro.Name = "cboFiltro";
            cboFiltro.Size = new Size(139, 23);
            cboFiltro.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDadosData);
            groupBox1.Controls.Add(lblDadosID);
            groupBox1.Controls.Add(lblDadosPartida);
            groupBox1.Location = new Point(557, 272);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 116);
            groupBox1.TabIndex = 14;
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
            lstJogadores.Location = new Point(557, 440);
            lstJogadores.Name = "lstJogadores";
            lstJogadores.Size = new Size(364, 154);
            lstJogadores.TabIndex = 15;
            lstJogadores.SelectedIndexChanged += lstJogadores_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(555, 412);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 16;
            label5.Text = "Jogadores:";
            // 
            // lblNomeGrupo
            // 
            lblNomeGrupo.AutoSize = true;
            lblNomeGrupo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNomeGrupo.Location = new Point(27, 205);
            lblNomeGrupo.Name = "lblNomeGrupo";
            lblNomeGrupo.Size = new Size(95, 15);
            lblNomeGrupo.TabIndex = 17;
            lblNomeGrupo.Text = "Nome do grupo:";
            // 
            // btnCriarPartida
            // 
            btnCriarPartida.Location = new Point(27, 253);
            btnCriarPartida.Name = "btnCriarPartida";
            btnCriarPartida.Size = new Size(375, 23);
            btnCriarPartida.TabIndex = 20;
            btnCriarPartida.Text = "Criar";
            btnCriarPartida.UseVisualStyleBackColor = true;
            btnCriarPartida.Click += btnCriarPartida_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(559, 82);
            label4.Name = "label4";
            label4.Size = new Size(171, 25);
            label4.TabIndex = 26;
            label4.Text = "Partidas existentes:";
            // 
            // lblIDatual
            // 
            lblIDatual.AutoSize = true;
            lblIDatual.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIDatual.Location = new Point(28, 289);
            lblIDatual.Name = "lblIDatual";
            lblIDatual.Size = new Size(102, 21);
            lblIDatual.TabIndex = 27;
            lblIDatual.Text = "ID da partida:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 645);
            Controls.Add(lblIDatual);
            Controls.Add(label4);
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
            Controls.Add(label2);
            Controls.Add(lblCriarNova);
            Controls.Add(lblVersao);
            Controls.Add(lstPartidas);
            Controls.Add(btnListarPartidas);
            Name = "Form1";
            Text = "King Me - Lobby";
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
        private Label label2;
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
        private Label label4;
        private Label lblIDatual;
        private Label lblDadosData;
        private Label lblDadosID;
        private Label lblDadosPartida;
    }
}
