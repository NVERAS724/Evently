
using Evently.Modules.Events.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Evently.Modules.Events.Application.Abstractions.Data;
namespace Evently.Modules.Events.Infrastructure.Database;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
