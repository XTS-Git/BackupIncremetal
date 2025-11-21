namespace Bkp.Incremental.Application.Dto
{
    public class AgendaDto
    {
        public DateTime ProximaExecucao { get; set; }
        public string HoraExecucao { get; set; }
        public string Intervalo { get; set; }
        public string PastaOrigem { get; set; }
        public string PastaDestino { get; set; }
        public string TiposArquivos { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public bool Ativo { get; set; }
        public List<ItensAgendaDto>? ItensAddAgenda { get; set; }
        public List<ItensAgendaDto>? ItensDelAgenda { get; set; }
    }
}
