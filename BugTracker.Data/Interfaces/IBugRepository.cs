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
        Task<IEnumerable<Bug>> GetAsync();
        Task<IEnumerable<Bug>> GetAsync(Common.Enums.Status status);
    }
}
