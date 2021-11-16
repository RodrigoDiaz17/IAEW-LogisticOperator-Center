using IAEW_LogisticOperator_Center_API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public interface IRepartidoresService
    {
        bool Create(Repartidor repartidor);
        bool Update(Repartidor repartidor);
        bool Delete(long petId);
        Repartidor GetById(long petId);
    }
}
