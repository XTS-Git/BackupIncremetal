using Bkp.Incremental.Application.Enums;

namespace Bkp.Incremental.Application.Dto
{
    public class ItensAgendaDto
    {
        public string Nome { get; set; }
        public TipoItenAgendaEnum TipoIten { get; set; }
        public bool Sucesso { get; set; }
        public DateTime DataUltimoBkp { get; set; }
}
}
