using TransactionHistory.Core.DomainObjects;

namespace TransactionHistory.Domain.Entities
{
    public sealed class Person : Entity
    {
        public string Name { get; private set; }
        public Account? Account { get; set; }

        public Person()
        {
        }

        public Person(string name)
        {
            Name = name;
        }
    }
}
