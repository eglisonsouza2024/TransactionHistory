using TransactionHistory.Core.DomainObjects;

namespace TransactionHistory.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; private set; }

        public Person()
        {
        }

        public Person(string name)
        {
            Name = name;
        }
    }
}
