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
using Jogos.EncontrePares.Properties;

namespace Jogos.EncontrePares {

    public partial class TelaEncontrePares : Form {

        //Lista das figuras que já foram reveladas (descoberto 
        //os pares).
        private List<int> figurasReveladas;
        //Posição da figura clicada.
        private Coordenada posicaoClicada;  
        //Contagem regressiva para ocultar as figuras.
        private int contagemRegressiva;
        //Número de erros ao tentar revelar os pares de figuras.
        private int numeroErros;
        //Controla a interação com o jogador.
        private bool aceitaIteracao; 
        //Matriz que recebe os números das figuras que estão sendo
        //exibidas.
        private int[,] matriz;                       
       
        public TelaEncontrePares() {  
            InitializeComponent();     
            matriz = new int[4,4]; 
            figurasReveladas = new List<int>();
            //Atribui a coordenada à propriedade Tag relativa a
            //cada PictureBox que vai exibir as figuras.
            pcbox1.Tag  = new Coordenada(0,0);
            pcbox2.Tag  = new Coordenada(0,1);
            pcbox3.Tag  = new Coordenada(0,2);
            pcbox4.Tag  = new Coordenada(0,3);
            pcbox5.Tag  = new Coordenada(1,0);
            pcbox6.Tag  = new Coordenada(1,1);
            pcbox7.Tag  = new Coordenada(1,2);
            pcbox8.Tag  = new Coordenada(1,3);
            pcbox9.Tag  = new Coordenada(2,0);
            pcbox10.Tag = new Coordenada(2,1);
            pcbox11.Tag = new Coordenada(2,2);
            pcbox12.Tag = new Coordenada(2,3);
            pcbox13.Tag = new Coordenada(3,0);
            pcbox14.Tag = new Coordenada(3,1);
            pcbox15.Tag = new Coordenada(3,2);
            pcbox16.Tag = new Coordenada(3,3);
            Iniciar();            
        }

        /*Retorna o componente PictureBox relativo à coordenada passada.*/
        private PictureBox GetPictureBox(int x, int y) {
            PictureBox pcbox = null;
            switch (x) {
                case 0: {
                    switch (y) { 
                        case 0: pcbox = pcbox1; break;
                        case 1: pcbox = pcbox2; break;
                        case 2: pcbox = pcbox3; break;
                        case 3: pcbox = pcbox4; break;
                    }
                } break;
                case 1: {
                    switch (y) { 
                        case 0: pcbox = pcbox5; break;
                        case 1: pcbox = pcbox6; break;
                        case 2: pcbox = pcbox7; break;
                        case 3: pcbox = pcbox8; break;
                    }
                } break;
                case 2: {
                    switch (y) { 
                        case 0: pcbox = pcbox9; break;
                        case 1: pcbox = pcbox10; break;
                        case 2: pcbox = pcbox11; break;
                        case 3: pcbox = pcbox12; break;
                    }
                } break;
                case 3: {
                    switch (y) { 
                        case 0: pcbox = pcbox13; break;
                        case 1: pcbox = pcbox14; break;
                        case 2: pcbox = pcbox15; break;
                        case 3: pcbox = pcbox16; break;
                    }
                } break;
            }
            return pcbox;
        }

        /*Retorna a imagem relativa à coordenada passada (imagem padrão,
        que oculta a figura e é numerada).*/
        private Bitmap GetImagemPadrao(int x, int y) { 
            Bitmap bmp = null;
            switch (x) {
                case 0: {
                    switch (y) { 
                        case 0: bmp = Resources.pos1; break;
                        case 1: bmp = Resources.pos2; break;
                        case 2: bmp = Resources.pos3; break;
                        case 3: bmp = Resources.pos4; break;
                    }
                } break;
                case 1: {
                    switch (y) { 
                        case 0: bmp = Resources.pos5; break;
                        case 1: bmp = Resources.pos6; break;
                        case 2: bmp = Resources.pos7; break;
                        case 3: bmp = Resources.pos8; break;
                    }
                } break;
                case 2: {
                    switch (y) { 
                        case 0: bmp = Resources.pos9; break;
                        case 1: bmp = Resources.pos10; break;
                        case 2: bmp = Resources.pos11; break;
                        case 3: bmp = Resources.pos12; break;
                    }
                } break;
                case 3: {
                    switch (y) { 
                        case 0: bmp = Resources.pos13; break;
                        case 1: bmp = Resources.pos14; break;
                        case 2: bmp = Resources.pos15; break;
                        case 3: bmp = Resources.pos16; break;
                    }
                } break;
            }
            return bmp;
        }

        /*Retorna a figura identificada pelo número passado. São 12 figuras, 
        identificadas pelos números de 1 a 12.*/
        private Bitmap GetFigura(int numFigura) {
            Bitmap bmp = null;
            switch (numFigura) {
                case  1: bmp = Resources.abelha; break;
                case  2: bmp = Resources.aranha; break;
                case  3: bmp = Resources.borboleta; break;
                case  4: bmp = Resources.caracol; break;
                case  5: bmp = Resources.coelho; break;
                case  6: bmp = Resources.gato; break;
                case  7: bmp = Resources.leao; break;
                case  8: bmp = Resources.macaco; break;
                case  9: bmp = Resources.passaro; break;
                case 10: bmp = Resources.pato; break;
                case 11: bmp = Resources.sapo; break;
                case 12: bmp = Resources.urso; break;
            }
            return bmp;
        }

