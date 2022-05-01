namespace FoodOrdering.Application.Exception
{
    public abstract class ApplicationException : System.Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }

    public class ApplicationNotFoundException : ApplicationException
    {
        public ApplicationNotFoundException(string message) : base(message)
        {
        }
    }

    public class ApplicationAlreadyExistsException : ApplicationException
    {
        public ApplicationAlreadyExistsException(string message) : base(message)
        {
        }
    }

    public class ApplicationValidationException : ApplicationException
    {
        public ApplicationValidationException(string message) : base(message)
        {
        }
    }
}
