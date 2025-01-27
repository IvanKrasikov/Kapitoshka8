using Domain.Base;
using Domain.Shared.ValueObjects;

namespace Domain.Entities.Nodes
{
    // Строка в БД
    public class Node : BaseEntity
    {
        public Name Name { get; private set; }
        public Quentity Quentity { get; private set; }
        public ParentId ParentId { get; private set; }
        
        public Node(Name name, Quentity quentity, ParentId parentId)
        {
            Name = name;
            Quentity = quentity;
            ParentId = parentId;
        }

        public Node(string name, int quentity = 0, int parentId = 0)
        {
            Name = new Name(name);
            Quentity = new Quentity(quentity);
            ParentId = new ParentId(parentId);
        }

        public void AddOneQuentity() => Quentity.AddOne();

        public override bool Equals(object obj) => obj is Node Node &&
                   EqualityComparer<Name>.Default.Equals(Name, Node.Name) &&
                   EqualityComparer<ParentId>.Default.Equals(ParentId, Node.ParentId) &&
                   EqualityComparer<Quentity>.Default.Equals(Quentity, Node.Quentity);

        public override int GetHashCode() => HashCode.Combine(Name, ParentId, Quentity);
    }
}
