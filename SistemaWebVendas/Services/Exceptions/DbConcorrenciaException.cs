using System;

namespace SistemaWebVendas.Services.Exceptions
{
    public class DbConcorrenciaException : ApplicationException
    {
        public DbConcorrenciaException(string message) : base(message)
        {

        }
    }
}
