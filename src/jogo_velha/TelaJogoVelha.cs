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
using Jogos.JogoVelha.Properties;

namespace Jogos.JogoVelha {

    /*Tela principal do jogo da velha. Implementa a interface de interação
    com o jogador.*/
    public partial class TelaJogoVelha : Form {

        //Ordem da partida atual.
        private int ordemPartida;
        //Pontuação do jogador humano.
        private int pontuacaoHumano;
        //Pontuação do jogador virtual.
        private int pontuacaoComputador;
        //Jogador que vai marcar o tabuleiro.
        private Jogador jogadorDaVez;
        //Jogador virtual. Algoritmo para disputa do
        //jogo da velha.
        private JogadorVirtual jogadorVirtual;
        //Jogador humano.
        private JogadorHumano jogadorHumano;        
        //Tabuleiro do jogo.
        private Tabuleiro tabuleiro;
        //Controla a interação do jogador humano.
        private bool aceitaInteracao;
        //Posições (PictureBox) da linha do tabuleiro
        //completada com os mesmos marcadores.
        private PictureBox posic1, posic2, posic3;
        //Modelos dos cursores.
        private Cursor cursor1, cursor2;

        public TelaJogoVelha() {
            InitializeComponent();
            tabuleiro = new Tabuleiro();
            jogadorHumano = new JogadorHumano('X');
            NivelDificuldade nivelDificuldade = GetNivelDificuldade();
            jogadorVirtual = new JogadorVirtual(
                'O',
                tabuleiro,
                jogadorHumano.Marcador,
                nivelDificuldade
            );
            tbNivelDificuldade.Value = (int) nivelDificuldade;                    
            cursor1 = System.Windows.Forms.Cursors.WaitCursor;
            cursor2 = new Cursor(Resources.marcador2.GetHicon());
            ordemPartida = 0;
            aceitaInteracao = false;  
            //Define a propriedade Tag de cada componente
            //PictureBox que constitui as posições do tabuleiro na
            //tela com suas respectivas posições lógicas (instancia
            //da classe Posicao).
            pcbPosicao1.Tag = new Posicao(0,0);
            pcbPosicao2.Tag = new Posicao(0,1);
            pcbPosicao3.Tag = new Posicao(0,2);
            pcbPosicao4.Tag = new Posicao(1,0);
            pcbPosicao5.Tag = new Posicao(1,1);
            pcbPosicao6.Tag = new Posicao(1,2);
            pcbPosicao7.Tag = new Posicao(2,0);
            pcbPosicao8.Tag = new Posicao(2,1);
            pcbPosicao9.Tag = new Posicao(2,2);               
            NovaPartida();
        }

        /*Atualiza a ordem da partida e pontuação dos competidores humano
        e virtual.*/
        private void AtualizarPlacar() {
            lblNumPartida.Text = ordemPartida.ToString();
            lblPontuacaoHumano.Text = pontuacaoHumano.ToString();
            lblPontuacaoComputador.Text = pontuacaoComputador.ToString();
        }

        /*Atualiza a visualização do tabuleiro na tela, para refletir
        a configuração do tabuleiro do jogo (instancia da classe Tabuleiro).*/
        private void AtualizarTabuleiro() {
            for (int linha = 0; linha < 3; linha++) {
                for (int coluna = 0; coluna < 3; coluna++) {
                    char marcador = tabuleiro[linha, coluna];
                    PictureBox pictureBox = GetPictureBox(linha, coluna);
                    switch (marcador) {
                        case 'O': pictureBox.Image = Resources.marcador1; break;
                        case 'X': pictureBox.Image = Resources.marcador2; break;
                        default : pictureBox.Image = null; break;   
                    }
                }
            }
        }

        /*Configura o cursor de acordo o contexto do jogo. Se o jogador pode
        interar com o jogo, cursor assume o desenho de seu marcador, senão,
        assume o cursor de espera em processos demorados.*/
        private void ConfigurarCursor() {
            Cursor cursor = (aceitaInteracao ? cursor2 : cursor1);
            pcbTabuleiro.Cursor = cursor;
            this.Cursor = cursor;
            for (int linha = 0; linha < 3; linha++) {
                for (int coluna = 0; coluna < 3; coluna++) {
                    PictureBox pictureBox = GetPictureBox(linha, coluna);
                    pictureBox.Cursor = cursor;
                }
            }
        }

