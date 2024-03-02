namespace VictorVentralCustomer.Application.Customers.Exceptions
{
    public class CustomerEmptyListException: Exception
    {
        public override string Message { get; }

        public CustomerEmptyListException() : base()
        {
            Message = "The list of Customers is empty";
        }

    }
}
