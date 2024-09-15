using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdQuery, EventDTO>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventDTO> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(request.Id);
            if(eventEntity is null)
            {
                //throw new NotFoundException($"Event with ID {request.Id} not found.");
                throw new Exception(message: $"Event with ID {request.Id} not found.");
            }

            var eventDTO = new EventDTO
            {
                Id = eventEntity.Id,
                Date = eventEntity.Date,
                Location = eventEntity.Location,
                Description = eventEntity.Description,
                Price = eventEntity.Price,
            };

            return eventDTO;
        }
    }
}
