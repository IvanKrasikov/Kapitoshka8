using Domain.Base;

namespace Domain.Entities.StringListTree
{
    // Класс созданный для передачи всех нужных данный в Index.cshtml
    public class IdAndName(int id, string name) : BaseEntity
    {
        public new int Id { get; private set; } = id;
        public string Name { get; private set; } = name;
    }
}
