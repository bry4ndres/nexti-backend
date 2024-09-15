using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetEventByIdQuery: IRequest<EventDTO>
    {
        public Guid Id { get; }
        public GetEventByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
