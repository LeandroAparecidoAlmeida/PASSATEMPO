using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Classe que representa o tabuleiro do jogo da velha. As posições do 
    tabuleiro vão receber caracteres que representam os marcadores associados
    aos jogadores (geralmente X e O).*/
    public class Tabuleiro: ICloneable {

        //Simboliza uma posição vazia no tabuleiro.
        public static char VAZIO = '\0';
        //Matriz 3 X 3 que representa as posições do tabuleiro.
        private char[,] matriz;
        //Número de posições marcadas na matriz.
        private int numPosicoesMarcadas;

        /*Constructor default. Inicializa todas as posições da matriz
        com marcador de vazio.*/
        public Tabuleiro() { 
            matriz = new char[3,3];
            Limpar();
        }

        /*Retorna o marcador na posição definida do tabuleiro.
        A forma de acessar a posição é a seguinte: tabuleiro[linha, coluna].*/
        public char this[int i, int j] {
            get{return matriz[i,j];}
        }

        /*Retorna o marcador na posição definida do tabuleiro.*/
        public char Get(int linha, int coluna) { 
            return matriz[linha, coluna];
        }

        /*Marca uma posição do tabuleiro se estiver vazia. Retorna a linha,
        coluna ou diagonal completada com o mesmo marcador passado se isso
        ocorreu.*/
        public Linha Marcar(int linha, int coluna, char marcador) {
            Linha resultado = Linha.Indefinida;
            if (matriz[linha, coluna] == VAZIO) {
                matriz[linha,coluna] = marcador;
                numPosicoesMarcadas++;
                if (matriz[0,0] == marcador &&
                    matriz[0,1] == marcador && 
                    matriz[0,2] == marcador) { 
                    resultado = Linha.Horizontal1;
                }
                else
                if (matriz[1,0] == marcador &&
                    matriz[1,1] == marcador &&
                    matriz[1,2] == marcador) {
                    resultado = Linha.Horizontal2;
                }
                else
                if (matriz[2,0] == marcador &&
                    matriz[2,1] == marcador &&
                    matriz[2,2] == marcador) {
                    resultado = Linha.Horizontal3;
                }
                else
                if (matriz[0,0] == marcador &&
                    matriz[1,0] == marcador &&
                    matriz[2,0] == marcador) {
                    resultado = Linha.Vertical1;
                }
                else
                if (matriz[0,1] == marcador &&
                    matriz[1,1] == marcador &&
                    matriz[2,1] == marcador) {
                    resultado = Linha.Vertical2;
                }
                else
                if (matriz[0,2] == marcador &&
                    matriz[1,2] == marcador &&
                    matriz[2,2] == marcador) {
                    resultado = Linha.Vertical3;
                }
                else
                if (matriz[0,0] == marcador &&
                    matriz[1,1] == marcador &&
                    matriz[2,2] == marcador) {
                    resultado = Linha.DiagonalEsquerda;
                }
                else
                if (matriz[0,2] == marcador &&
                    matriz[1,1] == marcador &&
                    matriz[2,0] == marcador) {
                    resultado = Linha.DiagonalDireita;
                }
            }
            return resultado;
        }

        /*Retorna true se o tabuleiro está cheio (todas as 9 posições
        do tabuleiro marcadas) ou false, caso tenha alguma posição ainda
        vazia.*/
        public bool Cheio() {
            return (numPosicoesMarcadas == 9);
        }

        /*Limpa o tabuleiro (define todas as posições com marcador
        de vazio).*/
        public void Limpar() {
            numPosicoesMarcadas = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    matriz[i, j] = VAZIO;
                }
            }
        }

        /*Retorna o número de linhas do tabuleiro.*/
        public int NumeroLinhas {
            get {return 3;}
        }

        /*Retorna o número de colunas do tabuleiro.*/
        public int NumeroColunas { 
            get {return 3;}
        }

        /*Retorna o número de posições marcadas no tabuleiro.*/
        public int NumeroPosicoesMarcadas { 
            get {return numPosicoesMarcadas;}
        }

        /*Retorna uma cópia do tabuleiro.*/
        public object Clone() {
            Tabuleiro copia = new Tabuleiro();
            copia.numPosicoesMarcadas = this.numPosicoesMarcadas;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    copia.matriz[i, j] = this.matriz[i, j];
                }
            }
            return copia;
        }

    }

}
