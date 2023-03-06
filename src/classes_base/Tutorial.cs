using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogos.Classes {

    public class Tutorial {

        public static void Show(String path, String titulo) {
            //Utilitário criado para abrir os arquivos de ajuda do sistema.
            //Espera como 1º parâmetro o caminho do arquivo principal
            //da ajuda, e 2º o texto que vai aparecer na barra de títulos do
            //Browser.
            String app = Application.StartupPath + @"\help.exe";
            //1º parâmetro: arquivo de ajuda: [root_dir]\help\index.html
            String html = "\"" + Application.StartupPath + @"\help\" + path + "\"";
            //2º parâmetro: texto da barra de títulos do Browser.
            String texto = "\"" + titulo + "\"";
            //Chama Help.exe, passando estes parâmetros.
            System.Diagnostics.Process.Start(app, html + " " + texto); 
        }

    }

}