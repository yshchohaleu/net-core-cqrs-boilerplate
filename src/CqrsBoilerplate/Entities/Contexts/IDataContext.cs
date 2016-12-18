using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CqrsBoilerplate.Entities.Contexts
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();

        void SetState(object entity, EntityState state);
    }
}
