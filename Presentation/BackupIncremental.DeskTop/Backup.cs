using System;
using System.IO;

namespace nsBackup
{
    public class Backup
    {
        DirectoryInfo dir;
        int arquivosCriados = 0;
        int pastasCriadas = 0;

        public string start(string pCaminhoOrigem, string pCaminhoDestino, string pTiposArquivos, bool root)
        {
            Arquivos.geraLog(string.Format("Inicio Backup {0} Origem: {1} Destino {2}", DateTime.Now, pCaminhoOrigem, pCaminhoDestino));
            backupPasta(pCaminhoOrigem, pCaminhoDestino, pTiposArquivos);
            string a = string.Format("Arquivos Criados {0} - Pastas criadas {1}", arquivosCriados, pastasCriadas);
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
                string pastaOrigem = Path.Combine(pPastaOrigem, conteudoPasta[i].Name);
                string pastaDestino = Path.Combine(pPastaDestino, conteudoPasta[i].Name);
                criaPasta(pastaDestino);
                backupPasta(pastaOrigem, pastaDestino, arquivos);
            }
        }

        private void copiaArquivos(string origem, string destino, string arquivos)
        {
            DirectoryInfo info = new DirectoryInfo(origem);
            string[] extencoes = (string.IsNullOrWhiteSpace(arquivos) ? "*.*" : arquivos).Split(new[] { '|', ';' }, StringSplitOptions.RemoveEmptyEntries);
            criaPasta(destino);
            for (int i = 0; i < extencoes.Length; i++)
            {
                FileInfo[] filesOrigem = info.GetFiles(extencoes[i]);
                for (int x = 0; x < filesOrigem.Length; x++)
                {
                    FileInfo fileOrigem = filesOrigem[x];
                    string arquivoNoDestino = Path.Combine(destino, fileOrigem.Name);
                    bool copia = false;
                    FileInfo infoArquivoDestino = new FileInfo(arquivoNoDestino);
                    try
                    {
                        if (infoArquivoDestino.Exists)
                        {
                            bool mesmoTamanho = infoArquivoDestino.Length == fileOrigem.Length;
                            bool destinoRecente = infoArquivoDestino.LastWriteTimeUtc >= fileOrigem.LastWriteTimeUtc;
                            if (mesmoTamanho && destinoRecente)
                                continue;
                        }
                        File.Copy(fileOrigem.FullName, arquivoNoDestino);
                        arquivosCriados++;
                        Arquivos.geraLog("Criando arquivo " + arquivoNoDestino);
                    }
                    catch (Exception exCopia)
                    {
                        Arquivos.geraLog(string.Format("Erro criando o arquivo {0}: {1}", arquivoNoDestino, exCopia.Message));
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
    }
}

