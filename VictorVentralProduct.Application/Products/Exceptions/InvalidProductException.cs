using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentralProduct.Application.Products.Exceptions
{
    public class InvalidProductException: Exception
    {
        public override string Message { get; }

        public InvalidProductException() : base()
        {
            Message = "Invalid input for product";
        }
    }
}
