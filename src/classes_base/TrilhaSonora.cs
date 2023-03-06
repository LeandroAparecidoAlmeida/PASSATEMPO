using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Jogos.Classes {

    /*Classe responsável pela execução de efeitos sonoros nos jogos.*/
    public class TrilhaSonora {

        /*Toca uma trilha sonora.*/
        public static void Executar(UnmanagedMemoryStream wavStream) {
            SoundPlayer sp = new SoundPlayer(wavStream);
            sp.Play();
        }

    }

}
