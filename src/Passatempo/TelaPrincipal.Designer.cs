namespace Jogos {
    partial class TelaPrincipal {
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mnSelecionarJogo = new System.Windows.Forms.ToolStripMenuItem();
            this.raciocínioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miJogoVelha = new System.Windows.Forms.ToolStripMenuItem();
            this.miJogoForca = new System.Windows.Forms.ToolStripMenuItem();
            this.miTorreHanoi = new System.Windows.Forms.ToolStripMenuItem();
            this.miRatoLabirinto = new System.Windows.Forms.ToolStripMenuItem();
            this.memóriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEncontrePares = new System.Windows.Forms.ToolStripMenuItem();
            this.miSuspeitoOculto = new System.Windows.Forms.ToolStripMenuItem();
            this.atençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNomesCores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvide = new System.Windows.Forms.HelpProvider();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSelecionarJogo,
            this.tsmAjuda});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.mnSelecionarJogo;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mnSelecionarJogo
            // 
            this.mnSelecionarJogo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raciocínioToolStripMenuItem,
            this.miJogoVelha,
            this.miJogoForca,
            this.miTorreHanoi,
            this.miRatoLabirinto,
            this.memóriaToolStripMenuItem,
            this.miEncontrePares,
            this.miSuspeitoOculto,
            this.atençãoToolStripMenuItem,
            this.miNomesCores});
            this.mnSelecionarJogo.Name = "mnSelecionarJogo";
            this.mnSelecionarJogo.Size = new System.Drawing.Size(101, 20);
            this.mnSelecionarJogo.Text = "Selecionar Jogo";
            // 
            // raciocínioToolStripMenuItem
            // 
            this.raciocínioToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.raciocínioToolStripMenuItem.Enabled = false;
            this.raciocínioToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raciocínioToolStripMenuItem.Name = "raciocínioToolStripMenuItem";
            this.raciocínioToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.raciocínioToolStripMenuItem.Tag = "1";
            this.raciocínioToolStripMenuItem.Text = "Raciocínio";
            // 
            // miJogoVelha
            // 
            this.miJogoVelha.ForeColor = System.Drawing.Color.Black;
            this.miJogoVelha.Name = "miJogoVelha";
            this.miJogoVelha.Size = new System.Drawing.Size(167, 22);
            this.miJogoVelha.Tag = "0";
            this.miJogoVelha.Text = "Jogo da Velha";
            this.miJogoVelha.Click += new System.EventHandler(this.miJogoVelha_Click);
            // 
            // miJogoForca
            // 
            this.miJogoForca.ForeColor = System.Drawing.Color.Black;
            this.miJogoForca.Name = "miJogoForca";
            this.miJogoForca.Size = new System.Drawing.Size(167, 22);
            this.miJogoForca.Tag = "0";
            this.miJogoForca.Text = "Jogo da Forca";
            this.miJogoForca.Click += new System.EventHandler(this.miJogoForca_Click);
            // 
            // miTorreHanoi
            // 
            this.miTorreHanoi.ForeColor = System.Drawing.Color.Black;
            this.miTorreHanoi.Name = "miTorreHanoi";
            this.miTorreHanoi.Size = new System.Drawing.Size(167, 22);
            this.miTorreHanoi.Tag = "0";
            this.miTorreHanoi.Text = "Torre de Hanói";
            this.miTorreHanoi.Click += new System.EventHandler(this.miTorreHanoi_Click);
            // 
            // miRatoLabirinto
            // 
            this.miRatoLabirinto.Name = "miRatoLabirinto";
            this.miRatoLabirinto.Size = new System.Drawing.Size(167, 22);
            this.miRatoLabirinto.Text = "Rato no Labirinto";
            this.miRatoLabirinto.Click += new System.EventHandler(this.miRatoLabirinto_Click);
            // 
            // memóriaToolStripMenuItem
            // 
            this.memóriaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.memóriaToolStripMenuItem.Enabled = false;
            this.memóriaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memóriaToolStripMenuItem.Name = "memóriaToolStripMenuItem";
            this.memóriaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.memóriaToolStripMenuItem.Tag = "1";
            this.memóriaToolStripMenuItem.Text = "Memória";
            // 
            // miEncontrePares
            // 
            this.miEncontrePares.ForeColor = System.Drawing.Color.Black;
            this.miEncontrePares.Name = "miEncontrePares";
            this.miEncontrePares.Size = new System.Drawing.Size(167, 22);
            this.miEncontrePares.Tag = "0";
            this.miEncontrePares.Text = "Encontre os Pares";
            this.miEncontrePares.Click += new System.EventHandler(this.miEncontrePares_Click);
            // 
            // miSuspeitoOculto
            // 
            this.miSuspeitoOculto.ForeColor = System.Drawing.Color.Black;
            this.miSuspeitoOculto.Name = "miSuspeitoOculto";
            this.miSuspeitoOculto.Size = new System.Drawing.Size(167, 22);
            this.miSuspeitoOculto.Tag = "0";
            this.miSuspeitoOculto.Text = "Suspeito Oculto";
            this.miSuspeitoOculto.Click += new System.EventHandler(this.miSuspeitoOculto_Click);
            // 
            // atençãoToolStripMenuItem
            // 
            this.atençãoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.atençãoToolStripMenuItem.Enabled = false;
            this.atençãoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atençãoToolStripMenuItem.Name = "atençãoToolStripMenuItem";
            this.atençãoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.atençãoToolStripMenuItem.Tag = "1";
            this.atençãoToolStripMenuItem.Text = "Atenção";
            // 
            // miNomesCores
            // 
            this.miNomesCores.ForeColor = System.Drawing.Color.Black;
            this.miNomesCores.Name = "miNomesCores";
            this.miNomesCores.Size = new System.Drawing.Size(167, 22);
            this.miNomesCores.Tag = "0";
            this.miNomesCores.Text = "Acerte a Cor";
            // 
            // tsmAjuda
            // 
            this.tsmAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAjuda,
            this.toolStripMenuItem1,
            this.miSobre});
            this.tsmAjuda.Name = "tsmAjuda";
            this.tsmAjuda.Size = new System.Drawing.Size(50, 20);
            this.tsmAjuda.Text = "Ajuda";
            // 
            // miAjuda
            // 
            this.miAjuda.Name = "miAjuda";
            this.miAjuda.Size = new System.Drawing.Size(105, 22);
            this.miAjuda.Text = "Ajuda";
            this.miAjuda.Click += new System.EventHandler(this.miAjuda_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 6);
            // 
            // miSobre
            // 
            this.miSobre.Name = "miSobre";
            this.miSobre.Size = new System.Drawing.Size(105, 22);
            this.miSobre.Text = "Sobre";
            this.miSobre.Click += new System.EventHandler(this.miSobre_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 624);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passatempo";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnSelecionarJogo;
        private System.Windows.Forms.ToolStripMenuItem miJogoVelha;
        private System.Windows.Forms.ToolStripMenuItem miJogoForca;
        private System.Windows.Forms.ToolStripMenuItem miEncontrePares;
        private System.Windows.Forms.ToolStripMenuItem miSuspeitoOculto;
        private System.Windows.Forms.ToolStripMenuItem miTorreHanoi;
        private System.Windows.Forms.ToolStripMenuItem miNomesCores;
        private System.Windows.Forms.ToolStripMenuItem raciocínioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memóriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atençãoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem miRatoLabirinto;
        private System.Windows.Forms.ToolStripMenuItem tsmAjuda;
        private System.Windows.Forms.ToolStripMenuItem miAjuda;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miSobre;
        private System.Windows.Forms.HelpProvider helpProvide;
    }
}



