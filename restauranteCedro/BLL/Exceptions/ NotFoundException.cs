using System;

namespace restauranteCedro.BLL.Exceptions
{
    public class  NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

}