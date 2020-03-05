using BugTracker.Data.Interfaces;
using BugTracker.Web.Data;
using System;
using System.Collections.Generic;
using BugTracker.Data.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BugTracker.Common.Enums;

namespace BugTracker.Data
{
    public class BugRepository : IBugRepository
    {
        private readonly BugTrackerDbContext _context;

        public BugRepository(BugTrackerDbContext contex)
        {
            _context = contex;
        }

        public async Task CreateAsync(Bug bug)
        {
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Bug bug)
        {
            _context.Bugs.Update(bug);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Bug>> GetAsync()
        {
            return await _context.Bugs.OrderBy(x => x.DateCreated).ToListAsync();
        }

        public async Task<IEnumerable<Bug>> GetAsync(Common.Enums.Status status)
        {
            return await _context.Bugs
                .Where(x=>x.Status.Id == (long)status)
                .OrderBy(x => x.DateCreated).ToListAsync();
        }

        public async Task<Bug> GetAsync(long id)
        {
            return await _context.Bugs
                .Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
