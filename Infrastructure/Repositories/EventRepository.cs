using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEventAsync(EventEntity eventEntity)
        {
            _dbContext.Events.Add(eventEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(Guid id)
        {
            var eventEntity = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (eventEntity != null)
            {
                eventEntity.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public IQueryable<EventEntity> GetAllEvents()
        {
            return _dbContext.Events.Where(e => !e.IsDeleted);
        }

        public async Task<EventEntity?> GetEventByIdAsync(Guid id)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateEventAsync(EventEntity eventEntity)
        {
            _dbContext.Events.Update(eventEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
