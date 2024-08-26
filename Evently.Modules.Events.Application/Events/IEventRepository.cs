using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Events.Domain.Events;

namespace Evently.Modules.Events.Application.Events;
public interface IEventRepository
{
    void Insert(Event @event);
}
