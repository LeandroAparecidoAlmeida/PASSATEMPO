using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jogos.Labirinto.Properties;
using System.Threading;
using Jogos.Classes;

namespace Jogos.Labirinto {

    public partial class TelaLabirinto : Form {

        //Matriz de PictureBox para desenho dos labirintos.
        private PictureBox[,] labirinto;
        //Padrões que codificam todos os modelos de labirintos.
        private List<String> padroes;
        //Coordenadas do rato no labirinto.
        private int idx1, idx2;
        //Status de jogo finalizado.
        private bool finalizado;

        public TelaLabirinto() {            
            padroes = new List<string>();
            InitializeComponent();
            finalizado = true;
            //Cria e posiciona os PictureBox que constitui a matriz
            //25x25 que forma os labirintos.
            labirinto = new PictureBox[25, 25];
            int h = 0, v = 0, d = 22;
            for (int i = 0; i < 25; i++) {
                h = 0;
                for (int j = 0; j < 25; j++) {
                    PictureBox pcb = new PictureBox();
                    pcb.Size = new Size(d, d);
                    pcb.Location = new Point(h, v);                    
                    labirinto[i, j] = pcb;
                    //Componente Panel que recebe os PictureBox criados,
                    //não o form. Isso facilita o posicionamento do labirinto,
                    //bastando mover o Panel para a posição desejada.
                    pnlLabirinto.Controls.Add(labirinto[i, j]);
                    h += d;                   
                }
                v += d;
            }
            pnlLabirinto.ResumeLayout(false);
            CriarLabirinto();            
        }

        /*Desenha o labirinto de acordo com algum padrão recuperado do arquivo.*/
        private void CriarLabirinto() {   
            this.Cursor = Cursors.WaitCursor;            
            lblMensagem.Visible = false;
            pcbMouse.Visible = false;
            if (padroes.Count == 0) {
                //Recupera os padrões no arquivo
                String texto = Resources.labirinto;
                String[] linhas = texto.Split(new char[] {'\n'});
                foreach (String linha in linhas) {
                    padroes.Add(linha);
                }
            }            
            //Obtém aleatóriamente um padrão que codifica um modelo
            //de labirinto.
            Random rnd = new Random();
            int idx = rnd.Next(padroes.Count);
            String padrao = padroes[idx];
            //Remove o padrão obtido.
            padroes.RemoveAt(idx);
            //String padrao = padroes[0];
            int n = 0;
            //Faz a decodificação do padrão. Ele representa uma matriz
            //binária (digítos 1's e 0's) de 25 x 25 posições.
            //A construção da matriz é linha a linha, da esquerda para 
            //a direita e de cima para baixo. O padrão vai sendo lido
            //linearmente para a construção da matriz.
            for (int i = 0; i < 25; i++) {
                for (int j = 0; j < 25; j++) {
                    //Inteiro que codificada uma passagem (0) ou parede (1)
                    //do labirinto.
                    int vi = int.Parse(padrao.Substring(n++, 1));
                    PictureBox pcb = labirinto[i, j];
                    pcb.Image = null;
                    //Tag do componente na coordenada i, j recebe este inteiro.
                    pcb.Tag = vi;
                    //.FromArgb(80, 80, 80) 
                    //Componentes que são passagem têm a cor transparente,
                    //que são parede a cor escura.
                    pcb.BackColor = (
                        vi == 1 ?
                        Color.FromArgb(95, 95, 75) : 
                        pcb.BackColor = Color.Transparent
                    );
                }
            }                  
            this.Cursor = Cursors.Default;
            //Posiciona o rato na entrada do labirinto.
            idx1 = 1;
            idx2 = 0;            
            labirinto[idx1, idx2].Image = Resources.mouse;
            finalizado = false;
            TrilhaSonora.Executar(Resources.trilha1);
        }

        private void Mover(int keyValue) {
            if (!finalizado) {
                int i = idx1, j = idx2;
                switch (keyValue) {
                    //Seta para esquerda.
                    case 37: j--; break;
                    //Seta para cima.
                    case 38: i--; break;
                    //Seta para direita.
                    case 39: j++; break;
                    //Seta para baixo.
                    case 40: i++; break;
                }
                if (i >= 0 && j >= 0) {
                    //Tag igual a 0 indica passagem, igual a 1, parede.
                    //Rato só se movimenta pelas passagens do labirinto.
                    if ((int)labirinto[i, j].Tag == 0) {
                        labirinto[idx1, idx2].Image = null;
                        idx1 = i;
                        idx2 = j;
                        //Coordenadas da saída do labirinto.
                        if (idx1 == 23 && idx2 == 24) {
                            //Atingiu a saída do labirinto. Configura fim
                            //de jogo.
                            finalizado = true;
                            lblMensagem.Visible = true;
                            pcbMouse.Visible = true;
                            TrilhaSonora.Executar(Resources.trilha2);
                        } else {
                            //Ainda não atingiu a saída do labirinto.
                            //Desenha o rato na coordenada atual.
                            labirinto[idx1, idx2].Image = Resources.mouse;
                        }
                    }
                }
            }
        }

        /*Tratador de evento para tecla pressionada.*/
        private void TelaLabirinto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            Mover(e.KeyValue);
        }

        private void label1_Click(object sender, EventArgs e) {
            CriarLabirinto();
        }

    }

}
