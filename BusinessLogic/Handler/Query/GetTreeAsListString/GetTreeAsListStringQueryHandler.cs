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
