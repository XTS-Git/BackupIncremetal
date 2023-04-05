using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Timers;

namespace nsBackup
{

    public enum Intervalo
    {
        Horario,
        Diario,
        Semanal,
        Mensal
    }



    public class Jobs
    {
        public event EventHandler onStart;
        public event EventHandler onStop;

        public bool atualizaAgenda = false;
        Backup backup;
        Timer horarioExecucao=null;

        public List<AgendaDto> agendas;
        public DateTime ultimaVerificacao;
       
        Agenda agenda;


        private void carregaJobs()
        {
            agenda = new Agenda();
            agendas = agenda.lerDados();
            for (int i = 0; i < agendas.Count; i++)
            {
                agendas[i].ProximaExecucao = preparaProximaExecucao(agendas[i].horaDaExecucao);
            }
            atualizaAgenda = false;
        }

        public void start()
        {
            carregaJobs();
            horarioExecucao = new Timer();
            horarioExecucao.Interval = 60000; // 1 minuto
            horarioExecucao.Elapsed += horarioExecucao_Tick;
            horarioExecucao.Enabled = true;
        }

        public DateTime preparaProximaExecucao(string hora)
        {
            DateTime hoje = DateTime.Now.Date;
            DateTime agora = DateTime.Now;
            
            string soData = hoje.ToString().Replace("00:00:00", "").Trim();
            DateTime proxima = Convert.ToDateTime(string.Format("{0} {1}", soData, hora));
            if (proxima < agora) proxima = proxima.AddDays(1);
            return proxima;
        }

        void horarioExecucao_Tick(object sender, EventArgs e)
        {
            // bool executou = false;
            horarioExecucao.Enabled = false;
            try
            {
                if (atualizaAgenda)
                    carregaJobs();
                DateTime agora = DateTime.Now;
                agora = Convert.ToDateTime(Convert.ToDateTime(agora.ToString()).ToString("dd/MM/yyyy HH:mm"));
                ultimaVerificacao = agora;
                for (int i = 0; i < agendas.Count; i++)
                {
                    if (!agendas[i].ativo)
                        continue;
                    if (agora == agendas[i].ProximaExecucao)
                    {
                        agendas[i] = executaBackup(agendas[i]);
                        // executou = true;
                    }
                }
                horarioExecucao.Enabled = true;
            }
            catch
            {

                throw;
            }
        }

        public AgendaDto executaBackup(AgendaDto dto)
        {
            if (onStart != null) onStart(this, null);
            backup = new Backup();
            string s = backup.start(dto.pastaOrigem, dto.pastaDestino, dto.tiposArquivos, dto.caminhoCompleto);
            dto.ProximaExecucao = preparaProximaExecucao(dto.horaDaExecucao);
            if (onStop != null)  onStop(this, null);
            return dto;

        }


    }
}
