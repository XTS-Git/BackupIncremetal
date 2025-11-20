using Bkp.Incremental.Application;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace nsBackup
{
    public class Jobs
    {
        public event EventHandler onStart;
        public event EventHandler onStop;

        public bool atualizaAgenda = false;
        Backup backup;
        System.Timers.Timer horarioExecucao = null;

        public List<AgendaDto> agendas;
        public DateTime ultimaVerificacao;

        Agenda agenda;


        private void CarregaJobs()
        {
            agenda = new Agenda();
            agendas = agenda.LerDados();
            if (agendas.Count == 0)
                throw new Exception("Não existe Agenda Criada");

            for (int i = 0; i < agendas.Count; i++)
            {
                agendas[i].ProximaExecucao = PreparaProximaExecucao(agendas[i]);
            }
            atualizaAgenda = false;
        }

        public void Start()
        {
            CarregaJobs();
            horarioExecucao = new System.Timers.Timer();
            horarioExecucao.Interval = 60000; // 1 minuto
            horarioExecucao.Elapsed += HorarioExecucao_Tick;
            horarioExecucao.Enabled = true;
        }

        public DateTime PreparaProximaExecucao(AgendaDto dto)
        {
            DateTime agora = DateTime.Now;
            TimeSpan hora;
            if (!TimeSpan.TryParse(dto.HoraExecucao, out hora))
                hora = new TimeSpan(agora.Hour, agora.Minute, 0);

            DateTime baseHoje = new DateTime(agora.Year, agora.Month, agora.Day, hora.Hours, hora.Minutes, 0);

            IntervaloEnum intervalo = IntervaloEnum.Horario;
            if (!string.IsNullOrWhiteSpace(dto.Intervalo) && Enum.TryParse<IntervaloEnum>(dto.Intervalo, out var parsed))
                intervalo = parsed;

            DateTime proxima;

            switch (intervalo)
            {
                case IntervaloEnum.Horario:
                    proxima = baseHoje;
                    if (proxima <= agora) proxima = proxima.AddDays(1);
                    break;

                case IntervaloEnum.Diario:
                    if (dto.UltimaExecucao != default)
                    {
                        proxima = new DateTime(dto.UltimaExecucao.Year, dto.UltimaExecucao.Month, dto.UltimaExecucao.Day, hora.Hours, hora.Minutes, 0).AddDays(1);
                        while (proxima <= agora) proxima = proxima.AddDays(1);
                    }
                    else
                    {
                        proxima = baseHoje;
                        if (proxima <= agora) proxima = proxima.AddDays(1);
                    }
                    break;

                case IntervaloEnum.Semanal:
                    if (dto.UltimaExecucao != default)
                    {
                        proxima = new DateTime(dto.UltimaExecucao.Year, dto.UltimaExecucao.Month, dto.UltimaExecucao.Day, hora.Hours, hora.Minutes, 0).AddDays(7);
                        while (proxima <= agora) proxima = proxima.AddDays(7);
                    }
                    else
                    {
                        proxima = baseHoje;
                        if (proxima <= agora) proxima = proxima.AddDays(1);
                    }
                    break;

                case IntervaloEnum.seisHoras:
                    {
                        DateTime t = baseHoje;
                        if (t <= agora)
                        {
                            while (t <= agora)
                                t = t.AddHours(6);
                        }
                        proxima = t;
                    }
                    break;

                case IntervaloEnum.dozeHoras:
                    {
                        DateTime t = baseHoje;
                        if (t <= agora)
                        {
                            while (t <= agora)
                                t = t.AddHours(12);
                        }
                        proxima = t;
                    }
                    break;

                default:
                    proxima = baseHoje;
                    if (proxima <= agora) proxima = proxima.AddDays(1);
                    break;
            }
            return new DateTime(proxima.Year, proxima.Month, proxima.Day, proxima.Hour, proxima.Minute, 0);
        }

        void HorarioExecucao_Tick(object sender, EventArgs e)
        {
            horarioExecucao.Enabled = false;
            try
            {
                if (atualizaAgenda) CarregaJobs();

                DateTime agora = DateTime.Now;
                agora = Convert.ToDateTime(Convert.ToDateTime(agora.ToString()).ToString("dd/MM/yyyy HH:mm"));
                ultimaVerificacao = agora;
                bool executou = false;
                for (int i = 0; i < agendas.Count; i++)
                {
                    if (!agendas[i].Ativo)
                        continue;
                    if (agora == agendas[i].ProximaExecucao)
                    {
                        agendas[i] = ExecutaBackup(agendas[i]);
                        executou = true;
                    }
                }
                if (executou && agenda != null && agendas != null)
                {
                    try
                    {
                        agenda.SalvarDados(agendas);
                    }
                    catch
                    {
                        // evitar que falha de I/O quebre o timer
                    }
                }
                horarioExecucao.Enabled = true;
            }
            catch
            {
                throw;
            }
        }

        public AgendaDto ExecutaBackup(AgendaDto dto)
        {
            if (onStart != null) onStart(this, null);
            backup = new Backup();
            string s = backup.start(dto.PastaOrigem, dto.PastaDestino, dto.TiposArquivos, dto.CaminhoCompleto);
            dto.ProximaExecucao = PreparaProximaExecucao(dto);
            dto.UltimaExecucao = DateTime.Now;
            if (onStop != null) onStop(this, null);
            return dto;
        }


    }
}
