using Application.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand,Unit>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(request.Id);

            if (eventEntity is null)
            {
                throw new Exception("Event not found");
            }

            eventEntity.Date = request.Date;
            eventEntity.Location = request.Location;
            eventEntity.Description = request.Description;
            eventEntity.Price = request.Price;

            await _eventRepository.UpdateEventAsync(eventEntity);

            return Unit.Value;
        }
    }
}
