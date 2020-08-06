using Microsoft.EntityFrameworkCore;
using SistemaWebVendas.Data;
using SistemaWebVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebVendas.Services
{
    public class DepartamentoService
    {
        private readonly SistemaWebVendasContext _context;

        public DepartamentoService(SistemaWebVendasContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAll()
        {
            return await _context.Departamento.OrderBy(dep => dep.Nome).ToListAsync();
        }
    }
}
