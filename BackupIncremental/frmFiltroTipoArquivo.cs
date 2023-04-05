using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace nsBackup
{
    public partial class frmFiltroTipoArquivo : Form
    {
        public string caminhoOrigem = string.Empty;
        public string selecionados = string.Empty;
        public string retorno = string.Empty;

        public frmFiltroTipoArquivo()
        {
            InitializeComponent();
        }


        static public string buscaExtensoes(string pCaminhoOrigem, string pSelecionados)
        {
            frmFiltroTipoArquivo f = new frmFiltroTipoArquivo();
            f.caminhoOrigem = pCaminhoOrigem;
            f.selecionados = pSelecionados;
            f.criaLista();
            f.ShowDialog();
            return f.retorno;
            
        }

        public void criaLista()
        {
            List<string> lista = listaPastas(caminhoOrigem);
            lista.Sort();
            for (int i = 0; i < lista.Count; i++)
            {
                string[] extencoes = selecionados.Split('|');
                bool checado = false;
                for (int x = 0; x < extencoes.Length; x++)
                {
                    if (lista[i] == extencoes[x].ToLower())
                    {
                        checado = true;
                    }
                }
                lstTipos.Items.Add(new ListItem(lista[i], lista[i]),checado);
            }
            
        }

        private List<string> listaExtensoes(string caminho)
        {
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(caminho);
                FileInfo[] f = diretorio.GetFiles("*.*");
                List<string> listagem = new List<string>();
                foreach (FileInfo arquivo in f)
                {
                    if (arquivo.Attributes != FileAttributes.Directory)
                    {
                        string extensao = string.Format("*{0}", arquivo.Extension.ToLower());
                        if (!listagem.Exists(Extensao(extensao)))
                        {
                            listagem.Add(extensao);
                        }
                    }
                }
                return listagem;
            }
            catch
            {
                throw;
            }
        }


        private List<string> listaPastas(string pPasta)
        {
            List<string> listagem = new List<string>();
           listagem = filtra(listaExtensoes(pPasta), listagem);

            DirectoryInfo d = new DirectoryInfo(pPasta);
            DirectoryInfo[] f = d.GetDirectories();
            foreach (DirectoryInfo pasta in f)
	        {
                listagem = filtra(listaPastas(pasta.FullName), listagem);
        	}
            return listagem;
        }

        private List<string> filtra(List<string> novos, List<string> listagem)
        {
            for (int i = 0; i < novos.Count; i++)
            {
                string extensao = novos[i];
                if (!listagem.Exists(Extensao(extensao)))
                {
                    listagem.Add(extensao);
                }
            }
            return listagem;

        }

        static Predicate<string> Extensao(string qual)
        {
            return delegate(string ext)
            {
                return ext.ToLower() == qual;
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTipos.Items.Count; i++)
            {
                if (lstTipos.GetItemChecked(i))
                {
                    retorno = string.Format("{0}|{1}",retorno,lstTipos.GetItemText(lstTipos.Items[i]));
                }
            }
            retorno = retorno.TrimStart('|').TrimEnd('|');
            this.Close();
        }

    }

    public class ListItem
    {
        public struct FieldNames
        {
            public const string Key = "Key";
            public const string Value = "Value";
        }

        public ListItem(string _key, string _value)
        {
            this.key = _key;
            this.value = _value;
        }

        private string key;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string value;
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return this.value;
        }
    }

}
