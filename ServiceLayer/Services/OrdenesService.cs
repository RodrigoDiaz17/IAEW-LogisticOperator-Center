using IAEW_LogisticOperator_Center_API.Models;
using IAEW_LogisticOperator_Center_API.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PersistanceLayer.Context;
using ServiceLayer.Contracts;
using ServiceLayer.Data_Transfer_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class OrdenesService : IOrdenesService
    {
        private readonly LogisticOperatorDbContext _dbContext;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public OrdenesService(LogisticOperatorDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<bool> RegisterDelivery(long orderId)
        {
            try
            {
                var order = _dbContext.OrdenesEnvios.FirstOrDefault(ordenEnvio => ordenEnvio.Id == orderId);
                if (order == null)
                {
                    throw new Exception($"La orden con el id {orderId} no existe");
                }
                order.EstadoEnvio = EstadoEnvio.Entregado;
                if (_dbContext.SaveChanges() > 0)
                {
                    return await NotifyDelivery(orderId);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error", ex);
            }
        }

        public bool Create(OrdenEnvio order)
        {
            try
            {
                _dbContext.Add(order);

                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear el envio", e);
            }

        }

        public OrdenEnvio GetById(long orderId)
        {
            var entity = _dbContext.OrdenesEnvios.FirstOrDefault(orden => orden.Id == orderId);

            if (entity == null)
                throw new Exception("La orden de envío no existe");

            return entity;
        }

        private async Task<bool> NotifyDelivery(long orderId)
        {

            OrdenEnvioChangeDto dto = new OrdenEnvioChangeDto
            {
                orderId = orderId,
                fechaDeCambio = DateTime.Now,
                nuevoEstado = EstadoEnvio.Entregado.GetAttribute<DescriptionAttribute>().Description
            };
            string url = _configuration.GetValue<string>("WebhookUrl");
            string token = _configuration.GetValue<string>("AccessTokenProcesadorEnvios");
            string dtoAsString = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(dtoAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync(url, stringContent);

            return response.IsSuccessStatusCode;
        }

        public bool AssignDelivery(long orderId, long deliveryId)
        {
            var entity = GetById(orderId);

            entity.RepartidorId = deliveryId;
            entity.EstadoEnvio = EstadoEnvio.Transito;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
