using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaWebVendas.Models;

namespace SistemaWebVendas.Data
{
    public class SistemaWebVendasContext : DbContext
    {
        public SistemaWebVendasContext (DbContextOptions<SistemaWebVendasContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaWebVendas.Models.Departamento> Departamento { get; set; }
    }
}
