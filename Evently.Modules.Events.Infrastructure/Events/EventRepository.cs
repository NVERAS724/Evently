using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Events.Application.Events;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Events;
internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{

    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }

   
}
