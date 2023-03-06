using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jogos.TorreHanoi.Properties;
using Jogos.Classes;

namespace Jogos.TorreHanoi {

    public partial class TelaTorreHanoi : Form {

        /*Disco no topo de uma pilha que se clicou nele.*/
        private int discoSelecionado;
        /*Status de jogo finalizado.*/
        private bool finalizado;
        /*Mínimo de movimentos para a solução.*/
        private int minimo;
        /*Contagem do número de movimentos realizados.*/
        private int numMovimentos;
        /*Número de discos no teste.*/
        private int numDiscos;
        /*Pilhas de discos (representa as hastes).*/
        private List<int> pilha1;
        private List<int> pilha2;
        private List<int> pilha3;        

        public TelaTorreHanoi() {
            pilha1 = new List<int>();
            pilha2 = new List<int>();
            pilha3 = new List<int>();            
            InitializeComponent();
            pcbHaste1.Tag = 1;
            pcbHaste2.Tag = 2;
            pcbHaste3.Tag = 3;
            //Recupera o valor para quantidade de discos.
            object obj = Config.GetValor("torre_hanoi", "num_discos");
            numDiscos = (obj != null ? (int) obj : 4);
            switch (numDiscos) {
                case 3: cbbNumDiscos.SelectedIndex = 0; break;
                case 4: cbbNumDiscos.SelectedIndex = 1; break;
                case 5: cbbNumDiscos.SelectedIndex = 2; break;
                case 6: cbbNumDiscos.SelectedIndex = 3; break;
            }
            Iniciar();
        }

        /*Obtém a PictureBox relativa à posição relativa em uma haste.
        A contagem é do fundo para o topo (1 é a da base da haste, 6 é
        a do topo).*/
        private PictureBox GetPictureBox(int haste, int posicao) {
            PictureBox pcbox = null;
            switch (haste) {
                case 1: {
                    switch (posicao) {
                        case 1: pcbox = pcbDisco6; break;
                        case 2: pcbox = pcbDisco5; break;
                        case 3: pcbox = pcbDisco4; break;
                        case 4: pcbox = pcbDisco3; break;
                        case 5: pcbox = pcbDisco2; break;
                        case 6: pcbox = pcbDisco1; break;
                    } 
                } break;
                case 2: {
                    switch (posicao) {
                        case 1: pcbox = pcbDisco12; break;
                        case 2: pcbox = pcbDisco11; break;
                        case 3: pcbox = pcbDisco10; break;
                        case 4: pcbox = pcbDisco9; break;
                        case 5: pcbox = pcbDisco8; break;
                        case 6: pcbox = pcbDisco7; break;
                    } 
                } break;
                case 3: {
                    switch (posicao) {
                        case 1: pcbox = pcbDisco18; break;
                        case 2: pcbox = pcbDisco17; break;
                        case 3: pcbox = pcbDisco16; break;
                        case 4: pcbox = pcbDisco15; break;
                        case 5: pcbox = pcbDisco14; break;
                        case 6: pcbox = pcbDisco13; break;
                    }  
                } break;
            }
            return pcbox;
        }

        /*Obtém a imagem relativa a um determinado disco, identificado
        por um número. O diâmetro do disco acompanha o número (1 = menor,
        6 = maior).*/
        private Bitmap GetDisco(int numero) {
            Bitmap bmp = null;
            switch (numero) {
                case 1: bmp = Resources.disco1; break;
                case 2: bmp = Resources.disco2; break;
                case 3: bmp = Resources.disco3; break;
                case 4: bmp = Resources.disco4; break;
                case 5: bmp = Resources.disco5; break;
                case 6: bmp = Resources.disco6; break;
            }
            return bmp;
        }

        /*Imprime as pilhas de discos, em suas respectivas hastes.
        Também atualiza o número de movimentos realizados.*/
        private void ImprimirPilhas() {
            pcbDisco1.Visible = false;
            pcbDisco2.Visible = false;
            pcbDisco3.Visible = false;
            pcbDisco4.Visible = false;
            pcbDisco5.Visible = false;
            pcbDisco6.Visible = false;
            pcbDisco7.Visible = false;
            pcbDisco8.Visible = false;
            pcbDisco9.Visible = false;
            pcbDisco10.Visible = false;
            pcbDisco11.Visible = false;
            pcbDisco12.Visible = false;
            pcbDisco13.Visible = false;
            pcbDisco14.Visible = false;
            pcbDisco15.Visible = false;
            pcbDisco16.Visible = false;
            pcbDisco17.Visible = false;
            pcbDisco18.Visible = false;
            List<int>[] pilhas = new List<int>[] {pilha1, pilha2, pilha3};
            int posicao, haste;
            foreach (List<int> pilha in pilhas) {                
                posicao = 1;
                haste = pilha == pilha1 ? 1 : pilha == pilha2 ? 2 : 3;
                for (int i = (pilha.Count - 1); i >= 0; i--) {                    
                    PictureBox pcbox = GetPictureBox(haste, posicao);                    
                    Bitmap bmp = GetDisco(pilha[i]);
                    pcbox.Image = bmp;
                    pcbox.Tag = pilha[i];
                    pcbox.Visible = true;
                    posicao++;
                }
            }
            lblMovimentos.Text = "NÚM. DE MOVIMENTOS: " + numMovimentos.ToString();
            if (numMovimentos > minimo) {
                lblMovimentos.ForeColor = Color.Red;
            }
        }

