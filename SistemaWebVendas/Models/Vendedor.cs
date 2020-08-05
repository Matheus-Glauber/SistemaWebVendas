using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SistemaWebVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Display (Name = "Nome")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display (Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        [Display(Name = "Data De Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
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
