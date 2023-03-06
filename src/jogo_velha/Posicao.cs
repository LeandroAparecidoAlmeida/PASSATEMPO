using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Classe que representa uma posição do tabuleiro. A 
    posição é definida pelo índice da linha e coluna na
    matriz que o representa.
    O índices válidos de linha e coluna vão de 0 até 2.*/
    public class Posicao: ICloneable {

        //Índice da linha no tabuleiro.
        private int linha;
        //Índice da coluna no tabuleiro.
        private int coluna;

        /*Constructor. Recebe os índices da linha e coluna 
        do tabuleiro.*/
        public Posicao(int linha, int coluna) { 
            this.linha = linha;
            this.coluna = coluna;
        }

        /*Retorna o índice da linha do tabuleiro.*/
        public int Linha {
            get {return linha;}
        }

        /*Retorna o índice da coluna do tabuleiro.*/
        public int Coluna {
            get { return coluna;}
        }       

        /*Define o critério de igualdade. Linha e colunas devem ter 
        o mesmo índice.
        Se faz necessária a sobrescrita deste método para se tratar
        conjuntos de objetos desta classe.*/
        public override bool Equals(object obj) {
            Posicao other = (Posicao) obj;
            return (other.linha == this.linha && other.coluna == this.coluna);
        }

        /*Retorna uma cópia do objeto.*/
        public object Clone() { 
            Posicao copia = new Posicao(linha, coluna);
            return copia;
        }

    }

}
