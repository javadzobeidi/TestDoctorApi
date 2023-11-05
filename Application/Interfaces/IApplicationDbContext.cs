using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    void ChangeState(object entity, EntityState state);

    Task<IDbContextTransaction> BeginTransaction();
    DbSet<Doctor> Doctors { get; }
    DbSet<ReserveTime> ReserveTimes { get; }
    DbSet<ReserveTimeUser> ReserveTimeUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