        /*Inicia o teste.*/
        private void Iniciar() {
            int [] discos = null;
            finalizado = false; 
            numMovimentos = 0;
            discoSelecionado = 0;
            pilha1.Clear();
            pilha2.Clear();
            pilha3.Clear();     
            //Seleciona discos de diâmetros específicos.
            switch (numDiscos) {
                case 3: {
                    discos = new int[] {1 ,3, 6};
                    minimo = 7;
                } break;
                case 4: {
                    discos = new int[] {1, 2, 4, 6};
                    minimo = 15;
                } break;
                case 5: {
                    discos = new int[] {1, 2, 3, 4, 6};
                    minimo = 31;
                } break;
                default: {
                    discos = new int[] {1, 2, 3, 4, 5, 6};
                    minimo = 63;
                } break;
            }            
            //Empilha todos os discos na haste 1.
            foreach (int disco in discos) pilha1.Add(disco);            
            lblMovimentos.ForeColor = Color.Black;
            lblMensagem.Visible = false;
            this.Cursor = Cursors.Default;
            ImprimirPilhas();
            TrilhaSonora.Executar(Resources.trilha3);
        }

        /*Tratador de evento para clique em algum dos discos nas hastes.*/
        private void DiscoClick(object sender, EventArgs e) {
            if (!finalizado) {
                if (discoSelecionado == 0) {
                    PictureBox pcbox = (PictureBox)sender;
                    int numDisco = (int)pcbox.Tag;
                    int disc1 = 0, disc2 = 0, disc3 = 0;
                    if (pilha1.Count > 0) disc1 = pilha1[0];
                    if (pilha2.Count > 0) disc2 = pilha2[0];
                    if (pilha3.Count > 0) disc3 = pilha3[0];
                    if (numDisco == disc1 || numDisco == disc2 || 
                    numDisco == disc3) {
                        //Só seleciona se o disco está no topo da pilha.
                        discoSelecionado = numDisco;
                        //Altera o cursor para o desenho do disco que foi 
                        //selecionado.
                        Bitmap bmp = GetDisco(numDisco);
                        this.Cursor = new Cursor(bmp.GetHicon());
                        pcbox.Visible = false;
                    }
                }
            }
        }

        /*Tratador de evento para clique na área de uma haste.*/
        private void HasteClick(object sender, EventArgs e) {
            if (discoSelecionado != 0) {                                            
                bool mover = false;
                PictureBox pcbox = (PictureBox)sender;
                int pilha = (int) pcbox.Tag;
                List<int> haste = null;
                switch (pilha) {
                    case 1: haste = pilha1; break;
                    case 2: haste = pilha2; break;
                    case 3: haste = pilha3; break;
                }                
                if (haste.Count > 0) {
                    if (haste[0] > discoSelecionado) {
                        if (!haste.Contains(discoSelecionado)) {                            
                            mover = true;
                        }
                    }
                } else {                  
                    mover = true;
                }                 
                if (mover) {
                    numMovimentos++;
                    //Move um disco de uma haste para a outra.
                    pilha1.Remove(discoSelecionado);
                    pilha2.Remove(discoSelecionado);
                    pilha3.Remove(discoSelecionado);
                    haste.Insert(0, discoSelecionado);                    
                    //Se moveu todos para a haste 3, finaliza o teste.
                    if (pilha3.Count == numDiscos) {
                        finalizado = true;
                        lblMensagem.Visible = true;
                        TrilhaSonora.Executar(Resources.trilha4);
                    } else {                        
                        TrilhaSonora.Executar(Resources.trilha5);
                    }
                } else {
                    TrilhaSonora.Executar(Resources.trilha2);
                }                
                ImprimirPilhas();
                this.Cursor = Cursors.Default; 
                discoSelecionado = 0;
            }
        }

        /*Tratador de evento para alteração no texto do Combobox.*/
        private void cbbNumDiscos_TextChanged(object sender, EventArgs e) {
            int num = Int32.Parse(((ComboBox)sender).Text);
            if (num != numDiscos) {
                numDiscos = num;
                Config.SetValor("torre_hanoi", "num_discos", numDiscos);
            }
            Iniciar();
        }

        /*Tratador de evento para clique no botão Iniciar.*/
        private void btnIniciar_Click(object sender, EventArgs e) {
            Iniciar();
        }

    }

}