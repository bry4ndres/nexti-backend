using Application.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class DeleteEventHandler:IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(request.Id);

            if (eventEntity is null)
            {
                throw new Exception("Event not found");
            }

            await _eventRepository.DeleteEventAsync(eventEntity.Id);

            return Unit.Value;
        }
    }
}
