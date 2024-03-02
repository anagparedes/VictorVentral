namespace VictorVentralCustomer.Application.Customers.Exceptions
{
    public class CustomerNotFoundException: Exception
    {
        public override string Message { get; }

        public CustomerNotFoundException() : base()
        {
            Message = "The Customer is not Found";
        }
    }
}
