namespace Jogos.Labirinto {
    partial class TelaLabirinto {
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
            this.pnlLabirinto = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.opçõesDoJogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.pcbMouse = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLabirinto
            // 
            this.pnlLabirinto.CausesValidation = false;
            this.pnlLabirinto.Location = new System.Drawing.Point(124, 21);
            this.pnlLabirinto.Name = "pnlLabirinto";
            this.pnlLabirinto.Size = new System.Drawing.Size(550, 550);
            this.pnlLabirinto.TabIndex = 626;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Jogos.Labirinto.Properties.Resources.seta;
            this.pictureBox2.Location = new System.Drawing.Point(677, 524);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 28);
            this.pictureBox2.TabIndex = 628;
            this.pictureBox2.TabStop = false;
            // 
            // opçõesDoJogoToolStripMenuItem
            // 
            this.opçõesDoJogoToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.opçõesDoJogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarToolStripMenuItem});
            this.opçõesDoJogoToolStripMenuItem.Name = "opçõesDoJogoToolStripMenuItem";
            this.opçõesDoJogoToolStripMenuItem.Size = new System.Drawing.Size(104, 19);
            this.opçõesDoJogoToolStripMenuItem.Text = "Opções do Jogo";
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.iniciarToolStripMenuItem.Text = "Iniciar";
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.Black;
            this.lblMensagem.Location = new System.Drawing.Point(692, 552);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(81, 20);
            this.lblMensagem.TabIndex = 630;
            this.lblMensagem.Text = "Parabéns!";
            // 
            // pcbMouse
            // 
            this.pcbMouse.Image = global::Jogos.Labirinto.Properties.Resources.mouse;
            this.pcbMouse.Location = new System.Drawing.Point(722, 527);
            this.pcbMouse.Name = "pcbMouse";
            this.pcbMouse.Size = new System.Drawing.Size(22, 22);
            this.pcbMouse.TabIndex = 631;
            this.pcbMouse.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Jogos.Labirinto.Properties.Resources.seta;
            this.pictureBox1.Location = new System.Drawing.Point(82, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 28);
            this.pictureBox1.TabIndex = 627;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 48);
            this.label1.TabIndex = 632;
            this.label1.Text = "Clique\r\npara\r\nVoltar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TelaLabirinto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(798, 593);
            this.Controls.Add(this.pcbMouse);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlLabirinto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaLabirinto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rato no Labirinto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TelaLabirinto_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLabirinto;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem opçõesDoJogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.PictureBox pcbMouse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;


    }
}