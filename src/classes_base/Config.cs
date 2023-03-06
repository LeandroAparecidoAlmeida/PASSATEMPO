using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Jogos.Classes {
    
    /*Leitura e escrita de configurações dos jogos. Os valores de configuração
    ficarão gravados no Registro do Windows.*/
    public class Config {

        private static String REGKEY = @"Software\Passatempo";

        /*Obtém um valor de configuração.*/
        public static object GetValor(String jogo, String chave) {            
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(REGKEY, true);
            object valor = null;
            if (rk != null) {
                valor = rk.GetValue(jogo + "." + chave, null);
                rk.Close();
                rk.Dispose();
            }             
            return valor;
        }

        /*Define um valor de configuração.*/
        public static void SetValor(String jogo, String chave, object valor) {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(REGKEY, true);
            if (rk == null) rk = Registry.CurrentUser.CreateSubKey(REGKEY);
            rk.SetValue(jogo + "." + chave , valor);
            rk.Close();
            rk.Dispose();
        }

    }

}
