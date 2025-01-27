using System.Runtime.CompilerServices;
using Domain.Base;
using Domain.Shared.ValueObjects;
using Domain.Entities.StringListTree;

namespace Domain.Entities.Trees
{
    // Класс реализующий узел дерева
    public class Tree(int id, Name name, Quentity quentity, ParentId parentId) : BaseEntity
    {
        
        public new int Id { get; private set; } = id;
        public Name Name { get; private set; } = name;
        public Quentity Quentity { get; private set; } = quentity;
        public ParentId ParentId { get; private set; } = parentId;
        public List<Tree> Chuldren { get; private set; } = [];

        public int FullQuentity()
        {
            int sum = 0;
            sum += Quentity.Value;

            foreach (Tree temp in Chuldren)
            {
                sum += temp.FullQuentity();
            }

            return sum;
        }

        public List<IdAndName> TreeToListString(int tab = 0)
        {
            List<IdAndName> list = [];

            foreach (Tree chuld in Chuldren)
            {
                string str = "";
                for (int i = 0; i < tab; i++)
                {
                    str += "        ";
                }
                str += tab % 3 == 0 ? " • " : tab % 2 == 0 ? " ▪ " : " o ";
                str += chuld.Name.ToString();
                str += "    ";
                str += chuld.FullQuentity().ToString();

                list.Add(new StringListTree.IdAndName(chuld.Id, str));
                list.AddRange(chuld.TreeToListString(tab + 1));
            }

            return list;
        }
    }
}
