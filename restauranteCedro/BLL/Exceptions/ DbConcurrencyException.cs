using System;

namespace restauranteCedro.BLL.Exceptions
{
    public class  DbConcurrencyException: ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }

}