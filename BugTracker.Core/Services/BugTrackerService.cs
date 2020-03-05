using BugTracker.Common.Enums;
using BugTracker.Core;
using BugTracker.Core.Interfaces;
using BugTracker.Data.Entities;
using BugTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class BugTrackerService: IBugTrackerService
    {
        private IBugRepository _bugRepository;

        public BugTrackerService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;

        }

        public async Task<Domain.Bug> CreateAsync(Domain.Bug newBug)
        {
            //Guard against NULL
            if (newBug == null)
            {
                throw new ArgumentNullException();
            }
            await _bugRepository.CreateAsync(new Bug
            {
                Title = newBug.Title,
                Description = newBug.Description,
                DateCreated = newBug.DateCreated,
                StatusId = newBug.StatusId
            });
            return newBug;
        }

        public async Task<IEnumerable<Data.Entities.Bug>> GetAsync()
        {
            //Guard against NULL

            return await _bugRepository.GetAsync();
        }

        public async Task<IEnumerable<Bug>> GetAsync(Common.Enums.Status status)
        {
            return await _bugRepository.GetAsync(status);
        }
    }
}
