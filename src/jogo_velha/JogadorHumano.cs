using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Classe que representa o jogador humano no jogo.*/
    class JogadorHumano: Jogador {

        /*Posição do tabuleiro que o jogador humano vai marcar.*/
        private Posicao posicao;

        public JogadorHumano(char marcador) : base(marcador) { 
        }

        /*Define a posição do tabuleiro que o jogador humano
        vai marcar. É obtida com o clique numa posição no tabuleiro
        na tela do jogo.*/
        public void SetPosicao(Posicao posicao) { 
            this.posicao = posicao;
        }

        /*Implementação do método MarcarTabuleiro da classe base.
        retorna a posição definida (clicada no tabuleiro da tela
        principal).*/
        public override Posicao MarcarTabuleiro() { 
            return posicao;
        }

    }

}
