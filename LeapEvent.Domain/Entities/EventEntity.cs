using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Domain.Entities
{
    public class EventEntity
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual DateTime StartsOn { get; set; }
        public virtual DateTime EndsOn { get; set; }
        public virtual string Location { get; set; } = string.Empty;
    }
}
