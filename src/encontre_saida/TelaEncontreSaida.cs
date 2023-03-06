using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogos.EncontreSaida {

    public partial class TelaEncontreSaida : Form {

        private int[,] matriz;
        private int x1;
        private int x2;

        public TelaEncontreSaida() {
            InitializeComponent();
            x1 = pcbRetang.Bounds.X;
            pcbPos1.Tag  = new Coordenada(0, 0);
            pcbPos2.Tag  = new Coordenada(0, 1);
            pcbPos3.Tag  = new Coordenada(0, 2);
            pcbPos4.Tag  = new Coordenada(0, 3);
            pcbPos5.Tag  = new Coordenada(0, 4);
            pcbPos6.Tag  = new Coordenada(0, 5);
            pcbPos7.Tag  = new Coordenada(0, 6);
            pcbPos8.Tag  = new Coordenada(1, 0);
            pcbPos9.Tag  = new Coordenada(1, 1);
            pcbPos10.Tag = new Coordenada(1, 2);
            pcbPos11.Tag = new Coordenada(1, 3);
            pcbPos12.Tag = new Coordenada(1, 4);
            pcbPos13.Tag = new Coordenada(1, 5);
            pcbPos14.Tag = new Coordenada(1, 6);
            pcbPos15.Tag = new Coordenada(2, 0);
            pcbPos16.Tag = new Coordenada(2, 1);
            pcbPos17.Tag = new Coordenada(2, 2);
            pcbPos18.Tag = new Coordenada(2, 3);
            pcbPos19.Tag = new Coordenada(2, 4);
            pcbPos20.Tag = new Coordenada(2, 5);
            pcbPos21.Tag = new Coordenada(2, 6);
            pcbPos22.Tag = new Coordenada(3, 0);
            pcbPos23.Tag = new Coordenada(3, 1);
            pcbPos24.Tag = new Coordenada(3, 2);
            pcbPos25.Tag = new Coordenada(3, 3);
            pcbPos26.Tag = new Coordenada(3, 4);
            pcbPos27.Tag = new Coordenada(3, 5);
            pcbPos28.Tag = new Coordenada(3, 6);
            pcbPos29.Tag = new Coordenada(4, 0);
            pcbPos30.Tag = new Coordenada(4, 1);
            pcbPos31.Tag = new Coordenada(4, 2);
            pcbPos32.Tag = new Coordenada(4, 3);
            pcbPos33.Tag = new Coordenada(4, 4);
            pcbPos34.Tag = new Coordenada(4, 5);
            pcbPos35.Tag = new Coordenada(4, 6);
            pcbPos36.Tag = new Coordenada(5, 0);
            pcbPos37.Tag = new Coordenada(5, 1);
            pcbPos38.Tag = new Coordenada(5, 2);
            pcbPos39.Tag = new Coordenada(5, 3);
            pcbPos40.Tag = new Coordenada(5, 4);
            pcbPos41.Tag = new Coordenada(5, 5);
            pcbPos42.Tag = new Coordenada(5, 6);
            pcbPos43.Tag = new Coordenada(6, 0);
            pcbPos44.Tag = new Coordenada(6, 1);
            pcbPos45.Tag = new Coordenada(6, 2);
            pcbPos46.Tag = new Coordenada(6, 3);
            pcbPos47.Tag = new Coordenada(6, 4);
            pcbPos48.Tag = new Coordenada(6, 5);
            pcbPos49.Tag = new Coordenada(6, 6);
        }

        private PictureBox GetPictureBox(int i, int j) {
            PictureBox pcb = null;
            switch (i) {
                case 0: {
                    switch (j) {
                        case 0: pcb = pcbPos1; break;
                        case 1: pcb = pcbPos2; break;
                        case 2: pcb = pcbPos3; break;
                        case 3: pcb = pcbPos4; break;
                        case 4: pcb = pcbPos5; break;
                        case 5: pcb = pcbPos6; break;
                        case 6: pcb = pcbPos7; break;
                    }
                } break;
                case 1: {
                    switch (j) {
                        case 0: pcb = pcbPos8; break;
                        case 1: pcb = pcbPos9; break;
                        case 2: pcb = pcbPos10; break;
                        case 3: pcb = pcbPos11; break;
                        case 4: pcb = pcbPos12; break;
                        case 5: pcb = pcbPos13; break;
                        case 6: pcb = pcbPos14; break;
                    }
                } break;
                case 2: {
                    switch (j) {
                        case 0: pcb = pcbPos15; break;
                        case 1: pcb = pcbPos16; break;
                        case 2: pcb = pcbPos17; break;
                        case 3: pcb = pcbPos18; break;
                        case 4: pcb = pcbPos19; break;
                        case 5: pcb = pcbPos20; break;
                        case 6: pcb = pcbPos21; break;
                    }
                } break;
                case 3: {
                    switch (j) {
                        case 0: pcb = pcbPos22; break;
                        case 1: pcb = pcbPos23; break;
                        case 2: pcb = pcbPos24; break;
                        case 3: pcb = pcbPos25; break;
                        case 4: pcb = pcbPos26; break;
                        case 5: pcb = pcbPos27; break;
                        case 6: pcb = pcbPos28; break;
                    }
                } break;
                case 4: {
                    switch (j) {
                        case 0: pcb = pcbPos29; break;
                        case 1: pcb = pcbPos30; break;
                        case 2: pcb = pcbPos31; break;
                        case 3: pcb = pcbPos32; break;
                        case 4: pcb = pcbPos33; break;
                        case 5: pcb = pcbPos34; break;
                        case 6: pcb = pcbPos35; break;
                    }
                } break;
                case 5: {
                    switch (j) {
                        case 0: pcb = pcbPos36; break;
                        case 1: pcb = pcbPos37; break;
                        case 2: pcb = pcbPos38; break;
                        case 3: pcb = pcbPos39; break;
                        case 4: pcb = pcbPos40; break;
                        case 5: pcb = pcbPos41; break;
                        case 6: pcb = pcbPos42; break;
                    }
                } break;
                case 6: {
                    switch (j) {
                        case 0: pcb = pcbPos43; break;
                        case 1: pcb = pcbPos44; break;
                        case 2: pcb = pcbPos45; break;
                        case 3: pcb = pcbPos46; break;
                        case 4: pcb = pcbPos47; break;
                        case 5: pcb = pcbPos48; break;
                        case 6: pcb = pcbPos49; break;
                    }
                } break;
            }
            return pcb;
        }

        private void ImprimirMatriz() {
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++) {

                }
            }
        }

        private void Iniciar() {
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++) {
                    matriz[i, j] = -1;
                }
            }    
        }

        private void Finalizar() {            
            Rectangle r = pcbRetang.Bounds;
            pcbRetang.SetBounds(x1, r.Y, r.Width, r.Height);            
            pcbRetang.Visible = true;
            btnIniciar.Enabled = false;
            x2 = 0;
            tmrSaida.Start();
        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            Finalizar();            
        }

        private void tmrSaida_Tick(object sender, EventArgs e) {
            if (x2 < 22) {
                Rectangle r = pcbRetang.Bounds;
                pcbRetang.SetBounds(r.X + 20, r.Y, r.Width, r.Height);  
                x2++;
            } else {
                ((Timer)sender).Stop();
                pcbRetang.Visible = false;
                btnIniciar.Enabled = true;
            }
        }

    }

}
