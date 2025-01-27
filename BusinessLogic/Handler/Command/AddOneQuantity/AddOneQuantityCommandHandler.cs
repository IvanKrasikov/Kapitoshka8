using BusinessLogic.Handler.Command.AddOneQuantity;
using Domain.Entities.Nodes;
using Domain.Interfaces;
using MediatR;

namespace BusinessLogic.Handler.Command
{
    public class AddOneQuantityCommandHandler : IRequestHandler<AddOneQuantityCommand, Node>
    {
        private readonly INodeDb _db;

        public AddOneQuantityCommandHandler(INodeDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Task<Node> Handle(AddOneQuantityCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.AddOneQuantity(command.Id));
        }
    }
}
