using BugTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Interfaces
{
    public interface IBugRepository
    {
        Task CreateAsync(Bug bug);
        Task EditAsync(Bug bug);
        Task<IEnumerable<Bug>> GetAsync();
        Task<Bug>  GetAsync(long id);
        Task<IEnumerable<Bug>> GetAsync(Common.Enums.Status status);
    }
}
