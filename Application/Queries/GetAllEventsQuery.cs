using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetAllEventsQuery: IRequest<PagedResult<EventDTO>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
