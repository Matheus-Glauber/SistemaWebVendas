using SistemaWebVendas.Models.Enums;
using System;

namespace SistemaWebVendas.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Montante { get; set; }
        public StatusDeVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVendas()
        {
        }

        public RegistroDeVendas(int id, DateTime data, double montante, StatusDeVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Montante = montante;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
