using Domain.Entities.Nodes;

namespace Domain.Interfaces
{
    // Интерфейс: метода по работе с БД
    public interface INodeDb
    {
        void Add(Node node);
        Node AddOneQuentity(int id);
        List<Node> GetList();
        bool IsNull();
    }
}
