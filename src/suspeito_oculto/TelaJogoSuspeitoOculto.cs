using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jogos.SuspeitoOculto.Properties;
using Jogos.Classes;

namespace Jogos.SuspeitoOculto {

    public partial class TelaJogoSuspeitoOculto : Form {

        //Lista de figuras acima da linha pontilhada.
        private List<int> figurasAcima;
        //Lista de figuras abaixo da linha pontilhada.
        private List<int> figurasAbaixo;
        //Figura que será ocultada.
        private int suspeito;
        //Etapa atual (de 1 a 10).
        private int etapaAtual;
        //Status de teste finalizado.
        private bool finalizado;

        public TelaJogoSuspeitoOculto() {
            figurasAcima = new List<int>();
            figurasAbaixo = new List<int>();
            InitializeComponent();
            Iniciar();            
        }

        /*Oculta todos os componentes PictureBox acima e abaixo
        da linha pontilhada.*/
        private void OcultarFiguras() {
            pcbPosicao19.Visible = false;
            pcbPosicao21.Visible = false;
            pcbPosicao23.Visible = false;
            pcbPosicao25.Visible = false;
            pcbPosicao27.Visible = false;
            pcbPosicao20.Visible = false;
            pcbPosicao22.Visible = false;
            pcbPosicao24.Visible = false;
            pcbPosicao26.Visible = false;
            pcbPosicao1.Visible = false;
            pcbPosicao3.Visible = false;
            pcbPosicao5.Visible = false;
            pcbPosicao7.Visible = false;
            pcbPosicao9.Visible = false;
            pcbPosicao10.Visible = false;
            pcbPosicao12.Visible = false;
            pcbPosicao14.Visible = false;
            pcbPosicao16.Visible = false;
            pcbPosicao18.Visible = false;
            pcbPosicao11.Visible = false;
            pcbPosicao13.Visible = false;
            pcbPosicao15.Visible = false;
            pcbPosicao17.Visible = false;
            pcbPosicao2.Visible = false;
            pcbPosicao4.Visible = false;
            pcbPosicao6.Visible = false;
            pcbPosicao8.Visible = false;
        }

        /*Retorna uma PictureBox acima ou abaixo da linha pontilhada.
        Uma posição acima da linha é definida por lista == 1. Abaixo,
        é definida por lista == 2.*/
        private PictureBox GetPictureBox(int lista, int posicao) {
            PictureBox pcbox = null;
            switch (lista) {
                //PictureBox acima da linha pontilhada.
                case 1: {
                    switch (posicao) {
                        case  1: pcbox = pcbPosicao1; break;
                        case  2: pcbox = pcbPosicao2; break;
                        case  3: pcbox = pcbPosicao3; break;
                        case  4: pcbox = pcbPosicao4; break;
                        case  5: pcbox = pcbPosicao5; break;
                        case  6: pcbox = pcbPosicao6; break;
                        case  7: pcbox = pcbPosicao7; break;
                        case  8: pcbox = pcbPosicao8; break;
                        case  9: pcbox = pcbPosicao9; break;
                        case 10: pcbox = pcbPosicao10; break;
                        case 11: pcbox = pcbPosicao11; break;
                        case 12: pcbox = pcbPosicao12; break;
                        case 13: pcbox = pcbPosicao13; break;
                        case 14: pcbox = pcbPosicao14; break;
                        case 15: pcbox = pcbPosicao15; break;
                        case 16: pcbox = pcbPosicao16; break;
                        case 17: pcbox = pcbPosicao17; break;
                        case 18: pcbox = pcbPosicao18; break;
                    }
                } break;
                //PictureBox abaixo da linha pontilhada.
                case 2: {
                    switch (posicao) {
                        case 1: pcbox = pcbPosicao19; break;
                        case 2: pcbox = pcbPosicao20; break;
                        case 3: pcbox = pcbPosicao21; break;
                        case 4: pcbox = pcbPosicao22; break;
                        case 5: pcbox = pcbPosicao23; break;
                        case 6: pcbox = pcbPosicao24; break;
                        case 7: pcbox = pcbPosicao25; break;
                        case 8: pcbox = pcbPosicao26; break;
                        case 9: pcbox = pcbPosicao27; break;
                    }
                } break;
            }
            return pcbox;
        }

