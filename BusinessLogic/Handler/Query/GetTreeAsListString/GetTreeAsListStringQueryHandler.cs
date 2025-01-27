using AutoMapper;
using Domain.Entities.Nodes;
using Domain.Entities.Trees;
using Domain.Entities.StringListTree;
using Domain.Interfaces;
using Domain.Shared.ValueObjects;
using MediatR;

namespace BusinessLogic.Handler.Query.GetTreeAsListString
{
    public class GetTreeAsListStringQueryHandler : IRequestHandler<GetTreeAsListStringQuery, List<IdAndName>>
    {
        private readonly INodeDb _db;
        private readonly IMapper _mapper;
        public GetTreeAsListStringQueryHandler(INodeDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<List<IdAndName>> Handle(GetTreeAsListStringQuery request, CancellationToken cancellationToken)
        {
            if (_db.IsNull())
            {
                _db.Add(new Node("Спортивные секции", 0, 0));
                _db.Add(new Node("Футбол", 5, 1));
                _db.Add(new Node("Цирковая школа", 0, 1));
                _db.Add(new Node("Клоунада", 6, 3));
                _db.Add(new Node("Эквилибристика", 4, 3));
                _db.Add(new Node("Иппотерапия", 7, 1));
                _db.Add(new Node("Творческие студии"));
                _db.Add(new Node("Изобразительное искусство", 0, 7));
                _db.Add(new Node("Живопись", 0, 8));
                _db.Add(new Node("Гуашь", 3, 9));
                _db.Add(new Node("Масло", 2, 9));
                _db.Add(new Node("Графика", 4, 8));
                _db.Add(new Node("Литература", 0, 7));
                _db.Add(new Node("Поэзия", 1, 13));
                _db.Add(new Node("Проза", 1, 13));
                _db.Add(new Node("Технические кружки"));
                _db.Add(new Node("Робототехника", 0, 16));
                _db.Add(new Node("LEGO Mindstorms", 6, 17));
                _db.Add(new Node("Arduino", 2, 17));
                _db.Add(new Node("Моделирование", 5, 16));
            }

            List<Node> nodes = _db.GetList();

            nodes.Sort((node1, node2) => node1.Id.CompareTo(node2.Id));

            Tree root = new(0, new Name("root"), new Quentity(0), new ParentId(0));

            List<Tree> nodesTree = [];
            nodesTree = _mapper.Map<List<Tree>>(nodes);

            for (int i = 0; i < nodes.Count; i++)
            {
                ParentId parentId = nodes[i].ParentId;

                if (parentId.Value == 0)
                {
                    root.Chuldren.Add(nodesTree[i]);
                }
                else
                {
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[j].Id == parentId.Value)
                        {
                            nodesTree[j].Chuldren.Add(nodesTree[i]);
                        }
                    }
                }
            }
            List<IdAndName> list = root.TreeToListString();
            return Task.FromResult(list);
        }
    }
}
