using Microsoft.EntityFrameworkCore;
using SistemaWebVendas.Data;
using SistemaWebVendas.Models;
using SistemaWebVendas.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebVendas.Services
{
    public class VendedorService
    {
        private readonly SistemaWebVendasContext _context;

        public VendedorService(SistemaWebVendasContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAll()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task Insert(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindById(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Remove(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegridadeException(e.Message + " Causa - Não é possível excluir um vendedor, pois o mesmo possui vendas");
            }
        }

        public async Task Update(Vendedor obj)
        {
            if(!await _context.Vendedor.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found.");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcorrenciaException(e.Message);
            }
        }
    }
}
