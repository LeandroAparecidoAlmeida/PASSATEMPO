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
using System.IO;
using Jogos.JogoForca.Properties;

namespace Jogos.JogoForca {

    public partial class TelaJogoForca : Form {
     
        /*Número máximo de letras erradas.*/
        private const int  MAX_ERROS = 6;
        /*Marcador de espaços vazios na palavra que está sendo gerada.*/
        private const char VAZIO = '\0';
        /*Palavra sorteada aleatóriamente do dicionário.*/
        private String palavraSorteada;    
        /*Número de letras erradas ao tentar adivinhar a palavra.*/
        private int letrasErradas; 
        /*Número de palavras que o jogador acertou.*/
        private int numeroAcertos;
        /*Número de palavras que o jogador errou (foi enforcado).*/
        private int numeroErros;
        /*Caracteres da palavra sorteada. Representa as linhas ao lado da forca.*/
        private char[] palavra;
        /*Lista de palavras do dicionário.*/
        private List<ItemDicionario> itensDicionario;
        /*Texto lido do arquivo de dicionário*/
        private String textoDicionario;

        /*Constructor. Obtém as palavras do dicionário e sorteia uma.*/
        public TelaJogoForca() {            
            InitializeComponent();
            numeroAcertos = 0;
            numeroErros = 0;
            lblNumAcertos.Text = numeroAcertos.ToString();
            lblNumErros.Text = numeroErros.ToString();
            itensDicionario = new List<ItemDicionario>();
            textoDicionario = Resources.dicionario;
            //Carrega as palavras para o dicionário.
            CarregarDicionario();
            //Sorteia uma palavra.
            SortearPalavra();          
        }

        /*Obtém as palavras ques estão no dicionário, com suas respectivas
        dicas.*/
        private void CarregarDicionario() {
            String[] linhas = textoDicionario.Split(new char[]{'\n'});
            foreach (String linha in linhas) {
                String[] item = linha.Split(new char[]{'='});
                String palavra = item[0];
                ItemDicionario itemDic = new ItemDicionario(palavra);
                String[] dicas = item[1].Split(new char[]{'|'});
                foreach (String dica in dicas) {
                    itemDic.SetDica(dica);
                }
                itensDicionario.Add(itemDic);
            }
        }

        /*Habilita/Desabilita os botões do teclado alfabético.*/
        private void HabilitarTeclado(bool status) {
            teclaA.Enabled = status;
            teclaB.Enabled = status;
            teclaC.Enabled = status;
            teclaD.Enabled = status;
            teclaE.Enabled = status;
            teclaF.Enabled = status;
            teclaG.Enabled = status;
            teclaH.Enabled = status;
            teclaI.Enabled = status;
            teclaJ.Enabled = status;
            teclaK.Enabled = status;
            teclaL.Enabled = status;
            teclaM.Enabled = status;
            teclaN.Enabled = status;
            teclaO.Enabled = status;
            teclaP.Enabled = status;
            teclaQ.Enabled = status;
            teclaR.Enabled = status;
            teclaS.Enabled = status;
            teclaT.Enabled = status;
            teclaU.Enabled = status;
            teclaV.Enabled = status;
            teclaX.Enabled = status;
            teclaW.Enabled = status;
            teclaY.Enabled = status;
            teclaZ.Enabled = status;
        }

        private void AlterarCorPalavra(Color cor) {
            letra1.ForeColor = cor;
            letra2.ForeColor = cor;
            letra3.ForeColor = cor;
            letra4.ForeColor = cor;
            letra5.ForeColor = cor;
            letra6.ForeColor = cor;
            letra7.ForeColor = cor;
            letra8.ForeColor = cor;
            letra9.ForeColor = cor;
            letra10.ForeColor = cor;
            letra11.ForeColor = cor;
            letra12.ForeColor = cor;
            letra13.ForeColor = cor;
            letra14.ForeColor = cor;
        }

        /*Limpa os campos para exibição da palavra sorteada (linhas ao lado da forca).*/
        private void LimparPalavra() {
            letra1.Visible = false;
            letra2.Visible = false;
            letra3.Visible = false;
            letra4.Visible = false;
            letra5.Visible = false;
            letra6.Visible = false;
            letra7.Visible = false;
            letra8.Visible = false;
            letra9.Visible = false;
            letra10.Visible = false;
            letra11.Visible = false;
            letra12.Visible = false;
            letra13.Visible = false;
            letra14.Visible = false;            
            linha1.Visible = false;
            linha2.Visible = false;
            linha3.Visible = false;
            linha4.Visible = false;
            linha5.Visible = false;
            linha6.Visible = false;
            linha7.Visible = false;
            linha8.Visible = false;
            linha9.Visible = false;
            linha10.Visible = false;
            linha11.Visible = false;
            linha12.Visible = false;
            linha13.Visible = false;
            linha14.Visible = false;
        }

