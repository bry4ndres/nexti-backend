using Application.DTOs;
using Application.Queries;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, PagedResult<EventDTO>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventsHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<PagedResult<EventDTO>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            //var events = await _eventRepository.GetAllEventsAsync();

            //var eventDTOs = events.Select(e => new EventDTO
            //{
            //    Id = e.Id,
            //    Date = e.Date,
            //    Location = e.Location,
            //    Description = e.Description,
            //    Price = e.Price,
            //});

            var pageNumber = request.PageNumber;
            var pageSize = request.PageSize;

            var query = _eventRepository.GetAllEvents();

            var totalCount = await query.CountAsync(cancellationToken);

            var eventos = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var eventDTOs = eventos.Select(e => new EventDTO
            {
                Id = e.Id,
                Date = e.Date,
                Location = e.Location,
                Description = e.Description,
                Price = e.Price
            });

            return new PagedResult<EventDTO>
            {
                Items = eventDTOs,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
