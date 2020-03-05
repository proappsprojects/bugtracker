using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Interfaces
{
    public interface IBugTrackerService
    {
        Task<Domain.Bug> CreateAsync(Domain.Bug newBug);
        Task<Domain.Bug> EditAsync(Domain.Bug newBug);

        Task<IEnumerable<Data.Entities.Bug>> GetAsync();
        Task<Data.Entities.Bug> GetAsync(long id);
        Task<IEnumerable<Data.Entities.Bug>> GetAsync(Common.Enums.Status status);
    }
}
