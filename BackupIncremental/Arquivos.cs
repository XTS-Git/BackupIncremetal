using System;
using System.Diagnostics;
using System.IO;

namespace nsBackup
{
    public static class Arquivos
    {

        public static string pastaPrincipal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string app = Process.GetCurrentProcess().ProcessName;

        /// <summary>
        /// Verifica se pasta de trablho do DB existe, senão cria
        /// </summary>
        /// <param name="pasta"></param>
        public static bool verificaDB(string db)
        {
            if (!Directory.Exists(db))
            {
                try
                {
                    Directory.CreateDirectory(db);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public static byte[] leArquivoByte(string @caminhoCompleto)
        {

            byte[] buff = null;
            FileStream fs = new FileStream(caminhoCompleto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(caminhoCompleto).Length;
            buff = br.ReadBytes((int)numBytes);
            fs.Close();
            return buff;
        }

        public static void salvaArquivoByte(string @caminhoCompleto, byte[] txt)
        {

            FileStream fs = new FileStream(caminhoCompleto, FileMode.Create);
            for (int i = 0; i < txt.Length; i++)
            {
                fs.WriteByte(txt[i]);
            }
            fs.Close();
        }

        public static string[] retornaLinhasArquivo(string @caminhoCompleto)
        {
            string[] a = { };
            if (System.IO.File.Exists(@caminhoCompleto))
            {
                a = System.IO.File.ReadAllLines(@caminhoCompleto);
            }
            return a;
        }
        public static string leArquivo(string @caminhoCompleto)
        {
            FileStream fs;
            string retorno = string.Empty;

            if (File.Exists(@caminhoCompleto))
                fs = File.Open(caminhoCompleto, FileMode.Open);
            else
                return null;
            StreamReader sr = new StreamReader(fs);
            retorno = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return retorno;

        }

        public static void salvaArquivo(string @caminhoCompleto, string txt, bool deletaAnterior)
        {
            FileStream fs = null;
            if (deletaAnterior)
                File.Delete(caminhoCompleto);

            if (!File.Exists(caminhoCompleto))
                fs = File.Create(caminhoCompleto);
            else
                fs = File.Open(caminhoCompleto, FileMode.Append);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(string.Format("{0}", txt));
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Cria/Adiciona arquivo texto para log na pasta Documents, por usuário 
        /// no formato (nome do executavel)_(Data atual).log
        /// </summary>
        /// <param name="texto"></param>
        public static void geraLog(string texto)
        {
            string caminhoCompleto = string.Format("{0}\\{1}_{2}.log", pastaPrincipal, app, DateTime.Now.Date.ToString().Replace("/", "-").Replace("00:00:00", ""));
            FileStream fs = null;

            if (!File.Exists(caminhoCompleto))
                fs = File.Create(caminhoCompleto);
            else
                fs = File.Open(caminhoCompleto, FileMode.Append);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(string.Format("{0}: \n\r {1}", DateTime.Now, texto));
            sw.Close();
            fs.Close();
        }

    }
}
