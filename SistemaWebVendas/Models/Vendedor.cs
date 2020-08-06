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
        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter no mínimo {2} e máximo {1} caracteres.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Obrigatório")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido")]
        public string Email { get; set; }

        [Display (Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        [Range(300, 10000, ErrorMessage = "O {0} deve ser entre {1} e {2}")]
        public double SalarioBase { get; set; }

        [Display(Name = "Data De Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} Obrigatório")]
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
