using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using XTS;
using XTS.Tools;

namespace nsBackup
{
    public class Backup
    {
        DirectoryInfo dir;
        int arquivosCriados=0;
        int pastasCriadas=0;
        // Arquivos log = null;
        string arquivoLog = "";

        public void enviaEmail(string m)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com"); // 465 587
            client.UseDefaultCredentials = false;
            client.Timeout = 10000;
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new NetworkCredential("rcosta.horadocha@gmail.com", "river1234");
            MailMessage mensagemEmail = new MailMessage();
            MailAddress addresFrom = new MailAddress("rcosta.horadocha@gmail.com","Ricardo Costa");
            mensagemEmail.Subject = "Backup Agendado H.A.C.";
            mensagemEmail.BodyEncoding = UTF8Encoding.UTF8;
            mensagemEmail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mensagemEmail.Body = m;
            mensagemEmail.From = addresFrom;
            mensagemEmail.IsBodyHtml = true;
            mensagemEmail.To.Add("exatos@gmail.com");
            // mensagemEmail.To.Add("ricardo.costa@anacosta.com.br");
            client.Send(mensagemEmail);

        }

        /// <summary>
        /// Monta caminho para pasta de maior nivel na raiz do caminho original
        /// </summary>
        /// <param name="pCaminhoOrigem"></param>
        /// <returns></returns>
        private string criaRoot(string pCaminhoOrigem, bool root)
        {
            DirectoryInfo[] conteudoPasta = listaPastas(pCaminhoOrigem);
            string montaCaminho=string.Empty;
            int i=0;
            DirectoryInfo d = conteudoPasta[0].Parent;
            if (root)
            {
                while (true)
                {
                    if (d.Parent != null)
                    {
                        montaCaminho = string.Format("{0}\\{1}", d.Name, montaCaminho);
                        d = d.Parent;
                    }
                    else
                        break;
                }
                montaCaminho = string.Format("Root\\{0}", montaCaminho);
            }
            else
            {
                montaCaminho = string.Format("{0}\\",d.Name);
            }
            return montaCaminho;
        }

        public string start(string pCaminhoOrigem, string pCaminhoDestino, string pTiposArquivos, bool root)
        {

            #region
            //DirectoryInfo[] conteudoPasta = listaPastas(pCaminhoOrigem);
            //string montaCaminho=string.Empty;
            //int i=0;
            //DirectoryInfo d = conteudoPasta[0].Parent;
            //while (true)
            //{
            //    if (d.Parent != null)
            //    {
            //        montaCaminho = string.Format("{0}\\{1}", d.Name, montaCaminho);
            //        d = d.Parent;
            //    }
            //    else
            //        break;
            //}
            //montaCaminho = string.Format("Root\\{0}",montaCaminho);
            // string montaCaminho = criaRoot(pCaminhoOrigem);
            // pCaminhoDestino = string.Format("{0}\\{1}", pCaminhoDestino, montaCaminho);
            #endregion

            pCaminhoDestino = string.Format("{0}\\{1}", pCaminhoDestino, criaRoot(pCaminhoOrigem, root));
            Arquivos.geraLog(string.Format("Inicio Backup {0} Origem: {1} Destino {2}", DateTime.Now, pCaminhoOrigem, pCaminhoDestino));
            backupPasta(pCaminhoOrigem, pCaminhoDestino, pTiposArquivos);
            string a =string.Format("Arquivos Criados {0} - Pastas criadas {1}", arquivosCriados, pastasCriadas);
            Arquivos.geraLog(a);
            Arquivos.geraLog(string.Format("Fim Backup {0}", DateTime.Now));
            return a;
        }

        public void backupPasta(string pPastaOrigem, string pPastaDestino, string arquivos)
        {
            copiaArquivos(pPastaOrigem, pPastaDestino, arquivos);
            DirectoryInfo[] conteudoPasta = listaPastas(pPastaOrigem);
            for (int i = 0; i < conteudoPasta.Length; i++)
            {
                string pastaO = string.Format("{0}\\{1}", pPastaOrigem, conteudoPasta[i].Name);
                string pastaD = string.Format("{0}{1}\\", pPastaDestino, conteudoPasta[i].Name);
                if (conteudoPasta[i].Attributes == FileAttributes.Directory)
                {
                    criaPasta(pastaD);
                    backupPasta(pastaO, pastaD, arquivos);
                }
                // copiaArquivos(pastaO, pastaD, arquivos);

            }
        }

