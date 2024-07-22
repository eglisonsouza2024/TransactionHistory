using TransactionHistory.Core.DomainObjects;

namespace TransactionHistory.Domain.Entities
{
    public class Account : Entity
    {
        public Person Person { get; private set; }
        public Account() { }
        public Account(Person person) { }
    }
}
