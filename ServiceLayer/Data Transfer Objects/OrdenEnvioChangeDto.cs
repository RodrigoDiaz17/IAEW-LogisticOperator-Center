using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Data_Transfer_Objects
{
    public class OrdenEnvioChangeDto
    {
        public long orderId { get; set; }
        public string nuevoEstado { get; set; }
        public DateTime fechaDeCambio { get; set; }

    }
}
