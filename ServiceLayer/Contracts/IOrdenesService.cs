using IAEW_LogisticOperator_Center_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IOrdenesService
    {
        Task<bool> RegisterDelivery(long orderId);
        bool Create(OrdenEnvio order);
        OrdenEnvio GetById(long orderIr);
        bool AssignDelivery(long orderId, long deliveryId);

    }
}
