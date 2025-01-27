using Domain.Entities.Nodes;
using MediatR;

namespace BusinessLogic.Handler.Command.AddOneQuantity
{
    public class AddOneQuantityCommand : IRequest<Node>
    {
        public int Id { get; set; }
    }
}