        /*Substitui todas as imagens exibidas pela respectiva imagem
        padrão (imagem padrão numerada).*/
        private void OcultarFiguras() {             
            pcbox1.Image  = GetImagemPadrao(0,0);
            pcbox2.Image  = GetImagemPadrao(0,1);
            pcbox3.Image  = GetImagemPadrao(0,2);
            pcbox4.Image  = GetImagemPadrao(0,3);
            pcbox5.Image  = GetImagemPadrao(1,0);
            pcbox6.Image  = GetImagemPadrao(1,1);
            pcbox7.Image  = GetImagemPadrao(1,2);
            pcbox8.Image  = GetImagemPadrao(1,3);
            pcbox9.Image  = GetImagemPadrao(2,0);
            pcbox10.Image = GetImagemPadrao(2,1);
            pcbox11.Image = GetImagemPadrao(2,2);
            pcbox12.Image = GetImagemPadrao(2,3);
            pcbox13.Image = GetImagemPadrao(3,0);
            pcbox14.Image = GetImagemPadrao(3,1);
            pcbox15.Image = GetImagemPadrao(3,2);
            pcbox16.Image = GetImagemPadrao(3,3);
        }

        /*Exibe as figuras nas posições da matriz. A cada turno os pares 
        de figuras são trocados (personagens diferentes) e são posicionadas
        aleatóriamente.*/
        private void ExibirFiguras() {
            pcbox1.Image  = GetFigura(matriz[0,0]);            
            pcbox2.Image  = GetFigura(matriz[0,1]);            
            pcbox3.Image  = GetFigura(matriz[0,2]);            
            pcbox4.Image  = GetFigura(matriz[0,3]);            
            pcbox5.Image  = GetFigura(matriz[1,0]);            
            pcbox6.Image  = GetFigura(matriz[1,1]);            
            pcbox7.Image  = GetFigura(matriz[1,2]);            
            pcbox8.Image  = GetFigura(matriz[1,3]);            
            pcbox9.Image  = GetFigura(matriz[2,0]);            
            pcbox10.Image = GetFigura(matriz[2,1]);            
            pcbox11.Image = GetFigura(matriz[2,2]);            
            pcbox12.Image = GetFigura(matriz[2,3]);            
            pcbox13.Image = GetFigura(matriz[3,0]);            
            pcbox14.Image = GetFigura(matriz[3,1]);            
            pcbox15.Image = GetFigura(matriz[3,2]);            
            pcbox16.Image = GetFigura(matriz[3,3]);
        }

        /*Exibe as figuras que foram reveladas, mantendo as demais ocultas.*/
        private void ImprimirMatriz() {
            for (int x = 0; x < 4; x++) {
                for (int y = 0; y < 4; y++) {
                    PictureBox pcbox = GetPictureBox(x, y);
                    int numImagem = matriz[x, y];
                    bool revelada = figurasReveladas.Contains(numImagem);
                    pcbox.Image = (
                        revelada ?
                        GetFigura(numImagem): 
                        GetImagemPadrao(x,y)
                    );
                }            
            }
        }

        /*Retorna a lista com os pares de figuras (números das figuras) que
        serão passadas para as posições da matriz. Os números das figuras serão
        distribuídos aleatóriamente na lista.
        A cada chamada a este método, os pares de figuras retornados terão alguns
        personagens diferentes.*/
        private List<int> GetListaParesFiguras() {
            Random rnd = new Random();
            List<int> lista1 = new List<int>(12);
            //Lista com os números de identificação das figuras.
            for (int numFigura = 1; numFigura <= 12; numFigura++) {
                lista1.Add(numFigura);
            }
            //Seleciona aleatóriamente apenas 8 das 12 figuras.
            do {
                int idx = rnd.Next(lista1.Count);
                lista1.RemoveAt(idx);
            } while (lista1.Count > 8);
            //Duplica a lista de figuras (cada figura deve estar 
            //aos pares na lista de retorno).
            List<int> lista2 = new List<int>(16);
            for (int i = 0; i < lista1.Count; i++) {
                lista2.Add(lista1[i]);
                lista2.Add(lista1[i]);
            }
            //Mistura as posições da lista (distribui aleatóriamente
            //os pares de figuras na lista anterior).
            List<int> lista3 = new List<int>(16);
            do {
                int idx = rnd.Next(lista2.Count);
                int img = lista2[idx];
                lista3.Add(img);
                lista2.RemoveAt(idx);
            } while (lista2.Count > 0);
            //Retorna a lista.
            return lista3;
        }

