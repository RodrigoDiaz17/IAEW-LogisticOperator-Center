using IAEW_LogisticOperator_Center_API.Models;
using ServiceLayer.Data_Transfer_Objects;

using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Mappers
{
    public static class RepartidorMappingExtensions
    {
        public static Repartidor MapToEntity(this RepartidorDto repartidorDto, Repartidor entity = null)
        {
            if(entity == null)
            {
                entity = new Repartidor();
            }
            entity.Nombre = repartidorDto.Nombre;
            return entity;
        }

        public static RepartidorDto MapToDto(this Repartidor repartidor)
        {
            return new RepartidorDto
            {
                Id = repartidor.Id,
                Nombre = repartidor.Nombre
            };
        }
    }
}
