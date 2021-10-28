using IAEW_LogisticOperator_Center_API.Utils;

namespace IAEW_LogisticOperator_Center_API.Models
{
   public class DatosEnvio
   {
       public long Id { get; set; }
       public string DireccionOrigen { get; set; }
       public string DireccionDestino { get; set; }
       public string ContactoComprador { get; set; }
       public EstadoEnvio EstadoEnvio { get; set; }
       public string DetalleProducto { get; set; }
       public virtual Repartidor Repartidor { get; set; }
       public long RepartidorId { get; set; }
   }
}
