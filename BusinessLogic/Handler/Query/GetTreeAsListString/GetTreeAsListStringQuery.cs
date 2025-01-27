using Domain.Entities.Nodes;
using Domain.Entities.StringListTree;
using MediatR;

namespace BusinessLogic.Handler.Query.GetTreeAsListString
{
    public class GetTreeAsListStringQuery : IRequest<List<IdAndName>>
    {
    }
}
