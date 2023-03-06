using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jogos.Classes;
using Jogos.JogoVelha;
using Jogos.JogoForca;
using Jogos.EncontrePares;
using Jogos.SuspeitoOculto;
using Jogos.Labirinto;
using Jogos.TorreHanoi;
using System.Threading;

namespace Jogos {

    public partial class TelaPrincipal : Form {

        public TelaPrincipal() {
            InitializeComponent();
            helpProvide.HelpNamespace = Application.StartupPath + @"\passatempo.chm";
            helpProvide.SetHelpKeyword(this, Keys.F1.ToString());
        }

        private void ExibirForm(Form form) {            
            Boolean showForm = true;
            if (ActiveMdiChild != null) {
                if (!ActiveMdiChild.Name.Equals(form.Name)) {
                    ActiveMdiChild.Close();
                } else {
                    showForm = false;
                }               
            }
            if (showForm) {
                form.MdiParent = this;
                form.Show();
            }
            Cursor = Cursors.Default;
        }

        /*Evento disparado ao clicar no menu Selecionar Jogo > Jogo da Velha.*/
        private void miJogoVelha_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            ExibirForm(new TelaJogoVelha());
        }

        /*Evento disparado ao clicar no menu Selecionar Jogo > Jogo da Forca.*/
        private void miJogoForca_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            ExibirForm(new TelaJogoForca());
        }

        private void miSuspeitoOculto_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            ExibirForm(new TelaJogoSuspeitoOculto());
        }

        private void miEncontrePares_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            ExibirForm(new TelaEncontrePares());
        }

        private void miTorreHanoi_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            ExibirForm(new TelaTorreHanoi());
        }

        private void miRatoLabirinto_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            ExibirForm(new TelaLabirinto());
        }

        private void miAjuda_Click(object sender, EventArgs e) {
            Help.ShowHelp(this, Application.StartupPath + @"\Passatempo.chm");
        }

        private void miSobre_Click(object sender, EventArgs e) {
            new TelaSobre().ShowDialog(this);
        }

    }

}