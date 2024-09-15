using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class AddEventHandler : IRequestHandler<AddEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;

        public AddEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = new EventEntity
            {
                Date = request.Date,
                Location = request.Location,
                Description = request.Description,
                Price = request.Price
            };

            await _eventRepository.AddEventAsync(eventEntity);
            
            return 0;
        }
    }
}
