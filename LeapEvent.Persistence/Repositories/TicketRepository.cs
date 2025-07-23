using LeapEvent.Application.Interfaces;
using LeapEvent.Domain.DTOs;
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
    public class TicketRepository : ITicketRepository
    {
        private readonly ISession _session;

        public TicketRepository(ISession session)
        {
            _session = session;
        }

        public async Task<List<TicketSaleEntity>> GetByEventIdAsync(string eventId)
        {
            return await _session.Query<TicketSaleEntity>()
                .Where(t => t.EventId == eventId)
                .ToListAsync();
        }

        public async Task<List<EventSalesDto>> GetTop5ByTicketsSoldAsync()
        {
            var ticketSales = await _session.Query<TicketSaleEntity>()
                .GroupBy(t => t.EventId)
                .Select(g => new
                {
                    EventId = g.Key,
                    TicketsSold = g.Count(),
                    TotalRevenue = g.Sum(t => t.PriceInCents) / 100m //Calculate total revenue in dollars
                })
                .OrderByDescending(x => x.TicketsSold)
                .Take(5)
                .ToListAsync();

            var eventIds = ticketSales.Select(x => x.EventId).ToList();

            var events = await _session.Query<EventEntity>()
                .Where(e => eventIds.Contains(e.Id))
                .ToListAsync();

            var result = (from ts in ticketSales
                          join ev in events on ts.EventId equals ev.Id
                          select new EventSalesDto
                          {
                              EventId = ev.Id,
                              EventName = ev.Name,
                              TicketsSold = ts.TicketsSold,
                              TotalRevenue = ts.TotalRevenue
                          }).ToList();

            return result;
        }



        public async Task<List<EventSalesDto>> GetTop5ByRevenueAsync()
        {
            var ticketRevenue = await _session.Query<TicketSaleEntity>()
                .GroupBy(t => t.EventId)
                .Select(g => new
                {
                    EventId = g.Key,
                    TotalRevenue = g.Sum(t => t.PriceInCents) / 100m, 
                    TicketsSold = g.Count()
                })
                .OrderByDescending(x => x.TotalRevenue)
                .Take(5)
                .ToListAsync();

            var eventIds = ticketRevenue.Select(x => x.EventId).ToList();

            var events = await _session.Query<EventEntity>()
                .Where(e => eventIds.Contains(e.Id))
                .ToListAsync();

            var result = (from tr in ticketRevenue
                          join ev in events on tr.EventId equals ev.Id
                          select new EventSalesDto
                          {
                              EventId = ev.Id,
                              EventName = ev.Name,
                              TicketsSold = tr.TicketsSold,
                              TotalRevenue = tr.TotalRevenue
                          }).ToList();

            return result;
        }
    }
}