        /*Retorna uma figura identificada por um número. O parâmetro tipo
        define o modelo de figura que será retornada. O valor 1 define que
        retorna a figura normal, 2 define que a figura terá um "X" sobre 
        ela.*/
        private Bitmap GetFigura(int numero, int tipo) {
            Bitmap bmp = null;
            switch (tipo) {
                //Imagem normal (sem efeitos).    
                case 1: {
                    switch (numero) {
                        case  0: bmp = Resources.Suspeito; break;
                        case  1: bmp = Resources.Homem1; break;
                        case  2: bmp = Resources.Homem2; break;
                        case  3: bmp = Resources.Homem3; break;
                        case  4: bmp = Resources.Homem4; break;
                        case  5: bmp = Resources.Homem5; break;
                        case  6: bmp = Resources.Homem6; break;
                        case  7: bmp = Resources.Homem7; break;
                        case  8: bmp = Resources.Homem8; break;
                        case  9: bmp = Resources.Homem9; break;
                        case 10: bmp = Resources.Homem10; break;
                        case 11: bmp = Resources.Homem11; break;
                        case 12: bmp = Resources.Mulher1; break;
                        case 13: bmp = Resources.Mulher2; break;
                        case 14: bmp = Resources.Mulher3; break;
                        case 15: bmp = Resources.Mulher4; break;
                        case 16: bmp = Resources.Mulher5; break;
                        case 17: bmp = Resources.Mulher6; break;
                    }                
                } break;
                //Imagem com "X" sobre ela
                case 2: {
                    switch (numero) {
                        case  1: bmp = Resources.Homem1E; break;
                        case  2: bmp = Resources.Homem2E; break;
                        case  3: bmp = Resources.Homem3E; break;
                        case  4: bmp = Resources.Homem4E; break;
                        case  5: bmp = Resources.Homem5E; break;
                        case  6: bmp = Resources.Homem6E; break;
                        case  7: bmp = Resources.Homem7E; break;
                        case  8: bmp = Resources.Homem8E; break;
                        case  9: bmp = Resources.Homem9E; break;
                        case 10: bmp = Resources.Homem10E; break;
                        case 11: bmp = Resources.Homem11E; break;
                        case 12: bmp = Resources.Mulher1E; break;
                        case 13: bmp = Resources.Mulher2E; break;
                        case 14: bmp = Resources.Mulher3E; break;
                        case 15: bmp = Resources.Mulher4E; break;
                        case 16: bmp = Resources.Mulher5E; break;
                        case 17: bmp = Resources.Mulher6E; break;
                    }
                } break;
            }
            return bmp;
        }

        /*Exibe as figuras acima da linha pontilhada. Se o parâmetro ocultarSuspeito é true, 
        substitui o suspeito oculto por uma figura padrão. As figuras serão dispostas de tal 
        modo que fiquem simétricas com relação a um eixo que corta a tela verticalmente em 
        duas partes iguais, por isso, serão distribuídas em diferentes configurações de 
        PictureBox. São 18 PictureBox dispostas de modo específico para manter a simetria.*/
        private void ExibirFigurasAcima(bool ocultarSuspeito) {   
            //Identifica cada PictureBox por um número.
            int[] posicoes = null;
            switch (etapaAtual) {
                case  1: posicoes = new int[] {5}; break;
                case  2: posicoes = new int[] {4, 6}; break;
                case  3: posicoes = new int[] {3, 5, 7}; break;
                case  4: posicoes = new int[] {2, 4, 6, 8}; break;
                case  5: posicoes = new int[] {1, 3, 5, 7, 9}; break;
                case  6: posicoes = new int[] {3, 5, 7, 12, 14, 16}; break;
                case  7: posicoes = new int[] {2, 4, 6, 8, 12, 14, 16}; break;
                case  8: posicoes = new int[] {2, 4, 6, 8, 11, 13, 15, 17}; break;
                case  9: posicoes = new int[] {1, 3, 5, 7, 9, 11, 13, 15, 17}; break;
                case 10: posicoes = new int[] {1, 3, 5, 7, 9, 10, 12, 14, 16, 18}; break;
            }
            //Cada PictureBox recebe a respectiva figura da lista.
            for (int i = 0; i < posicoes.Length; i++) {
                int posicao = posicoes[i];                               
                int figura = figurasAcima[i];
                //Se ocultarSuspeito = true, figura do suspeito é a padrão.
                int imagem = (ocultarSuspeito && figura == suspeito ? 0 : figura);
                PictureBox pcbox = GetPictureBox(1, posicao);
                Bitmap bmp = GetFigura(imagem, 1);                
                pcbox.Image = bmp;
                pcbox.Visible = true;
            }            
        }

