using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.EncontrePares {

    /*Guarda uma coordenada da matriz.*/
    class Coordenada {

        private int x;
        private int y;

        public Coordenada(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int X {
            get { return x; }
        }

        public int Y {
            get { return y; }
        }
        
        public override bool Equals(object obj) {
            Coordenada other = (Coordenada)obj;
            return this.x == other.x && this.y == other.y;
        }

    }

}