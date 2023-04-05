using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace nsBackup
{

    public class AgendaDto
    {
        public DateTime ProximaExecucao { get; set; }
        public string horaDaExecucao { get; set; }
        public string pastaOrigem { get; set; }
        public string pastaDestino { get; set; }
        public string tiposArquivos { get; set; }
        public bool caminhoCompleto { get; set; }
        public bool ativo { get; set; }
    }

    public class Agenda
    {
        // string pastaArquivoAgenda = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string arquivoDados = string.Format(@"{0}\Backup\job.dat", Environment.GetFolderPath(Environment.SpecialFolder.Personal));


        public Agenda()
        {
            if (!File.Exists(arquivoDados))
            {
                string pasta = string.Format(@"{0}\Backup", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                DirectoryInfo dir;
                dir = Directory.CreateDirectory(pasta);                
                if (dir == null)
                    throw new Exception("Impossível criar Pasta da agenda");
            }
        }
        public event EventHandler EnviaMsgAgendaAtualizada;

        public bool salvaDados(List<AgendaDto> dados)
        {
            try
            {

                Jobs job = new Jobs();
                FileStream fs;
                if (File.Exists(arquivoDados)) File.Delete(arquivoDados);
                fs = File.Create(arquivoDados);
                StreamWriter sw = new StreamWriter(fs);

                for (int i = 0; i < dados.Count; i++)
                {
                    AgendaDto dto = dados[i];
                    string grava = string.Empty;
                    grava = dto.horaDaExecucao + ";";
                    grava += dto.pastaDestino.Replace("\\", "\\\\") + ";";
                    grava += dto.pastaOrigem.Replace("\\", "\\\\") + ";";
                    grava += job.preparaProximaExecucao(dto.horaDaExecucao).ToString("dd/MM/yyyy hh:mm") + ";"; // dto.ProximaExecucao.ToString() + ";";
                    grava += dto.tiposArquivos + ";";
                    grava += (dto.caminhoCompleto ? "1" : "0") + ";";
                    grava += (dto.ativo ? "1" : "0") + ";";
                    sw.WriteLine(grava);
                }
                sw.Close();
                fs.Close();
                // agendaAtualizada = true;
                if (EnviaMsgAgendaAtualizada != null) EnviaMsgAgendaAtualizada(null, null);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<AgendaDto> lerDados()
        {
            List<AgendaDto> lista = new List<AgendaDto>();
            FileStream fs;
            bool existe = false;
            if (!File.Exists(arquivoDados)) return new List<AgendaDto>();

            fs = File.Open(arquivoDados, FileMode.Open);

            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string linha = sr.ReadLine();
                string[] dados = linha.Split(';');
                AgendaDto dto = new AgendaDto();
                dto.horaDaExecucao =dados[0];
                dto.pastaDestino = dados[1].Replace("\\\\", "\\");
                dto.pastaOrigem = dados[2].Replace("\\\\", "\\");
                dto.ProximaExecucao= Convert.ToDateTime(dados[3]);
                dto.tiposArquivos = dados[4];
                dto.caminhoCompleto = (dados[5]=="1"?true:false);
                dto.ativo = (dados[6] == "1" ? true : false);
                lista.Add(dto);
            }
            sr.Close();
            fs.Close();
            return lista;
        }

    }
}
