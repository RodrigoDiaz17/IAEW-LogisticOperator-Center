using IAEW_LogisticOperator_Center_API.Models;
using PersistanceLayer.Context;
using ServiceLayer.Contracts;
using ServiceLayer.Data_Transfer_Objects;
using ServiceLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Services
{
    public class RepartidoresService: IRepartidoresService
    {
        private readonly LogisticOperatorDbContext _dbContext;

        public RepartidoresService(LogisticOperatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Repartidor repartidor)
        {
            try
            {
                _dbContext.Add(repartidor);

                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear el repartidor", e);
            }

        }

        public bool Update(RepartidorDto repartidor)
        {
            try
            {
                var entity = _dbContext.Find(typeof(Repartidor), repartidor.Id);

                if (entity == null)
                    throw new Exception("El repartidor no existe");

                entity = repartidor.MapToEntity((Repartidor)entity);

                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error al actualizar los datos del repartidor", e);
            }

        }

        public bool Delete(long Idrepartidor)
        {
            try
            {
                var entity = _dbContext.Find(typeof(Repartidor), Idrepartidor);

                if (entity == null)
                    throw new Exception("El repartidor no existe");

                _dbContext.Remove(entity);

                return _dbContext.SaveChanges() > 0;

            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar la mascota", e);
            }
        }

        public Repartidor GetById(long Idrepartidor)
        {
            var entity = _dbContext.Find(typeof(Repartidor), Idrepartidor) as Repartidor;

            if (entity == null)
                throw new Exception("El repartidor no existe");

            return entity;
        }

        public List<Repartidor> GetAll()
        {
            var entities = _dbContext.Repartidores.ToList();

            if (entities == null)
                throw new Exception("No existen repartidores registrados");

            return entities;
        }
    }
}
    