        /*Exibe as figuras abaixo da linha pontilhada. Se o parâmetro revelarSuspeito
        é true, exibe as figuras com um "X", ficando somente a figura correspondente 
        ao suspeito oculto sem este efeito.
        As figuras abaixo da linha pontilhada devem manter a mesma simetria com relação ao
        eixo que divide a tela verticalmente em duas partes iguais.*/
        private void ExibirFigurasAbaixo(Boolean revelarSuspeito) {
            //Identifica cada PictureBox por um número.
            int[] posicoes = null;
            switch (etapaAtual) {
                case  1: posicoes = new int[] {3, 5, 7}; break;
                case  2: posicoes = new int[] {3, 5, 7}; break;
                case  3: posicoes = new int[] {3, 5, 7}; break;
                case  4: posicoes = new int[] {3, 5, 7}; break;
                case  5: posicoes = new int[] {2, 4, 6, 8}; break;
                case  6: posicoes = new int[] {2, 4, 6, 8}; break;
                case  7: posicoes = new int[] {2, 4, 6, 8}; break;
                case  8: posicoes = new int[] {1, 3, 5, 7, 9}; break;
                case  9: posicoes = new int[] {1, 3, 5, 7, 9}; break;
                case 10: posicoes = new int[] {1, 3, 5, 7, 9}; break;
            }
            //Cada PictureBox recebe a respectiva figura da lista.
            for (int i = 0; i < posicoes.Length; i++) {
                int posicao = posicoes[i];                                          
                int imagem = figurasAbaixo[i];
                //Se revelarSuspeito = true, figura que não é do suspeito têm um "X".
                int tipo = (revelarSuspeito ? (imagem == suspeito ? 1 : 2) : 1);                
                PictureBox pcbox = GetPictureBox(2, posicao);
                Bitmap bmp = GetFigura(imagem, tipo);
                pcbox.Image = bmp;
                pcbox.Tag = imagem;
                pcbox.Visible = true;
            }
        }

        /*Iniciar etapas.*/
        private void Iniciar() {
            finalizado = false;
            etapaAtual = 0;
            btnIniciar.Visible = false;
            ProximaEtapa();
            lblSeparador1.Visible = true;
            lblSeparador2.Visible = false;
        }

