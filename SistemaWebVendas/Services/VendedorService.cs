﻿using Microsoft.EntityFrameworkCore;
using SistemaWebVendas.Data;
using SistemaWebVendas.Models;
using SistemaWebVendas.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebVendas.Services
{
    public class VendedorService
    {
        private readonly SistemaWebVendasContext _context;

        public VendedorService(SistemaWebVendasContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            obj.Departamento = _context.Departamento.Find(obj.DepartamentoId);
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found.");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcorrenciaException(e.Message);
            }
        }
    }
}
