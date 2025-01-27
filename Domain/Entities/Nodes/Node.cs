using Domain.Base;
using Domain.Shared.ValueObjects;

namespace Domain.Entities.Nodes
{
    // Строка в БД
    public class Node : BaseEntity
    {
        public Name Name { get; private set; }
        public Quantity Quantity { get; private set; }
        public ParentId ParentId { get; private set; }
        
        public Node(Name name, Quantity quantity, ParentId parentId)
        {
            Name = name;
            Quantity = quantity;
            ParentId = parentId;
        }

        public Node(string name, int quantity = 0, int parentId = 0)
        {
            Name = new Name(name);
            Quantity = new Quantity(quantity);
            ParentId = new ParentId(parentId);
        }

        public void AddOneQuantity() => Quantity.AddOne();

        public override bool Equals(object obj) => obj is Node Node &&
                   EqualityComparer<Name>.Default.Equals(Name, Node.Name) &&
                   EqualityComparer<ParentId>.Default.Equals(ParentId, Node.ParentId) &&
                   EqualityComparer<Quantity>.Default.Equals(Quantity, Node.Quantity);

        public override int GetHashCode() => HashCode.Combine(Name, ParentId, Quantity);
    }
}