        /*Configurar uma nova etapa. Sorteia os personagens para as listas acima e 
        abaixo da linha pontilhada. Escolhe também o suspeito oculto da lista acima 
        da linha.*/
        private void ProximaEtapa() {                      
            Random rnd = new Random();
            int num = 0, tempo = 0;
            //Lista com os números de todas as figuras.
            List<int> listaFiguras = new List<int>(17);
            for (int i = 1; i <= 17; i++) {
                listaFiguras.Add(i);
            }
            //Configuração do número de personagens na lista
            //abaixo e o tempo de exibição.
            etapaAtual++;
            switch (etapaAtual) {
                case  1: {num = 3; tempo = 1;} break;
                case  2: {num = 3; tempo = 3;} break;
                case  3: {num = 3; tempo = 3;} break;
                case  4: {num = 3; tempo = 4;} break;
                case  5: {num = 4; tempo = 4;} break;
                case  6: {num = 4; tempo = 4;} break;
                case  7: {num = 4; tempo = 4;} break;
                case  8: {num = 5; tempo = 5;} break;
                case  9: {num = 5; tempo = 5;} break;
                case 10: {num = 5; tempo = 5;} break;
            }            
            figurasAcima.Clear();
            figurasAbaixo.Clear();
            //Obtém os personagens da lista acima da linha.
            //Número de personagens é o mesmo que o da etapa atual.
            for (int i = 1; i <= etapaAtual; i++) {
                int idx = rnd.Next(listaFiguras.Count);
                figurasAcima.Add(listaFiguras[idx]);
                listaFiguras.RemoveAt(idx);
            }
            //Define o suspeito oculto.
            suspeito = figurasAcima[
                rnd.Next(figurasAcima.Count)
            ];
            //Obtém os personagens da lista abaixo da linha.
            List<int> lista2 = new List<int>(num);
            lista2.Add(suspeito);
            while (lista2.Count < num) {
                int idx = rnd.Next(listaFiguras.Count);
                lista2.Add(listaFiguras[idx]);
                listaFiguras.RemoveAt(idx);
            }
            do {
                int idx = rnd.Next(lista2.Count);
                figurasAbaixo.Add(lista2[idx]);
                lista2.RemoveAt(idx);
            } while (lista2.Count > 0);            
            lblMensagem.Visible = false;
            lblEtapa.Text = "ETAPA: " + etapaAtual.ToString();
            lblSeparador1.Visible = (etapaAtual < 6);
            lblSeparador2.Visible = !lblSeparador1.Visible;
            OcultarFiguras();
            //Exibe todos os personagens da lista acima da linha.
            ExibirFigurasAcima(false);
            //Inicia o timer para exibição da lista abaixo da linha
            //e ocultação do suspeito da lista acima.
            timeOcultar.Interval = 1000 * tempo;
            timeOcultar.Start();            
        }

        /*Tratador de evento para clique numa PictureBox da lista abaixo da
        linha pontilhada.*/
        private void PictureBoxClick(object sender, EventArgs e) {
            if (finalizado) return;
            int numImagem = (int)((PictureBox)sender).Tag;
            if (numImagem == suspeito) {  
                //Imagem clicada é a do suspeito oculto...  
                if (etapaAtual < 10) {
                    //Antes da décima etapa: inicia uma nova etapa.
                    TrilhaSonora.Executar(Resources.trilha2);
                    ProximaEtapa();    
                } else {
                    //Décima etapa: finaliza o jogo, com a mensagem parabenizando
                    //o jogador e habilita o botão Iniciar.
                    TrilhaSonora.Executar(Resources.trilha4);  
                    finalizado = true;
                    lblMensagem.Text = "Você passou em todas as etapas. Parabéns!";
                    lblMensagem.ForeColor = Color.Green;
                    lblMensagem.Visible = true;
                    btnIniciar.Visible = true;            
                }                
            } else {
                //Imagem clicada não é do suspeito. Exibe a mensagem informando
                //o erro e habilita o botão Iniciar para começar de novo.
                finalizado = true;                
                ExibirFigurasAbaixo(true);
                btnIniciar.Visible = true;
                TrilhaSonora.Executar(Resources.trilha3);                
                lblMensagem.Text = "Você errou!";
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Visible = true;
            }            
        }

        /*Tratador de evento para o timer que vai exibir as figuras abaixo da linha e
        ocultar o suspeito.*/
        private void timeOcultar_Tick(object sender, EventArgs e) {
            ((Timer)sender).Stop();
            TrilhaSonora.Executar(Resources.trilha1);
            ExibirFigurasAcima(true);
            ExibirFigurasAbaixo(false);
        }

        /*Tratador de evento para clique no botão Iniciar.*/
        private void btnIniciarClick(object sender, EventArgs e) {
            Iniciar();          
        }

    }

}