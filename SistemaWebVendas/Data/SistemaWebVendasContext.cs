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

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroDeVendas> RegistroDeVendas { get; set; }
    }
}