        private void copiaArquivos(string origem, string destino, string arquivos)
        {
            DirectoryInfo info = new DirectoryInfo(origem);
            string[] extencoes = arquivos.Split('|');
            criaPasta(destino);
            for (int i = 0; i < extencoes.Length; i++)
            {
                FileInfo[] filesOrigem = info.GetFiles(extencoes[i]);
                for (int x = 0; x < filesOrigem.Length; x++)
                {
                    FileInfo fileOrigem = filesOrigem[x];
                    string arquivoNoDestino = string.Format("{0}{1}", destino, fileOrigem.Name);
                    try
                    {
                        // verifica se arquivo existe no destino
                        bool copia = false;
                        FileInfo fileDestino = new FileInfo(arquivoNoDestino);
                        if (fileDestino.Exists)
                        {
                            if (fileDestino.LastWriteTime >= fileOrigem.LastWriteTime)
                                continue;
                            else
                                File.Delete(arquivoNoDestino);
                        }
                        File.Copy(fileOrigem.FullName, arquivoNoDestino);
                        arquivosCriados++;
                        Arquivos.geraLog("Criando arquivo " + arquivoNoDestino);
                    }
                    catch (Exception exCopia)
                    {
                        Arquivos.geraLog(string.Format("Erro criando o arquivo {0}: {1}",arquivoNoDestino, exCopia.Message));
                    }
                }
            }

        }


        public bool pastaExiste(string pPasta)
        {
            return Directory.Exists(pPasta);
        }
        public bool criaPasta(string pPasta)
        {
            bool retorno = true;
            if (!pastaExiste(pPasta))
            {
                dir = Directory.CreateDirectory(pPasta);
                if (dir == null)
                {
                    retorno = false;
                }
                else
                {
                    pastasCriadas++;
                }
            }
            return retorno;
        }
        public DirectoryInfo[] listaPastas(string pPasta)
        {
            DirectoryInfo info = new DirectoryInfo(pPasta);
            return info.GetDirectories();
        }

        //public bool existePastaDeDestino(string pPasta)
        //{
        //    return pastaExiste(pPasta);
        //}
        //public bool confirmaPastaNoDestino(string pPasta)
        //{
        //    bool retorno = true;
        //    if (!pastaExiste(pPasta))
        //        if (!criaPasta(pPasta))
        //            return false;
        //    return retorno;
        //}        
        //public FileInfo[] listaArquivos(string pPasta, string pTiposArquivos)
        //{
        //    DirectoryInfo info = new DirectoryInfo(pPasta);
        //    string[] extencoes = pTiposArquivos.Split('|');            
        //    List<FileInfo> files = new List<FileInfo>();
        //    for (int i = 0; i < extencoes.Length; i++)
        //    {                
        //        FileInfo[] aFile = info.GetFiles(extencoes[i]);
        //        for (int x = 0; x < aFile.Length; x++)
        //        {
        //            files.Add(aFile[x]);
        //        }
        //    }
        //    FileInfo[] fi = new FileInfo[files.Count];
        //    for (int y = 0; y < fi.Length; y++)
        //    {
        //        fi[y] = files[y];
        //    }
        //    return fi;
        //}
        
        //public bool arquivoDestinoAntigo(FileInfo origem, FileInfo destino)
        //{
        //    DateTime o = origem.CreationTime;
        //    DateTime d = destino.CreationTime;
        //    if (o > d) return true;
        //    return false;
        //}
    }

    //public class Arquivo
    //{
    //    string caminhoCompleto;
    //    public Arquivo(string pCaminhoCompleto)
    //    {
    //        caminhoCompleto = pCaminhoCompleto;
    //    }

    //    public void salva(string txt)
    //    {
    //        try
    //        {
    //            FileStream fs;

    //            if (!File.Exists(caminhoCompleto))
    //                fs = File.Create(caminhoCompleto);
    //            else
    //                fs = File.Open(caminhoCompleto, FileMode.Append);

    //            StreamWriter sw = new StreamWriter(fs);
    //            sw.WriteLine(txt);
    //            sw.Close();
    //            fs.Close();
    //        }
    //        catch
    //        {
    //            throw;
    //        }
    //        finally
    //        {
    //        }
    //    }
    //}


}