        /*Exibe a palavra no campo de exibição (linhas ao lado da forca).*/
        private void ImprimirPalavra(char[] palavra) {
            for (int i = 0; i < palavra.Length; i++) {
                if (!palavra[i].Equals(VAZIO) && !palavra[i].Equals('-')) {
                    String letra = new String(palavra[i], 1);
                    switch (i) {
                        case 0: letra1.Text = letra; break;
                        case 1: letra2.Text = letra; break;
                        case 2: letra3.Text = letra; break;
                        case 3: letra4.Text = letra; break;
                        case 4: letra5.Text = letra; break;
                        case 5: letra6.Text = letra; break;
                        case 6: letra7.Text = letra; break;
                        case 7: letra8.Text = letra; break;
                        case 8: letra9.Text = letra; break;
                        case 9: letra10.Text = letra; break;
                        case 10: letra11.Text = letra; break;
                        case 11: letra12.Text = letra; break;
                        case 12: letra13.Text = letra; break;
                        case 13: letra14.Text = letra; break;
                    }
                }
            }
        }

        /*Obtém uma nova palavra do dicionário.*/
        private void SortearPalavra() {            
            Random rnd = new Random();
            if (itensDicionario.Count == 0) {
                //Dicionário vazio... 
                //Lista todas as palavras de novo.
                CarregarDicionario();
            }
            //Obtém a nova palavra.
            int idxItem = rnd.Next(itensDicionario.Count);
            ItemDicionario itemDic = itensDicionario[idxItem];
            palavraSorteada = itemDic.Palavra;
            List<String> dicas = itemDic.Dicas;
            int idxDica = rnd.Next(dicas.Count);
            lblTextoDica.Text = dicas[idxDica];
            //Remove a palavra para não ser sorteada outra vez.
            itensDicionario.RemoveAt(idxItem);
            palavra = null;
            //Prepara o sistema para a nova palavra.
            palavra = new char[palavraSorteada.Length];
            letrasErradas = 0;
            pcbBoneco.Visible = false;
            HabilitarTeclado(true);
            LimparPalavra();
            AlterarCorPalavra(Color.Black);         
            for (int i = 0; i < palavraSorteada.Length; i++) {
                Label linha = null;
                Label letra = null;
                switch (i) {
                    case  0: {linha = linha1;  letra = letra1;} break;
                    case  1: {linha = linha2;  letra = letra2;} break;
                    case  2: {linha = linha3;  letra = letra3;} break;
                    case  3: {linha = linha4;  letra = letra4;} break;
                    case  4: {linha = linha5;  letra = letra5;} break;
                    case  5: {linha = linha6;  letra = letra6;} break;
                    case  6: {linha = linha7;  letra = letra7;} break;
                    case  7: {linha = linha8;  letra = letra8;} break;
                    case  8: {linha = linha9;  letra = letra9;} break;
                    case  9: {linha = linha10; letra = letra10;} break;
                    case 10: {linha = linha11; letra = letra11;} break;
                    case 11: {linha = linha12; letra = letra12;} break;
                    case 12: {linha = linha13; letra = letra13;} break;
                    case 13: {linha = linha14; letra = letra14;} break;
                }
                letra.Visible = true;
                if (palavraSorteada[i].Equals('-')) {
                    //Marca as posições dos hífens.
                    linha.Visible = false;
                    letra.Text = "-";
                    palavra[i] = '-';                    
                } else {
                    //Exibe as linhas nas posições das letras.
                    linha.Visible = true;
                    letra.Text = "";
                    palavra[i] = VAZIO;
                }
            }
            TrilhaSonora.Executar(Resources.trilha1);
        }

