using BusinessLogic.Handler.Command.AddOneQuentity;
using Domain.Entities.Nodes;
using Domain.Interfaces;
using MediatR;

namespace BusinessLogic.Handler.Command
{
    public class AddOneQuentityCommandHandler : IRequestHandler<AddOneQuentityCommand, Node>
    {
        private readonly INodeDb _db;

        public AddOneQuentityCommandHandler(INodeDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Task<Node> Handle(AddOneQuentityCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.AddOneQuentity(command.Id));
        }
    }
}
