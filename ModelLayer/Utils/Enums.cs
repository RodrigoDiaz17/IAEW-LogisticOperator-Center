using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IAEW_LogisticOperator_Center_API.Utils
{
    public enum EstadoEnvio
    {
        [Description("Creado")]
        Creado,
        [Description("En tránsito")]
        Transito,
        [Description("Entregado")]
        Entregado
    }
}