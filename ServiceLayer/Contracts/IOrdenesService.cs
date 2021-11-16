using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IOrdenesService
    {
        Task<bool> RegisterDelivery(long orderId);
    }
}