        /*Trata uma letra clicada no teclado.*/
        private void TratarTecla(char letra) {
            switch (letra) {
                case 'A': teclaA.Enabled = false; break;
                case 'B': teclaB.Enabled = false; break;
                case 'C': teclaC.Enabled = false; break;
                case 'D': teclaD.Enabled = false; break;
                case 'E': teclaE.Enabled = false; break;
                case 'F': teclaF.Enabled = false; break;
                case 'G': teclaG.Enabled = false; break;
                case 'H': teclaH.Enabled = false; break;
                case 'I': teclaI.Enabled = false; break;
                case 'J': teclaJ.Enabled = false; break;
                case 'K': teclaK.Enabled = false; break;
                case 'L': teclaL.Enabled = false; break;
                case 'M': teclaM.Enabled = false; break;
                case 'N': teclaN.Enabled = false; break;
                case 'O': teclaO.Enabled = false; break;
                case 'P': teclaP.Enabled = false; break;
                case 'Q': teclaQ.Enabled = false; break;
                case 'R': teclaR.Enabled = false; break;
                case 'S': teclaS.Enabled = false; break;
                case 'T': teclaT.Enabled = false; break;
                case 'U': teclaU.Enabled = false; break;
                case 'V': teclaV.Enabled = false; break;
                case 'X': teclaX.Enabled = false; break;
                case 'W': teclaW.Enabled = false; break;
                case 'Y': teclaY.Enabled = false; break;
                case 'Z': teclaZ.Enabled = false; break;
            }
            int numPosicoes = 0;
            for (int i = 0; i < palavraSorteada.Length; i++) {
                Char charI;
                //Adapta os caracteres com pontuação na palavra.
                switch (palavraSorteada[i]) {
                    case 'Ç': charI = 'C'; break;
                    case 'À': charI = 'A'; break;
                    case 'Á': charI = 'A'; break;
                    case 'Ã': charI = 'A'; break;
                    case 'Â': charI = 'A'; break;
                    case 'É': charI = 'E'; break;
                    case 'Ê': charI = 'E'; break;
                    case 'Í': charI = 'I'; break;
                    case 'Ú': charI = 'U'; break;
                    case 'Ü': charI = 'U'; break;
                    case 'Ó': charI = 'O'; break;
                    case 'Õ': charI = 'O'; break;
                    case 'Ô': charI = 'O'; break;
                    default: charI = palavraSorteada[i]; break;
                }
                //Verifica se a palavra sorteada contém aquela letra.
                if (charI.Equals(letra)) {
                    palavra[i] = palavraSorteada[i];
                    numPosicoes++;
                }
            }
            if (numPosicoes > 0) {                
                //A palavra contém a letra...
                //Imprime a palavra (que está sendo construída, pode ter espaços
                //vazios).
                ImprimirPalavra(palavra);
                String str = new String(palavra);                
                if (!str.Contains(VAZIO)) {
                    //Se todos os espaços vazios foram substituídos, o jogador 
                    //acertou a palavra.
                    numeroAcertos++;
                    HabilitarTeclado(false);
                    AlterarCorPalavra(Color.Green);
                    lblNumAcertos.Text = numeroAcertos.ToString();
                    lblNumErros.Text = numeroErros.ToString();
                    TrilhaSonora.Executar(Resources.trilha4);
                } else {
                    TrilhaSonora.Executar(Resources.trilha2);
                }
            } else {                
                //A letra selecionada não pertence à palavra...
                //Inclementa a quantidade de erros e desenha o boneco na forca.
                letrasErradas++;
                if (!pcbBoneco.Visible) pcbBoneco.Visible = true;
                switch (letrasErradas) {
                    case 1: pcbBoneco.Image = Resources.boneco01; break;
                    case 2: pcbBoneco.Image = Resources.boneco02; break;
                    case 3: pcbBoneco.Image = Resources.boneco03; break;
                    case 4: pcbBoneco.Image = Resources.boneco04; break;
                    case 5: pcbBoneco.Image = Resources.boneco05; break;
                    case 6: pcbBoneco.Image = Resources.boneco06; break;
                }             
                if (letrasErradas == MAX_ERROS) {
                    //Completou 6 erros... Está enforcado.
                    numeroErros++;
                    HabilitarTeclado(false);
                    AlterarCorPalavra(Color.Red);
                    ImprimirPalavra(palavraSorteada.ToArray());
                    lblNumAcertos.Text = numeroAcertos.ToString();
                    lblNumErros.Text = numeroErros.ToString();
                    TrilhaSonora.Executar(Resources.trilha5);
                } else {
                    TrilhaSonora.Executar(Resources.trilha3);
                }
            }
        }

        /*Tratador de evento para o clique no botão Nova Palavra*/
        private void btnNovaPalavra_Click(object sender, EventArgs e) {
            SortearPalavra();
        }

        /*Tratador de evento para todos os botões que compõem o teclado
        alfabético.*/
        private void LetraAlfabetoClick(object sender, EventArgs e) {
            Button button = (Button) sender;
            char letraBotao = button.Text[0]; 
            TratarTecla(letraBotao);
        }

    }

}
