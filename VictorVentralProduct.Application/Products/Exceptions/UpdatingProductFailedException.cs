using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentralProduct.Application.Products.Exceptions
{
    public class UpdatingProductFailedException: Exception
    {
        public override string Message { get; }

        public UpdatingProductFailedException() : base()
        {
            Message = "Failed to update product, check values again";
        }
    }
}
