namespace FoodOrdering.Domain.Exception
{
    public abstract class DomainExeption : System.Exception
    {
        public DomainExeption(string message)
            : base(message)
        {
        }
    }

    public class DomainNotFoundException : DomainExeption
    {
        public DomainNotFoundException(string message)
            : base(message)
        {
        }
    }
}
