using LeapEvent.Application.Interfaces;
using LeapEvent.Domain.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public EventRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task<List<EventEntity>> GetUpcomingEventsAsync(int days)
        {
            using var session = _sessionFactory.OpenSession();
            var threshold = DateTime.UtcNow.AddDays(days);

            return await session.Query<EventEntity>()
                .Where(e => e.StartsOn <= threshold && e.StartsOn >= DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
