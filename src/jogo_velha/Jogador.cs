using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Classe abstrata representando um jogador que disputa o
    jogo da velha. Cada jogador deve ter um marcador associado.
    Cada classe que herda de Jogador deve implementar o método
    abstract MarcarTabuleiro, que retorna a posição do tabuleiro
    que o jogador vai marcar.*/
    public abstract class Jogador {

        /*Marcador do jogador.*/
        protected char marcador;

        /*Constructor. Recebe o marcador como parâmetro.*/
        public Jogador(char marcador) { 
            this.marcador = marcador;
        }

        /*Retorna o marcador associado ao jogador.*/
        public char Marcador {
            get {return marcador;}
        }

        /*Método abstract. Retorna a posição do tabuleiro que o
        jogador vai marcar. Cada classe que herda de Jogador deve
        implementar este método.*/
        public abstract Posicao MarcarTabuleiro();

    }

}
