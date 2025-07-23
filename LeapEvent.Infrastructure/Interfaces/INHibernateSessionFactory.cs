using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Infrastructure.Interfaces
{
    public interface INHibernateSessionFactory
    {
        ISessionFactory SessionFactory { get; }
    }
}
