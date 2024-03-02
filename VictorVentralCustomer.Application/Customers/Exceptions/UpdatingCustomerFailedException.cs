namespace VictorVentralCustomer.Application.Customers.Exceptions
{
    public class UpdatingCustomerFailedException: Exception
    {
        public override string Message { get; }

        public UpdatingCustomerFailedException() : base()
        {
            Message = "Failed to update customer, check values again";
        }
    }
}
