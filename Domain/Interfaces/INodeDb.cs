using Domain.Entities.Nodes;

namespace Domain.Interfaces
{
    // Интерфейс: метода по работе с БД
    public interface INodeDb
    {
        void Add(Node node);
        Node AddOneQuantity(int id);
        List<Node> GetList();
        bool IsNull();
    }
}
