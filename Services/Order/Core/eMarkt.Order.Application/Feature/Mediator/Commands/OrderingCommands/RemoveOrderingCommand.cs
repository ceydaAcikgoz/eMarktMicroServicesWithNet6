using MediatR;

namespace eMarkt.Order.Application.Feature.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }   
    }
}
