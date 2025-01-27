using Domain.Interfaces;
using Domain.Entities.Nodes;
using Persistence;

namespace BusinessLogic
{
    // Класс реализующий методы работы с БД из интерфейса INode
    public class NodeDb : INodeDb
    {
        private readonly NodeContext db;

        public NodeDb()
        {
            db = new NodeContext();
        }

        public void Add(Node node)
        {
            if (node != null)
            {
                db.Nodes.Add(node);
                db.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<Node> GetList() => [.. db.Nodes];

        public bool IsNull()
        {
            List<Node> nodes = [.. db.Nodes];
            return nodes.Count == 0;
        }

        public Node AddOneQuantity(int id)
        {
            Node? node = db.Nodes.Find(id);
            if (node != null)
            {
                node.AddOneQuantity();
                db.Nodes.Update(node);
                db.SaveChanges();
                return node;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
