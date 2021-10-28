using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceLayer.Context
{
    public class LogisticOperatorDbContext : DbContext
    {
        public LogisticOperatorDbContext(DbContextOptions<LogisticOperatorDbContext> options) : base(options)
        {
        }

        public DbSet<Repartidor> Repartidores { get; set; }
        public DbSet<DatosEnvio> DatosEnvios { get; set; }
    }
}
