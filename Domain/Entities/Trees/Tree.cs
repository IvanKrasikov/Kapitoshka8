using System.Runtime.CompilerServices;
using Domain.Base;
using Domain.Shared.ValueObjects;
using Domain.Entities.StringListTree;

namespace Domain.Entities.Trees
{
    // Класс реализующий узел дерева
    public class Tree(int id, Name name, Quantity quantity, ParentId parentId) : BaseEntity
    {
        
        public new int Id { get; private set; } = id;
        public Name Name { get; private set; } = name;
        public Quantity Quantity { get; private set; } = quantity;
        public ParentId ParentId { get; private set; } = parentId;
        public List<Tree> Children { get; private set; } = [];

        public int FullQuantity()
        {
            int sum = 0;
            sum += Quantity.Value;

            foreach (Tree temp in Children)
            {
                sum += temp.FullQuantity();
            }

            return sum;
        }

        public List<IdAndName> TreeToListString(int tab = 0)
        {
            List<IdAndName> list = [];

            foreach (Tree child in Children)
            {
                string str = "";
                for (int i = 0; i < tab; i++)
                {
                    str += "        ";
                }
                str += tab % 3 == 0 ? " • " : tab % 2 == 0 ? " ▪ " : " o ";
                str += child.Name.ToString();
                str += "    ";
                str += child.FullQuantity().ToString();

                list.Add(new StringListTree.IdAndName(child.Id, str));
                list.AddRange(child.TreeToListString(tab + 1));
            }

            return list;
        }
    }
}