        /*Inicia um novo jogo de adivinhação. Antes de ocultar as figuras, há
        um tempo de 20 segundos para que o jogador tente decorar aonde estão os
        pares de figuras iguais que ele irá revelar.*/
        private void Iniciar() {
            TrilhaSonora.Executar(Resources.trilha1);
            timOcultar.Stop();
            timIniciar.Stop();
            btnIniciar.Visible = false;
            aceitaIteracao = false;
            contagemRegressiva = 20;
            numeroErros = 0;
            //Recebe a lista com os pares de figuras já misturada,
            //e recupera aleatóriamente os números desta lista
            //para preencher as posições da matriz.
            Random rnd = new Random();
            List<int> lista = GetListaParesFiguras();
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    int idx = rnd.Next(lista.Count);
                    matriz[i,j] = lista[idx];
                    lista.RemoveAt(idx);
                }
            }
            lblTempo.Text = contagemRegressiva.ToString();
            lblErros1.Text = "ERROS: " + numeroErros.ToString();
            figurasReveladas.Clear();                                 
            lblTempo.Visible = true;
            pcbTempo.Visible = true;
            lblErros1.Visible = false;
            lblErros1.Visible = false;
            ExibirFiguras();
            //Inicia a contagem regressiva para ocultar as figuras e
            //iniciar a interação com o jogador.
            timContagem.Start();
        }

        /*Tratador de eventos para o clique nas figuras da matriz na tela.*/
        private void PictureBoxClick(object sender, EventArgs e) {
            if (aceitaIteracao) {
                //Recupera a coordenada clicada.
                Coordenada coord = (Coordenada)((Control)sender).Tag;
                //Se for a mesma clicada anteriormente, retorna.
                if (posicaoClicada != null) { 
                    if (posicaoClicada.Equals(coord)) {
                        return;
                    }    
                }
                //Se clicou numa figura que já foi revelada, retorna.
                aceitaIteracao = false;                
                int figura1 = matriz[coord.X, coord.Y];
                if (figurasReveladas.Contains(figura1)) {
                    aceitaIteracao = true;
                    return;
                }
                //Exibe a figura que está na posição clicada.
                PictureBox pcbox = GetPictureBox(coord.X, coord.Y);
                pcbox.Image = GetFigura(figura1);
                if (posicaoClicada != null) {
                    //Segundo clique. Verifica se a figura clicada agora
                    //faz par com a da coordenada obtida no primeiro clique.
                    int figura2 = matriz[posicaoClicada.X, posicaoClicada.Y];                        
                    if (figura1 == figura2) {
                        //Faz par...
                        figurasReveladas.Add(figura1);
                        ImprimirMatriz();
                        aceitaIteracao = true;
                        if (figurasReveladas.Count == 8) {
                            //Revelou os 8 pares... Toca a trilha de fim
                            //de jogo e iniciar o timer para embaralhar
                            //os personagens.
                            TrilhaSonora.Executar(Resources.trilha3);
                            timIniciar.Start();
                        } else {
                            TrilhaSonora.Executar(Resources.trilha5);
                        }
                    } else {
                        //Não faz par...
                        TrilhaSonora.Executar(Resources.trilha4);
                        //Inclementa o número de erros e ativa o timer que vai
                        //ocultar as figuras clicadas e habilitar a interação
                        //com o jogador.
                        numeroErros++;
                        lblErros1.Text = "ERROS: " + numeroErros.ToString();
                        timOcultar.Start();
                    }
                    posicaoClicada = null;
                } else {
                    //Primeiro clique. Registra a coordenada da figura clicada.
                    TrilhaSonora.Executar(Resources.trilha2);
                    posicaoClicada = coord;
                    aceitaIteracao = true;
                }                               
            }
        }

        /*Tratador de evento do timer para a contagem regressiva para ocultar
        as figuras exibidas e iniciar a interação com o jogador.*/
        private void timContagem_Tick(object sender, EventArgs e) {
            //Declementa a contagem e exibe na tela.
            contagemRegressiva--;
            lblTempo.Text = contagemRegressiva.ToString();
            if (contagemRegressiva == 0) {
                //Fim da contagem...
                //Oculta as figuras e aceita a interação com o jogador.
                ((Timer)sender).Stop();
                TrilhaSonora.Executar(Resources.trilha1);
                lblErros1.Text = "ERROS: " + numeroErros.ToString();
                OcultarFiguras();
                btnIniciar.Visible = true;
                lblTempo.Visible = false;
                pcbTempo.Visible = false;
                lblErros1.Visible = true;
                lblErros1.Visible = true;                
                aceitaIteracao = true;
            }
        }

        /*Tratador de evento do timer que vai remover o par de figuras que não
        formam par.*/
        private void timOcultar_Tick(object sender, EventArgs e) {
            ((Timer)sender).Stop();
            TrilhaSonora.Executar(Resources.trilha1);
            ImprimirMatriz();
            aceitaIteracao = true;
        }

        /*Tratador de evento do timer que embaralha as figuras e inicia a
        contagem regressiva.*/
        private void timIniciar_Tick(object sender, EventArgs e) {
            Iniciar();
        }

        /*Tratador de evento para o clique no botão Iniciar.*/
        private void btnIniciar_Click(object sender, EventArgs e) {            
            Iniciar();
        }

    }

}