        /*Retorna o componente PictureBox que compõe o tabuleiro da tela
        relativo às coordenadas passadas (linha, coluna).*/
        private PictureBox GetPictureBox(int linha, int coluna) {
            Posicao posicao = new Posicao(linha, coluna);
            PictureBox pictureBox = null;
            if (((Posicao)pcbPosicao1.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao1;
            } else if (((Posicao)pcbPosicao2.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao2;
            } else if (((Posicao)pcbPosicao3.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao3;
            } else if (((Posicao)pcbPosicao4.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao4;
            } else if (((Posicao)pcbPosicao5.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao5;
            } else if (((Posicao)pcbPosicao6.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao6;
            } else if (((Posicao)pcbPosicao7.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao7;
            } else if (((Posicao)pcbPosicao8.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao8;
            } else if (((Posicao)pcbPosicao9.Tag).Equals(posicao)) {
                pictureBox = pcbPosicao9;
            }
            return pictureBox;
        }        

        /*Retorna o nível de dificuldade que o computador vai oferecer
        na partida, de acordo com o valor da configuração lido do
        Registro do Windows.*/
        private NivelDificuldade GetNivelDificuldade() {
            NivelDificuldade nivelDificuldade;
            object valConfig = Config.GetValor("jogo_velha", "dificuldade");
            int dificuldade = (valConfig != null ? (int)valConfig : 1);
            switch (dificuldade) {
                case 1: nivelDificuldade = NivelDificuldade.Facil; break;
                case 2: nivelDificuldade = NivelDificuldade.Dificil; break;
                case 3: nivelDificuldade = NivelDificuldade.Expert; break;
                default: nivelDificuldade = NivelDificuldade.Facil; break;
            }
            return nivelDificuldade;
        }

        private void SetNivelDificuldade(int value) {
            NivelDificuldade dificuldadeAnterior = GetNivelDificuldade();
            NivelDificuldade dificuldadeAtual = dificuldadeAnterior;
            switch (value) {
                case 1: dificuldadeAtual = NivelDificuldade.Facil; break;
                case 2: dificuldadeAtual = NivelDificuldade.Dificil; break;
                case 3: dificuldadeAtual = NivelDificuldade.Expert; break;
            }            
            if (dificuldadeAtual != dificuldadeAnterior) {                
                //Se mudou o nível de dificuldade, inicia uma novo jogo.   
                timNovaPartida.Stop();
                timTempoComputador.Stop();
                timEfeitos.Stop();
                jogadorVirtual.NivelDificuldade = dificuldadeAtual;
                Config.SetValor("jogo_velha", "dificuldade", value);
                ordemPartida = 0;
                NovaPartida();
            }  
        }

        /*Avalia o tabuleiro e configura o tempo que o computador vai levar para 
        fazer a sua jogada. As situações são as seguintes:
        
            Tabuleiro vazio ou com 8 posições marcadas: 
            -> 0,5 segundos para marcar.
         
            Vai completar uma linha ou desarmar o adversário humano:
            -> 0,5 segundos para marcar.
         
            Vai marcar uma posição qualquer do tabuleiro: 
            -> tempo variável para marcar.
         
        No último caso, a definição do tempo é aleatória, variando entre 0,8 e 
        1,3 segundos.
        Essa variação de tempo serve para dar mais naturalidade ao jogo, simulando
        o tempo que um ser humano leva para realizar a sua jogada nas mais diversas
        situações.*/
        private int GetTempoDecisao() {
            //Tabuleiro vazio ou com 8 posições marcadas:
            int numMarcadas = tabuleiro.NumeroPosicoesMarcadas; 
            if (numMarcadas == 0 || numMarcadas == 8) return 500;
            //Vai completar uma linha ou desarmar o adversário humano:
            int c1, c2, c3, c4, c5, c6, c7, c8, v1, v2, v3, v4;
            c5 = c6 = c7 = c8 = v3 = v4 = 0;
            for (int idx1 = 0; idx1 < 3; idx1++) {
                c1 = c2 = c3 = c4 = v1 = v2 = 0;
                for (int idx2 = 0; idx2 < 3; idx2++) {
                    switch (tabuleiro[idx1, idx2]) { 
                        case 'X': c1++; break;
                        case 'O': c2++; break;
                        default : v1++; break;
                    }
                    switch (tabuleiro[idx2, idx1]) {
                        case 'X': c3++; break;
                        case 'O': c4++; break;
                        default : v2++; break;
                    }
                }
                switch (tabuleiro[idx1, idx1]) {
                    case 'X': c5++; break;
                    case 'O': c6++; break;
                    default : v3++; break;
                }
                switch (tabuleiro[idx1, 2 - idx1]) {
                    case 'X': c7++; break;
                    case 'O': c8++; break;
                    default : v4++; break;
                }
                if (((c1 == 2 || c2 == 2) && v1 == 1) || 
                    ((c3 == 2 || c4 == 2) && v2 == 1) ||
                    ((c5 == 2 || c6 == 2) && v3 == 1) ||
                    ((c7 == 2 || c8 == 2) && v4 == 1)) {
                    return 500;
                }
            }
            //Vai marcar uma posição qualquer do tabuleiro:
            Random rnd = new Random();
            return 800 + rnd.Next(500); 
        }

        /*Seleciona os 3 PictureBox do tabuleiro relativoas à linha
        completada com um mesmo marcador.*/
        private void SelecionarLinha(Linha linha) { 
            switch (linha) {
                case Linha.Horizontal1: { 
                    posic1 = pcbPosicao1;
                    posic2 = pcbPosicao2;
                    posic3 = pcbPosicao3;
                } break;
                case Linha.Horizontal2: {
                    posic1 = pcbPosicao4;
                    posic2 = pcbPosicao5;
                    posic3 = pcbPosicao6;
                } break;
                case Linha.Horizontal3: {
                    posic1 = pcbPosicao7;
                    posic2 = pcbPosicao8;
                    posic3 = pcbPosicao9;
                } break;
                case Linha.Vertical1: {
                    posic1 = pcbPosicao1;
                    posic2 = pcbPosicao4;
                    posic3 = pcbPosicao7;
                } break;
                case Linha.Vertical2: {
                    posic1 = pcbPosicao2;
                    posic2 = pcbPosicao5;
                    posic3 = pcbPosicao8;
                } break;
                case Linha.Vertical3: {
                    posic1 = pcbPosicao3;
                    posic2 = pcbPosicao6;
                    posic3 = pcbPosicao9;
                } break;
                case Linha.DiagonalEsquerda: {
                    posic1 = pcbPosicao1;
                    posic2 = pcbPosicao5;
                    posic3 = pcbPosicao9;
                } break;
                case Linha.DiagonalDireita: {
                    posic1 = pcbPosicao3;
                    posic2 = pcbPosicao5;
                    posic3 = pcbPosicao7;
                } break;
            }        
        }

        /*Jogador marca uma posição do tabuleiro.*/
        private void MarcarTabuleiro(Jogador jogador) {    
            //Posição do tabuleiro escolhida pelo jogador.
            Posicao posic = jogador.MarcarTabuleiro();
            int linha = posic.Linha;
            int coluna = posic.Coluna;
            //Verifica se a posição escolhida está vazia.
            if (tabuleiro[linha, coluna] == Tabuleiro.VAZIO) {  
                aceitaInteracao = false;
                ConfigurarCursor();
                //Marca o tabuleiro com o marcador do jogador.
                Linha linhaCompletada = tabuleiro.Marcar(
                    linha,
                    coluna,
                    jogador.Marcador
                );
                AtualizarTabuleiro();
                //Verifica se completou uma linha vertical, horizontal
                //ou diagonal com os mesmos marcadores.
                if (linhaCompletada == Linha.Indefinida) {
                    //Não completou a linha...
                    TrilhaSonora.Executar(Resources.trilha1);
                    //Alterna o direito de jogada.
                    if (jogador == jogadorHumano) {
                        jogadorDaVez = jogadorVirtual;                        
                    } else { 
                        jogadorDaVez = jogadorHumano;
                    }
                    //Verifica se encheu o tabuleiro
                    if (tabuleiro.Cheio()) {
                        //Tabuleiro cheio...
                        //Iniciará uma nova partida.
                        lblNovaPartida.Visible = true;
                        timNovaPartida.Interval = 2000;
                        NovaPartida();
                    } else { 
                        //Não encheu o tabuleiro...
                        //Verifica o direito de marcar o tabuleiro.
                        VerificarDireitoMarcar();                        
                    }
                } else {
                    //Completou uma linha...
                    TrilhaSonora.Executar(Resources.trilha2);
                    //Inclementa a pontuação do jogador que marcou 
                    //o tabuleiro.
                    if (jogador == jogadorHumano) {
                        pontuacaoHumano++;
                    } else { 
                        pontuacaoComputador++;
                    }
                    //Exibe os efeitos de destaque da linha e
                    //dá inicio a uma nova partida.
                    lblNovaPartida.Visible = true;
                    AtualizarPlacar();
                    SelecionarLinha(linhaCompletada);
                    timNovaPartida.Interval = 4000;
                    //Faz as posições da linha completada ficarem
                    //intermitentes.
                    timEfeitos.Start();
                    NovaPartida();
                }
            }
        }

        /*Configura a interface de acordo com o jogador com o
        direito a marcar o tabuleiro. Se for o computador, aciona
        o timer que simula o tempo de decisão que um jogador 
        humano leva para marcar uma posição. Ao executar o evento,
        o computador marca a posição escolhida do tabuleiro.*/
        private void VerificarDireitoMarcar() {
            if (jogadorDaVez == jogadorVirtual) {
                //É a vez do computador marcar...                
                aceitaInteracao = false;
                //Exibe o ícone do computador.
                pcbComputador.Visible = true;
                pcbProcesso.Visible = true;
                pcbHumano.Visible = false;
                //Ativa o timer que simula o tempo que
                //uma pessoa leva para pensar numa 
                //jogada.
                timTempoComputador.Interval = GetTempoDecisao();
                timTempoComputador.Start();
                ConfigurarCursor();
            } else {
                //É a vez do humano marcar...
                aceitaInteracao = true;
                //Exibe o ícone do humano.
                pcbComputador.Visible = false;
                pcbProcesso.Visible = false;
                pcbHumano.Visible = true;
                ConfigurarCursor();
            }            
        }

        /*Inicia uma nova partida.*/
        private void NovaPartida() {            
            ordemPartida++;
            if (ordemPartida == 1) {
                //Primeira partida do jogo...
                //Sorteia o jogador que inicia jogando.
                Random rnd = new Random();
                int num = 1 + rnd.Next(2);
                switch (num) {
                    case 1: jogadorDaVez = jogadorHumano; break;
                    case 2: jogadorDaVez = jogadorVirtual; break;
                }
                //Configura a interface gráfica.
                pontuacaoHumano = 0;
                pontuacaoComputador = 0;
                TrilhaSonora.Executar(Resources.trilha3);
                tabuleiro.Limpar();
                AtualizarTabuleiro();
                AtualizarPlacar();
                //Verifica o direita a marcar o tabuleiro.
                VerificarDireitoMarcar();
            } else {
                //Aciona o timer para dar uma pausa até iniciar 
                //a nova partida.
                tbNivelDificuldade.Enabled = false;
                timNovaPartida.Start();
            }
        }

        /*Tratador de evento para o clique nas posições do tabuleiro da
        tela.*/
        private void TabuleiroClick(object sender, EventArgs e) {
            if (aceitaInteracao) {
                //Recupera a posição relativa do componente clicado, conforme
                //definido em sua propriedade Tag.
                Posicao posicao = (Posicao)((PictureBox)sender).Tag;
                //Marca o tabuleiro nesta posição.
                jogadorHumano.SetPosicao(posicao);
                MarcarTabuleiro(jogadorHumano);
            }
        }

        /*Evento do Timer que dá início a uma nova partida.*/
        private void timNovaPartida_Tick(object sender, EventArgs e) {
            ((Timer)sender).Stop();
            timEfeitos.Stop();
            lblNovaPartida.Visible = false;            
            if (posic1 != null && posic2 != null && posic3 != null) {
                posic1.Visible = true;
                posic2.Visible = true;
                posic3.Visible = true;
                posic1 = null;
                posic2 = null;
                posic3 = null;
            }
            TrilhaSonora.Executar(Resources.trilha3);
            tabuleiro.Limpar();
            AtualizarTabuleiro();
            AtualizarPlacar();
            VerificarDireitoMarcar();
            tbNivelDificuldade.Enabled = true;
        }

        /*Evento do Timer que realiza a jogada do computador.*/
        private void timTempoComputador_Tick(object sender, EventArgs e) {
            Timer timer = (Timer)sender;
            timer.Stop();
            MarcarTabuleiro(jogadorVirtual);
        }

        /*Evento do timer que causa a intermitência nas posições da
        linha completada com os mesmos marcadores.*/
        private void timEfeitos_Tick(object sender, EventArgs e) {
            posic1.Visible = !posic1.Visible;
            posic2.Visible = !posic2.Visible;
            posic3.Visible = !posic3.Visible;
        }

        /*Evento disparado quando se altera o nível de dificuldade numa partida.*/
        private void tbNivelDificuldade_ValueChanged(object sender, EventArgs e) {
            SetNivelDificuldade(tbNivelDificuldade.Value);
        }

    }

}