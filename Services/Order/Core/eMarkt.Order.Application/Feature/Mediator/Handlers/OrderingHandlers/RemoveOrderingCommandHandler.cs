using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using eMarkt.Order.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
