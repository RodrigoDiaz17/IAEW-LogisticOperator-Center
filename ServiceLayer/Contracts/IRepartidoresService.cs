using IAEW_LogisticOperator_Center_API.Models;
using ServiceLayer.Data_Transfer_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public interface IRepartidoresService
    {
        bool Create(Repartidor repartidor);
        bool Update(RepartidorDto repartidor);
        bool Delete(long Idrepartidor);
        Repartidor GetById(long Idrepartidor);
        List<Repartidor> GetAll();
    }
}
