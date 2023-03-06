using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogos.JogoForca {

    class ItemDicionario {

        private String palavra;
        private List<String> dicas;

        public ItemDicionario(String palavra) {
            dicas = new List<string>();
            this.palavra = palavra;
        }

        public void SetDica(String dica) {
            dicas.Add(dica);
        }

        public String Palavra {
            get { return palavra; }
        }

        public List<String> Dicas {
            get { return dicas; }
        }

    }

}
