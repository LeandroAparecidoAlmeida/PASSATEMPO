using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Linhas que podem ser formadas no tabuleiro com
    os mesmos marcadores.*/
    public enum Linha {
        //Verticais.
        Vertical1,
        Vertical2,
        Vertical3,
        //Horizontais.
        Horizontal1,
        Horizontal2,
        Horizontal3,
        //Diagonais.
        DiagonalDireita,
        DiagonalEsquerda,
        //Nenhuma linha.
        Indefinida
    }

}
