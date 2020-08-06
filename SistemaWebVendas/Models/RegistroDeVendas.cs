using SistemaWebVendas.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebVendas.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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
