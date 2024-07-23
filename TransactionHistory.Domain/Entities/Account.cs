using TransactionHistory.Core.DomainObjects;

namespace TransactionHistory.Domain.Entities
{
    public class Account : Entity
    {
        public Guid PersonId { get; private set; }
        public Person Person { get; private set; }
        public IList<Transaction>? Transactions { get; set; }

        public Account() { }
        public Account(Person person) { }
    }
}
