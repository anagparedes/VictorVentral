namespace VictorVentralCustomer.Application.Customers.Exceptions
{
    public class InvalidCustomerException: Exception
    {
        public override string Message { get; }

        public InvalidCustomerException() : base()
        {
            Message = "Invalid input for Customer";
        }
    }
}
