using Domain.Entities.Nodes;
using MediatR;

namespace BusinessLogic.Handler.Command.AddOneQuentity
{
    public class AddOneQuentityCommand : IRequest<Node>
    {
        public int Id { get; set; }
    }
}
