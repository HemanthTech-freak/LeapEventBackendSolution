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
    public class EventMapping : ClassMapping<EventEntity>
    {
        public EventMapping()
        {
            Table("Events");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Assigned); // Use Assigned generator for manually assigning id values
                m.Type(NHibernateUtil.String);    
                m.Column("Id");
            });

            Property(x => x.Name);
            Property(x => x.StartsOn);
            Property(x => x.EndsOn);
            Property(x => x.Location);
        }
    }

}
