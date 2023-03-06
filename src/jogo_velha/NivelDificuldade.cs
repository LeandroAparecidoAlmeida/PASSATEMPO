using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Nível de dificuldade oferecida pelo computador na partida.*/
    public enum NivelDificuldade {
        /*Computador joga em nível amador. Pode errar
        jogadas e deixar o humano ganhar frequentemente.*/
        Facil = 1,
        /*Computador joga bem na maioria das partidas.
        Tem a capacidade de desarmar as jogadas do
        adversário e armar estratégias para vencer, mas
        pode, eventualmente, perder para o jogador humano.*/
        Dificil = 2,
        /*Computador se torna invencível. Nesse nível de
        dificuldade é possível, no máximo, obter um 
        empate com o computador.*/
        Expert = 3
    }

}
