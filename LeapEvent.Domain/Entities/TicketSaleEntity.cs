using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Domain.Entities
{
    public class TicketSaleEntity
    {
        public virtual string Id { get; set; }
        public virtual string EventId { get; set; }
        public virtual string UserId { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual int PriceInCents { get; set; }
    }
}
