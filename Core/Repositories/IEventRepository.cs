using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEventRepository
    {
        Task<EventEntity> GetEventByIdAsync(Guid id);
        IQueryable<EventEntity> GetAllEvents();
        Task AddEventAsync(EventEntity eventEntity);
        Task UpdateEventAsync(EventEntity eventEntity);
        Task DeleteEventAsync(Guid id);
    }
}
