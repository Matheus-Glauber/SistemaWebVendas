using Microsoft.EntityFrameworkCore.Internal;
using SistemaWebVendas.Models;
using SistemaWebVendas.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebVendas.Data
{
    public class PopulaService
    {
        private SistemaWebVendasContext _context;

        public PopulaService(SistemaWebVendasContext context)
        {
            _context = context;
        }

        public void Popula()
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroDeVendas.Any())
            {
                return; //DB está populado
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletrônicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Laissa Albuquerque", "laissa@gmail.com", 1500.00, new DateTime(1997, 03, 09), d2);
            Vendedor v2 = new Vendedor(2, "Matheus Glauber", "glauber@gmail.com", 1500.00, new DateTime(1995, 08, 21), d2);
            Vendedor v3 = new Vendedor(3, "Lucas  Willian", "lucas@gmail.com", 1400.00, new DateTime(2000, 05, 15), d1);
            Vendedor v4 = new Vendedor(4, "Marta Dayane", "marta@gmail.com", 1400.00, new DateTime(1998, 03, 09), d3);
            Vendedor v5 = new Vendedor(5, "Janine Rodrigues", "janine@gmail.com", 2500.00, new DateTime(1976, 03, 20), d3);
            Vendedor v6 = new Vendedor(6, "Sandraque Glauber", "sandraque@gmail.com", 2500.00, new DateTime(1970, 03, 11), d4);
            Vendedor v7 = new Vendedor(7, "NanaShara", "shara@gmail.com", 1100.00, new DateTime(1997, 06, 09), d3);
            Vendedor v8 = new Vendedor(8, "Julius", "julius@gmail.com", 1100.00, new DateTime(1997, 12, 09), d4);

            RegistroDeVendas rv1 = new RegistroDeVendas(1, new DateTime(20, 08, 03), 5000.00, StatusDeVenda.Faturado, v2);
            RegistroDeVendas rv2 = new RegistroDeVendas(2, new DateTime(20, 08, 03), 1500.00, StatusDeVenda.Pendente, v2);
            RegistroDeVendas rv3 = new RegistroDeVendas(3, new DateTime(20, 08, 03), 1500.00, StatusDeVenda.Faturado, v1);
            RegistroDeVendas rv4 = new RegistroDeVendas(4, new DateTime(20, 08, 03), 6000.00, StatusDeVenda.Pendente, v1);
            RegistroDeVendas rv5 = new RegistroDeVendas(5, new DateTime(20, 08, 03), 200.00, StatusDeVenda.Faturado, v3);
            RegistroDeVendas rv6 = new RegistroDeVendas(6, new DateTime(20, 08, 03), 500.00, StatusDeVenda.Faturado, v4);
            RegistroDeVendas rv7 = new RegistroDeVendas(7, new DateTime(20, 08, 03), 700.00, StatusDeVenda.Faturado, v5);
            RegistroDeVendas rv8 = new RegistroDeVendas(8, new DateTime(20, 08, 03), 100.00, StatusDeVenda.Faturado, v6);
            RegistroDeVendas rv9 = new RegistroDeVendas(9, new DateTime(20, 08, 03), 400.00, StatusDeVenda.Faturado, v7);
            RegistroDeVendas rv10 = new RegistroDeVendas(10, new DateTime(20, 08, 03), 100.00, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv11 = new RegistroDeVendas(11, new DateTime(20, 08, 03), 50.00, StatusDeVenda.Cancelado, v8);
            RegistroDeVendas rv12 = new RegistroDeVendas(12, new DateTime(20, 08, 03), 500.00, StatusDeVenda.Pendente, v6);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.RegistroDeVendas.AddRange(rv1, rv2, rv3, rv4, rv5, rv6, rv7, rv8, rv9, rv10, rv11, rv12);

            _context.SaveChanges();
        }
    }
}
