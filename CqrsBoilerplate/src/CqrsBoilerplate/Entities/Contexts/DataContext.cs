using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Npgsql;

namespace CqrsBoilerplate.Entities.Contexts
{
    public abstract class DataContext : DbContext
    {
        private readonly Guid _instanceId;
        private readonly NpgsqlOptionsExtension _npgsqlOptions;

        protected DataContext(DbContextOptions options) : base(options)
        {
            _npgsqlOptions = options.FindExtension<NpgsqlOptionsExtension>();
            _instanceId = Guid.NewGuid();
        }

        public DbConnection Connection => new NpgsqlConnection(_npgsqlOptions.ConnectionString);

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var changesAsync = await base.SaveChangesAsync(cancellationToken);
            return changesAsync;
        }

        public override int SaveChanges()
        {
            var changes = base.SaveChanges();
            return changes;
        }

        public void SetState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }
    }
}
