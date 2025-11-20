using System.ComponentModel;

namespace Bkp.Incremental.Application
{
    public enum IntervaloEnum
    {
        [Description("Agendar Hora")]
        Horario =0,
        [Description("Diário")]
        Diario = 1,
        [Description("Semanal")]
        Semanal = 2,
        [Description("6 em 6 horas")]
        seisHoras = 3,
        [Description("12 em 12 horas")]
        dozeHoras = 4
    }
}
