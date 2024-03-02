using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentralProduct.Application.Products.Exceptions
{
    public class ProductNotFoundException: Exception
    {
        public override string Message { get; }

        public ProductNotFoundException() : base()
        {
            Message = "The Product is not Found";
        }

    }
}
