using LeapEvent.Domain.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Infrastructure
{
    public class TicketSaleMapping : ClassMapping<TicketSaleEntity>
    {
        public TicketSaleMapping()
        {
            Table("TicketSales");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Assigned);
                m.Type(NHibernateUtil.String);
                m.Column("Id");
            });

            Property(x => x.EventId, m => m.Type(NHibernateUtil.String));
            Property(x => x.UserId, m => m.Type(NHibernateUtil.String));
            Property(x => x.PurchaseDate);
            Property(x => x.PriceInCents);
        }
    }

}
