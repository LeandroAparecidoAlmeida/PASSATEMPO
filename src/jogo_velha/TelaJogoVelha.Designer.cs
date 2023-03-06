namespace Jogos.JogoVelha {
    partial class TelaJogoVelha {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaJogoVelha));
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumPartida = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPontuacaoHumano = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPontuacaoComputador = new System.Windows.Forms.Label();
            this.timNovaPartida = new System.Windows.Forms.Timer(this.components);
            this.timTempoComputador = new System.Windows.Forms.Timer(this.components);
            this.pcbProcesso = new System.Windows.Forms.PictureBox();
            this.pcbPosicao9 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao8 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao7 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao6 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao5 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao4 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao3 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao2 = new System.Windows.Forms.PictureBox();
            this.pcbPosicao1 = new System.Windows.Forms.PictureBox();
            this.pcbTabuleiro = new System.Windows.Forms.PictureBox();
            this.pcbComputador = new System.Windows.Forms.PictureBox();
            this.pcbHumano = new System.Windows.Forms.PictureBox();
            this.timEfeitos = new System.Windows.Forms.Timer(this.components);
            this.lblNovaPartida = new System.Windows.Forms.Label();
            this.tbNivelDificuldade = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbProcesso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTabuleiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbComputador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHumano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNivelDificuldade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Name = "label1";
            // 
            // lblNumPartida
            // 
            resources.ApplyResources(this.lblNumPartida, "lblNumPartida");
            this.lblNumPartida.ForeColor = System.Drawing.Color.DimGray;
            this.lblNumPartida.Name = "lblNumPartida";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Name = "label3";
            // 
            // lblPontuacaoHumano
            // 
            resources.ApplyResources(this.lblPontuacaoHumano, "lblPontuacaoHumano");
            this.lblPontuacaoHumano.ForeColor = System.Drawing.Color.DimGray;
            this.lblPontuacaoHumano.Name = "lblPontuacaoHumano";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Name = "label5";
            // 
            // lblPontuacaoComputador
            // 
            resources.ApplyResources(this.lblPontuacaoComputador, "lblPontuacaoComputador");
            this.lblPontuacaoComputador.ForeColor = System.Drawing.Color.DimGray;
            this.lblPontuacaoComputador.Name = "lblPontuacaoComputador";
            // 
            // timNovaPartida
            // 
            this.timNovaPartida.Interval = 4000;
            this.timNovaPartida.Tick += new System.EventHandler(this.timNovaPartida_Tick);
            // 
            // timTempoComputador
            // 
            this.timTempoComputador.Interval = 1500;
            this.timTempoComputador.Tick += new System.EventHandler(this.timTempoComputador_Tick);
            // 
            // pcbProcesso
            // 
            resources.ApplyResources(this.pcbProcesso, "pcbProcesso");
            this.pcbProcesso.Name = "pcbProcesso";
            this.pcbProcesso.TabStop = false;
            // 
            // pcbPosicao9
            // 
            resources.ApplyResources(this.pcbPosicao9, "pcbPosicao9");
            this.pcbPosicao9.Name = "pcbPosicao9";
            this.pcbPosicao9.TabStop = false;
            this.pcbPosicao9.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao8
            // 
            resources.ApplyResources(this.pcbPosicao8, "pcbPosicao8");
            this.pcbPosicao8.Name = "pcbPosicao8";
            this.pcbPosicao8.TabStop = false;
            this.pcbPosicao8.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao7
            // 
            resources.ApplyResources(this.pcbPosicao7, "pcbPosicao7");
            this.pcbPosicao7.Name = "pcbPosicao7";
            this.pcbPosicao7.TabStop = false;
            this.pcbPosicao7.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao6
            // 
            resources.ApplyResources(this.pcbPosicao6, "pcbPosicao6");
            this.pcbPosicao6.Name = "pcbPosicao6";
            this.pcbPosicao6.TabStop = false;
            this.pcbPosicao6.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao5
            // 
            resources.ApplyResources(this.pcbPosicao5, "pcbPosicao5");
            this.pcbPosicao5.Name = "pcbPosicao5";
            this.pcbPosicao5.TabStop = false;
            this.pcbPosicao5.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao4
            // 
            resources.ApplyResources(this.pcbPosicao4, "pcbPosicao4");
            this.pcbPosicao4.Name = "pcbPosicao4";
            this.pcbPosicao4.TabStop = false;
            this.pcbPosicao4.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao3
            // 
            resources.ApplyResources(this.pcbPosicao3, "pcbPosicao3");
            this.pcbPosicao3.Name = "pcbPosicao3";
            this.pcbPosicao3.TabStop = false;
            this.pcbPosicao3.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao2
            // 
            resources.ApplyResources(this.pcbPosicao2, "pcbPosicao2");
            this.pcbPosicao2.Name = "pcbPosicao2";
            this.pcbPosicao2.TabStop = false;
            this.pcbPosicao2.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbPosicao1
            // 
            resources.ApplyResources(this.pcbPosicao1, "pcbPosicao1");
            this.pcbPosicao1.Name = "pcbPosicao1";
            this.pcbPosicao1.TabStop = false;
            this.pcbPosicao1.Click += new System.EventHandler(this.TabuleiroClick);
            // 
            // pcbTabuleiro
            // 
            resources.ApplyResources(this.pcbTabuleiro, "pcbTabuleiro");
            this.pcbTabuleiro.Name = "pcbTabuleiro";
            this.pcbTabuleiro.TabStop = false;
            // 
            // pcbComputador
            // 
            resources.ApplyResources(this.pcbComputador, "pcbComputador");
            this.pcbComputador.Name = "pcbComputador";
            this.pcbComputador.TabStop = false;
            // 
            // pcbHumano
            // 
            resources.ApplyResources(this.pcbHumano, "pcbHumano");
            this.pcbHumano.Name = "pcbHumano";
            this.pcbHumano.TabStop = false;
            // 
            // timEfeitos
            // 
            this.timEfeitos.Interval = 500;
            this.timEfeitos.Tick += new System.EventHandler(this.timEfeitos_Tick);
            // 
            // lblNovaPartida
            // 
            resources.ApplyResources(this.lblNovaPartida, "lblNovaPartida");
            this.lblNovaPartida.ForeColor = System.Drawing.Color.White;
            this.lblNovaPartida.Name = "lblNovaPartida";
            // 
            // tbNivelDificuldade
            // 
            resources.ApplyResources(this.tbNivelDificuldade, "tbNivelDificuldade");
            this.tbNivelDificuldade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbNivelDificuldade.Maximum = 3;
            this.tbNivelDificuldade.Minimum = 1;
            this.tbNivelDificuldade.Name = "tbNivelDificuldade";
            this.tbNivelDificuldade.Value = 1;
            this.tbNivelDificuldade.ValueChanged += new System.EventHandler(this.tbNivelDificuldade_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // TelaJogoVelha
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNivelDificuldade);
            this.Controls.Add(this.lblNovaPartida);
            this.Controls.Add(this.pcbPosicao9);
            this.Controls.Add(this.pcbPosicao8);
            this.Controls.Add(this.pcbPosicao7);
            this.Controls.Add(this.pcbPosicao6);
            this.Controls.Add(this.pcbPosicao5);
            this.Controls.Add(this.pcbPosicao4);
            this.Controls.Add(this.pcbPosicao3);
            this.Controls.Add(this.pcbPosicao2);
            this.Controls.Add(this.pcbPosicao1);
            this.Controls.Add(this.lblPontuacaoComputador);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPontuacaoHumano);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumPartida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbTabuleiro);
            this.Controls.Add(this.pcbHumano);
            this.Controls.Add(this.pcbProcesso);
            this.Controls.Add(this.pcbComputador);
            this.Name = "TelaJogoVelha";
            this.Tag = "1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pcbProcesso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPosicao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTabuleiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbComputador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHumano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNivelDificuldade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbHumano;
        private System.Windows.Forms.PictureBox pcbTabuleiro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumPartida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPontuacaoHumano;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPontuacaoComputador;
        private System.Windows.Forms.PictureBox pcbPosicao1;
        private System.Windows.Forms.PictureBox pcbPosicao2;
        private System.Windows.Forms.PictureBox pcbPosicao3;
        private System.Windows.Forms.PictureBox pcbPosicao4;
        private System.Windows.Forms.PictureBox pcbPosicao5;
        private System.Windows.Forms.PictureBox pcbPosicao6;
        private System.Windows.Forms.PictureBox pcbPosicao7;
        private System.Windows.Forms.PictureBox pcbPosicao8;
        private System.Windows.Forms.PictureBox pcbPosicao9;
        private System.Windows.Forms.PictureBox pcbComputador;
        private System.Windows.Forms.Timer timNovaPartida;
        private System.Windows.Forms.Timer timTempoComputador;
        private System.Windows.Forms.PictureBox pcbProcesso;
        private System.Windows.Forms.Timer timEfeitos;
        private System.Windows.Forms.Label lblNovaPartida;
        private System.Windows.Forms.TrackBar tbNivelDificuldade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;






    }
}