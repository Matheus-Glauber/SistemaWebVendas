using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double SalarioBase { get; set; }
        public DateTime DataNascimento { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string name, string email, double salarioBase, DateTime dataNascimento, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            SalarioBase = salarioBase;
            DataNascimento = dataNascimento;
            Departamento = departamento;
        }

        public void AddVenda(RegistroDeVendas venda)
        {
            Vendas.Add(venda);
        }

        public void RemoveVenda(RegistroDeVendas venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalDeVendas(DateTime inicio, DateTime final)
        {
            return Vendas.Where(v => v.Data >= inicio && v.Data <= final).Sum(v => v.Montante);
        }
    }
}
