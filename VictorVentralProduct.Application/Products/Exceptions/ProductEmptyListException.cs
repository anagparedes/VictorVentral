using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentralProduct.Application.Products.Exceptions
{
    public class ProductEmptyListException: Exception
    {
        public override string Message { get; }

        public ProductEmptyListException() : base()
        {
            Message = "The list of Products is empty";
        }


    }
}
