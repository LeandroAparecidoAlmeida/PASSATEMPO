using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoVelha {

    /*Classe que representa o computador. Sua decisão de jogada é baseada na
    avaliação do tabuleiro do jogo e no nível de dificuldade oferecido na
    partida pelo computador.
    O algoritmo utilizado é baseado em previsão e simulação, sendo altamente
    adaptável a quaisquer condição de jogo.*/
    public class JogadorVirtual: Jogador {

        /*Tabuleiro do jogo da velha aonde as partidas são disputadas.*/
        private Tabuleiro tabuleiroJogo;
        /*Marcador associado ao jogador humano.*/
        private char marcadorHumano;
        /*Nível de dificuldade oferecido pelo computador na partida.*/
        private NivelDificuldade nivelDificuldade;
        /*Todos os conjuntos de 3 posições que formam uma linha, coluna
        ou diagonal do tabuleiro.*/
        private List<Posicao[]> linhasTabuleiro;

        public JogadorVirtual(char marcador, Tabuleiro tabuleiro, char marcadorHumano, 
        NivelDificuldade nivelDificuldade): base(marcador) {
            this.tabuleiroJogo = tabuleiro;
            this.marcadorHumano = marcadorHumano;
            this.nivelDificuldade = nivelDificuldade;
            linhasTabuleiro= new List<Posicao[]>();
            //Recupera todas as formações de 3 posições que formam uma linha do
            //tabuleiro, quer na vertical, horizontal ou diagonal.
            linhasTabuleiro.Add(new Posicao[]{new Posicao(0,0), new Posicao(0,1), new Posicao(0,2)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(1,0), new Posicao(1,1), new Posicao(1,2)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(2,0), new Posicao(2,1), new Posicao(2,2)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(0,0), new Posicao(1,0), new Posicao(2,0)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(0,1), new Posicao(1,1), new Posicao(2,1)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(0,2), new Posicao(1,2), new Posicao(2,2)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(0,0), new Posicao(1,1), new Posicao(2,2)});
            linhasTabuleiro.Add(new Posicao[]{new Posicao(0,2), new Posicao(1,1), new Posicao(2,0)});
        }

        /*Verifica se uma condição de vitória em prol do jogador com o marcador existe 
        na configuração atual do tabuleiro. Essa condição é verdadeira se há pelo menos
        duas posições vazias que, se marcada qualquer uma no próximo turno, leva o jogador 
        à vitória contra o seu adversário.
        Retorna true caso haja uma condição de vitória em favor do jogador e false caso isso 
        não se verifique.*/
        private bool CondicaoVitoriaVerificada(Tabuleiro tabuleiro, char marcador) {
            List<Posicao> posicoesCompletamLinha = GetPosicoesCompletamLinhaTabuleiro(
                tabuleiro,
                marcador
            );
            bool vitoriaInevitavel = (posicoesCompletamLinha.Count > 1); 
            return vitoriaInevitavel;
        }

        /*Simula uma partida. A simulação termina quando uma das seguintes condições for
        verificada:
        
            1. Há uma condição de vitória em favor do jogador com o marcador.
         
            2. Não há mais posicões que obriguem o adversário a desarmar ou que possam lhe
               dar uma vitória contra o jogador no próximo turno.
        
        A instancia do tabuleiro no parâmetro é alterada ao longo das recursões do método.
        O marcador do jogador que marcou o tabuleiro pela última vez é retornado pelo método.*/
        private char SimularPartida(Tabuleiro tabuleiro, Posicao posicao, char marcador) {
            //Marca a posição vazia com o marcador no parâmetro...
            tabuleiro.Marcar(posicao.Linha, posicao.Coluna, marcador);
            //Verifica se levou a uma condição de vitória para o jogador com o marcador
            //no parâmetro ao marcá-la...
            if (!CondicaoVitoriaVerificada(tabuleiro, marcador)) {
                //Se não levou a uma condição de vitória em favor do jogador com o
                //marcador definido, é momento de trocar o contexto para
                //simular a jogada do adversário deste jogador.
                char marcadorAdversario = (
                    marcador == this.marcador ?
                    this.marcadorHumano :
                    this.marcador
                );                
                List<Posicao> posicoesCompletamLinha = GetPosicoesCompletamLinhaTabuleiro(
                    tabuleiro,
                    marcador
                );
                //Verifica qual(is) posição(s) completam uma linha do tabuleiro a favor
                //do jogador com o marcador definido. Essas posiçãos serão marcadas
                //considerando-se que o adversário vai desarmá-las.
                if (posicoesCompletamLinha.Count() > 0) {
                    //Usa a recursividade do método para simular a ação do
                    //adversário de desarmar esta linha...
                    Random rnd = new Random();
                    int idx = rnd.Next(posicoesCompletamLinha.Count);
                    posicao = posicoesCompletamLinha[idx];
                    return SimularPartida(tabuleiro, posicao, marcadorAdversario);
                } else {
                    //Não tendo uma linha do tabuleiro que o jogador vai desarmar...
                    //Verifica se o adversário têm a possibilidade de criar uma
                    //condição de vitória a seu favor, e tendo, simula a marcação 
                    //desta posição.
                    List<Posicao> posicoesCriamArmadilha = GetPosicoesLevamVitoria(
                        tabuleiro,
                        marcadorAdversario
                    );
                    if (posicoesCriamArmadilha.Count > 0) {
                        Random rnd = new Random();
                        int idx = rnd.Next(posicoesCriamArmadilha.Count);
                        posicao = posicoesCriamArmadilha[idx];
                        return SimularPartida(tabuleiro, posicao, marcadorAdversario);
                    }
                }
            }
            return marcador;
        }

        /*Verifica se com a marcação da posição definida do tabuleiro, o jogador com o
        marcador passado acaba numa situação de derrota inevitável para o seu adversário.
        Retorna true se a ação levará o jogador a uma condição de derrota, e false, caso 
        não exista este risco.*/
        private bool MarcarPosicaoLevaDerrota(Tabuleiro tabuleiro, Posicao posicao,
        char marcador) {
            //Obtém uma cópia do tabuleiro original...
            Tabuleiro copiaTabuleiro = (Tabuleiro)tabuleiro.Clone();
            //Identifica o jogador do adversário, no contexto do método...
            char marcadorDoAdversario = (
                marcador == this.marcador ?
                this.marcadorHumano :
                this.marcador
            );
            //Simula a marcação da posição definida...
            char ultimoMarcar = SimularPartida(copiaTabuleiro, posicao, marcador);
            //Se na sequência da simulação houver uma condição de vitória...
            if (CondicaoVitoriaVerificada(copiaTabuleiro, ultimoMarcar)) {
                //Se for a favor do jogador adversário a posição oferece risco, 
                //do contrário ela não oferece.
                return (ultimoMarcar == marcadorDoAdversario);
            } else {
                //Na primeira simulação não houve uma condição de vitória...
                List<Posicao> posicoesVazias = GetPosicoesVaziasTabuleiro(copiaTabuleiro);                
                if (posicoesVazias.Count > 0) {                    
                    if (ultimoMarcar == marcador) {
                        //Não houve uma condição de vitória, mas há posições vazias e 
                        //parou na vez do adversário marcar...                        
                        for (int i = 0; i < posicoesVazias.Count; i++) {
                            //Verifica todas as posições vazias nesta cópia do tabuleiro
                            //original, que passou pelo processo de simulação, e foi
                            //alterada, e simula novamente, com o marcador do adversário.
                            //Caso na sequência haja uma condição de vitória a favor do
                            //adversário, então a marcação da posição leva o jogador à                    
                            //derrota para o adversário.
                            Posicao posicaoVazia = posicoesVazias[i];
                            Tabuleiro copiaAlterada = (Tabuleiro) copiaTabuleiro.Clone();
                            SimularPartida(copiaAlterada, posicaoVazia, marcadorDoAdversario);
                            if (CondicaoVitoriaVerificada(copiaAlterada, marcadorDoAdversario)) {
                                return true;
                            }
                        }
                        return false;
                    } else {
                        //Não houve uma condição de vitória na primeira simulação e parou na vez
                        //do jogador marcar. A única forma de avaliar se a posição em questão
                        //oferece risco é se com a marcação de qualquer das posições vazias
                        //restantes leve a uma condição de vitória a favor do seu adversário.                  
                        int contVitoria = 0;
                        for (int i = 0; i < posicoesVazias.Count; i++) {
                            Posicao posicaoVazia = posicoesVazias[i];
                            Tabuleiro copiaAlterada = (Tabuleiro)copiaTabuleiro.Clone();
                            SimularPartida(copiaAlterada, posicaoVazia, marcador);
                            if (CondicaoVitoriaVerificada(copiaAlterada, marcadorDoAdversario)) {
                                ++contVitoria;
                            }
                        }
                        return (contVitoria == posicoesVazias.Count);
                    }
                } else {
                    return false;
                }
            }
        }

        /*Retorna uma lista com todas as posicões vazias na configuração atual 
        do tabuleiro. Se não houver posições vazias, retorna uma lista vazia.*/
        private List<Posicao> GetPosicoesVaziasTabuleiro(Tabuleiro tabuleiro) {
            List<Posicao> posicoesVazias = new List<Posicao>();
            for (int linha = 0; linha < 3; linha++) {
                for (int coluna = 0; coluna < 3; coluna++) {                    
                    if (tabuleiro[linha, coluna] == Tabuleiro.VAZIO) {
                        Posicao posicao = new Posicao(linha, coluna);
                        posicoesVazias.Add(posicao);
                    }
                }
            }
            return posicoesVazias;
        }

        /*Retorna uma posição vazia aleatória do tabuleiro do jogo. Se não houver uma
        posição vazia, retorna null.*/
        private Posicao GetPosicaoVaziaAleatoriaTabuleiro() {
            List<Posicao> posicoesVazias = GetPosicoesVaziasTabuleiro(tabuleiroJogo);
            Posicao posicao = null;
            if (posicoesVazias.Count > 0) {
                Random rnd = new Random();
                int idx = rnd.Next(posicoesVazias.Count);
                posicao = posicoesVazias[idx];
            }
            return posicao;
        }

        /*Recebe as posições de uma linha vertical, horizontal ou diagonal do tabuleiro 
        e verifica a configuração desta linha, de tal forma que se tenha o seguinte:
            
            1 posição qualquer da linha têm o marcador definido.
         
            2 posições da linha estão vazias (sem nenhum marcador).
        
        Se a condição for verificada, retorna as duas posições que estão vazias,senão
        retorna uma lista vazia.*/
        private List<Posicao> GetPosicoesVaziasNaLinhaComMarcador(Tabuleiro tabuleiro, 
        Posicao[] linhaTabuleiro, char marcador) {
            List<Posicao> posicoesVazias = new List<Posicao>();
            int qtdMarcador = 0, qtdVazio = 0, linha, coluna;
            //Conta quantos marcadores e vazios a linha contém.
            for (int i = 0; i < linhaTabuleiro.Count(); i++) {
                Posicao posicao = linhaTabuleiro[i];
                linha = posicao.Linha;
                coluna = posicao.Coluna;
                if (tabuleiro[linha, coluna] != Tabuleiro.VAZIO) {
                    if (tabuleiro[linha, coluna] == marcador) {
                        qtdMarcador++;
                    }                    
                } else {
                    qtdVazio++;    
                }
            }
            //Havendo 1 marcador e 2 vazios, localiza os vazios e retorna.
            if (qtdMarcador == 1 && qtdVazio == 2) {
                for (int i = 0; i < linhaTabuleiro.Count(); i++) {
                    Posicao posicao = linhaTabuleiro[i];
                    linha = posicao.Linha;
                    coluna = posicao.Coluna;
                    if (tabuleiro[linha, coluna] == Tabuleiro.VAZIO) {
                        posicoesVazias.Add(posicao);
                    }
                }
            }
            return posicoesVazias;
        }

        /*Retorna uma lista com todas as posições vazias no tabuleiro, que, se marcadas
        completam uma linha vertical, horizontal ou diagonal com o marcador passado.
        Se não houver posições que satisfaçam à condição, retorna uma lista vazia.*/
        private List<Posicao> GetPosicoesCompletamLinhaTabuleiro(Tabuleiro tabuleiro,
        char marcador) {
            List<Posicao> posicoesVazias = new List<Posicao>();
            int qtdMarcador, qtdVazio, linha, coluna;            
            for (int i = 0; i < linhasTabuleiro.Count; i++) {
                //Conta a quantidade de marcadores e de vazios na linha.
                Posicao[] linhaTabuleiro = linhasTabuleiro[i];
                qtdMarcador = qtdVazio = 0;               
                for (int j = 0; j < linhaTabuleiro.Count(); j++) {
                    Posicao posicao = linhaTabuleiro[j];
                    linha = posicao.Linha;
                    coluna = posicao.Coluna;
                    if (tabuleiro[linha, coluna] != Tabuleiro.VAZIO) {
                        if (tabuleiro[linha, coluna] == marcador) {
                            qtdMarcador++;
                        }
                    } else {
                        qtdVazio++;
                    }
                }
                //Havendo 2 marcadores e 1 vazio, localiza o vazio e adiciona à lista de
                //retorno.
                if (qtdMarcador == 2 && qtdVazio == 1) {                    
                    for (int j = 0; j < linhaTabuleiro.Count(); j++) {
                        Posicao posicao = linhaTabuleiro[j];
                        linha = posicao.Linha;
                        coluna = posicao.Coluna;
                        if (tabuleiro[linha, coluna] == Tabuleiro.VAZIO) {
                            posicoesVazias.Add(posicao);
                            break;
                        }
                    }                    
                }
            }
            return posicoesVazias;
        }

        /*Retorna uma lista com todas as posições vazias do tabuleiro, que, se marcadas
        levam o jogador com aquele marcador a uma condição de vitória a seu favor. Caso 
        não encontre alguma posição vazia que satisfaça a essa condição, retorna uma lista 
        vazia.*/
        private List<Posicao> GetPosicoesLevamVitoria(Tabuleiro tabuleiro, char marcador) {
            List<Posicao> posicoesVitoria = new List<Posicao>();
            List<Posicao> listaAuxiliar = new List<Posicao>();
            for (int i = 0; i < linhasTabuleiro.Count; i++) {
                Posicao[] linhaTabuleiro = linhasTabuleiro[i];
                List<Posicao> posicoesVazias = GetPosicoesVaziasNaLinhaComMarcador(
                    tabuleiro,
                    linhaTabuleiro,
                    marcador
                );
                for (int j = 0; j < posicoesVazias.Count; j++) {
                    Posicao posicao = posicoesVazias[j];
                    if (listaAuxiliar.Contains(posicao)) {
                        if (!posicoesVitoria.Contains(posicao)) {
                            posicoesVitoria.Add(posicao);
                        }
                    } else {
                        listaAuxiliar.Add(posicao);
                    }
                }
            }
            return posicoesVitoria;
        }

        /*Retorna uma lista com todas as posições vazias do tabuleiro
        que levam à condição definida se o tabuleiro receber o marcador.
         
        As condições são as seguintes:
         
            'V': retorna todas as casas vazias que se marcadas com o 
                 marcador, levam o jogador com o mesmo à vitória inevitável
                 nos próximos turnos.
        
            'D': retorna todas as casas vazias que se marcadas com o 
                 marcador, levam o jogador com o mesmo à derrota inevitável 
                 para o seu adversário nos próximos turnos.
        
        Se não houver alguma posição que leve à condição definida, retorna uma
        lista vazia.*/
        private List<Posicao> GetPosicoesNaCondicao(Tabuleiro tabuleiro, char marcador,
        char condicao) {
            //Obtém todas as posições vazias do tabuleiro, que, se marcadas pelo
            //jogador com o marcador passado vão forçar o jogador adversário a 
            //desarmar.
            List<Posicao> posicoesForcamDesarmar = new List<Posicao>();
            for (int i = 0; i < linhasTabuleiro.Count(); i++) {
                Posicao[] linhaTabuleiro = linhasTabuleiro[i];
                List<Posicao> posicoesVazias = GetPosicoesVaziasNaLinhaComMarcador(
                    tabuleiro,
                    linhaTabuleiro,
                    marcador
                );
                for (int j = 0; j < posicoesVazias.Count; j++) {
                    Posicao posicao = posicoesVazias[j];
                    if (!posicoesForcamDesarmar.Contains(posicao)) {
                        posicoesForcamDesarmar.Add(posicao);
                    }
                }
            }
            char marcadorAdversario = (
                marcador == this.marcador ? 
                marcadorHumano: 
                this.marcador
            );
            //Simula o adversário desarmando em cada uma das posições.
            List<Posicao> posicoesCondicao = new List<Posicao>();
            for (int i = 0; i < posicoesForcamDesarmar.Count; i++) {
                Posicao posicao = posicoesForcamDesarmar[i];
                Tabuleiro copiaTabuleiro = (Tabuleiro)tabuleiro.Clone();
                SimularPartida(copiaTabuleiro, (Posicao)posicao.Clone(), marcador);
                switch (condicao) {
                    case 'V': {
                        //A sequência da simulação leva o jogador à vitória.
                        if (CondicaoVitoriaVerificada(copiaTabuleiro, marcador)) {
                            posicoesCondicao.Add(posicao);
                        }
                    } break;
                    case 'D': {
                        //A sequência da simulação leva o jogador à derrota.
                        if (CondicaoVitoriaVerificada(copiaTabuleiro, marcadorAdversario)) {
                            posicoesCondicao.Add(posicao);
                        }
                    } break;
                }
            }
            return posicoesCondicao;
        }

        /*Retorna uma lista com todas as posições vazias do tabuleiro que são seguras de 
        serem marcadas. Uma posição é segura se marcada pelo jogador, não possibilita 
        na sequência a vitória do seu adversário (derrota inevitável). Se não houver posições
        vazias nesta condição, retorna uma lista vazia.*/
        private List<Posicao> GetPosicoesSegurasParaMarcar(Tabuleiro tabuleiro, char marcador) {
            List<Posicao> posicoesVazias = GetPosicoesVaziasTabuleiro(tabuleiro);
            List<Posicao> posicoesSeguras = new List<Posicao>();
            for (int i = 0; i < posicoesVazias.Count; i++) {
                Posicao posicao = posicoesVazias[i];
                if (!MarcarPosicaoLevaDerrota(tabuleiro, posicao, marcador)) {
                    posicoesSeguras.Add(posicao);
                }
            }
            return posicoesSeguras;
        }

        /*Implementação do método abstrato MarcarTabuleiro da classe base Jogador. O
        algoritmo vai analizar a configuração atual do tabuleiro do jogo, e, com base 
        no nível de dificuldade que oferece na partida vai fazer a sua jogada.*/
        public override Posicao MarcarTabuleiro() {
            if (tabuleiroJogo.NumeroPosicoesMarcadas == 0) {
                //Neste caso, não há nenhuma posição do tabuleiro marcada. Vai marcar
                //a primeira posição do tabuleiro. A escolha da posição é aleatória.
                return GetPosicaoVaziaAleatoriaTabuleiro();
            } else {
                List<Posicao> posicoesMarcar;
                posicoesMarcar = GetPosicoesCompletamLinhaTabuleiro(
                    tabuleiroJogo,
                    marcador
                );
                if (posicoesMarcar.Count > 0) {
                    //Vai completar uma linha. Marca e vence o adversário humano.
                    Random rnd = new Random();
                    int idx = rnd.Next(posicoesMarcar.Count);
                    return posicoesMarcar[idx];
                } else {
                    posicoesMarcar = GetPosicoesCompletamLinhaTabuleiro(
                        tabuleiroJogo,
                        marcadorHumano
                    );
                    if (posicoesMarcar.Count > 0) {
                        //Vai desarmar o adversário humano.
                        Random rnd = new Random();
                        int idx = rnd.Next(posicoesMarcar.Count);
                        return posicoesMarcar[idx];
                    }
                }
                //Determina se o computador vai seguir a melhor estratégia na jogada ou não.
                //Se o nível de dificuldade estiver definido como "Expert", o computador sempre
                //segue a melhor estratégia. Do contrário, esta decisão será estatística, sendo 
                //que no nível "Difícil" ele têm uma probabilidade maior de seguir a melhor
                //estratégia que no nível "Fácil".
                bool melhorEstrategia;
                Random random = new Random();
                switch (nivelDificuldade) {
                    case NivelDificuldade.Facil: {
                        int valInt = 1 + random.Next(1000); 
                        melhorEstrategia = (valInt < 400);
                    } break;
                    case NivelDificuldade.Dificil: {
                        int valInt = 1 + random.Next(10000);
                        melhorEstrategia = (valInt < 9500);
                    }break;
                    default: { 
                        melhorEstrategia = true; 
                    } break;
                }
                if (melhorEstrategia) {
                    //Vai seguir a melhor estratégia de jogada...
                    posicoesMarcar = GetPosicoesLevamVitoria(tabuleiroJogo, marcador);
                    if (posicoesMarcar.Count > 0) {
                        //Se há posições que levam a uma situação de vitória a seu favor, 
                        //marca alguma e define a vitória contra o adversário humano no
                        //próximo turno.
                        Random rnd = new Random();
                        int idx = rnd.Next(posicoesMarcar.Count);
                        return posicoesMarcar[idx];
                    } else {
                        posicoesMarcar = GetPosicoesNaCondicao(tabuleiroJogo, this.marcador, 'V');
                        if (posicoesMarcar.Count > 0) {
                            //Se há posições que,se marcadas levam a uma Vitória inevitável 
                            //nos próximos turnos, marca alguma, e define a vitória contra o 
                            //adversário humano.
                            Random rnd = new Random();
                            int idx = rnd.Next(posicoesMarcar.Count);
                            return posicoesMarcar[idx];
                        } else {                                         
                            posicoesMarcar = GetPosicoesSegurasParaMarcar(tabuleiroJogo, marcador);
                            if (posicoesMarcar.Count > 0) {
                                //Marca uma posição qualquer, que não ofereça risco.        
                                Random rnd = new Random();
                                int idx = rnd.Next(posicoesMarcar.Count);
                                return posicoesMarcar[idx];
                            } else {
                                return GetPosicaoVaziaAleatoriaTabuleiro();
                            }
                        }
                    }
                } else {
                    //Não vai seguir a melhor estratégia... 
                    //Impede qualquer chance que o computador tenha de forçar uma vitória contra
                    //o seu oponente humano.
                    List<Posicao> posicoes1 = GetPosicoesNaCondicao(tabuleiroJogo, marcador, 'V');
                    List<Posicao> posicoes2 = GetPosicoesLevamVitoria(tabuleiroJogo, marcador);
                    posicoesMarcar = GetPosicoesVaziasTabuleiro(tabuleiroJogo);
                    for (int i = 0; i < posicoes1.Count; i++) {
                        Posicao posicao = posicoes1[i];
                        posicoesMarcar.Remove(posicao);
                    }
                    for (int i = 0; i < posicoes2.Count; i++) {
                        Posicao posicao = posicoes2[i];
                        posicoesMarcar.Remove(posicao);
                    }
                    if (posicoesMarcar.Count() > 0) {
                        Random rnd = new Random();
                        int idx = rnd.Next(posicoesMarcar.Count);
                        return posicoesMarcar[idx];
                    } else {
                        return GetPosicaoVaziaAleatoriaTabuleiro();
                    }
                }
            }
        }

        /*Propriedade para leitura/escrita do nível de dificuldade que o
        computador vai oferecer na partida.*/
        public NivelDificuldade NivelDificuldade {
            get { return nivelDificuldade; }
            set { nivelDificuldade = value; }
        }

    }

}