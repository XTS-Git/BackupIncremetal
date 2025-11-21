using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace nsBackup
{

    public class AgendaDto
    {
        public DateTime ProximaExecucao { get; set; }
        public string HoraExecucao { get; set; }
        public string Intervalo { get; set; }
        public string PastaOrigem { get; set; }
        public string PastaDestino { get; set; }
        public string TiposArquivos { get; set; }
        public bool CaminhoCompleto { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public bool Ativo { get; set; }
    }

    public class Agenda
    {
        string arquivoDados = string.Format(@"{0}\Backup\job.json", Environment.GetFolderPath(Environment.SpecialFolder.Personal));

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

        public bool SalvarDados(List<AgendaDto> dados)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dados,Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(arquivoDados, json);
                if (EnviaMsgAgendaAtualizada != null) EnviaMsgAgendaAtualizada(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<AgendaDto> LerDados()
        {
            if (!File.Exists(arquivoDados)) return new List<AgendaDto>();
            string json = File.ReadAllText(arquivoDados);
            List<AgendaDto> lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AgendaDto>>(json);
            return lista;
        }
    }
}
