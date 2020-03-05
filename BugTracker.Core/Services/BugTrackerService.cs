using BugTracker.Common.Enums;
using BugTracker.Core;
using BugTracker.Core.Domain;
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
            await _bugRepository.CreateAsync(new Data.Entities.Bug
            {
                Title = newBug.Title,
                Description = newBug.Description,
                DateCreated = newBug.DateCreated,
                StatusId = newBug.StatusId
            });
            return newBug;
        }

        public async Task<Domain.Bug> EditAsync(Domain.Bug newBug)
        {
            //Guard against NULL
            if (newBug == null || newBug.Id < 1)
            {
                throw new ArgumentNullException();
            }
            var editBug = await _bugRepository.GetAsync(newBug.Id);

            if (editBug == null)
            {
                throw new KeyNotFoundException("The Bug data couldn't be found.");
            }

            //TODO: replace this block with AutoMapper.
            editBug.Title = newBug.Title;
            editBug.Description = newBug.Description;
            editBug.DateCreated = newBug.DateCreated;
            editBug.StatusId = newBug.StatusId;

            await _bugRepository.EditAsync(editBug);
            return newBug;
        }


        public async Task<IEnumerable<Data.Entities.Bug>> GetAsync()
        {
            //Guard against NULL

            return await _bugRepository.GetAsync();
        }

        public async Task<IEnumerable<Data.Entities.Bug>> GetAsync(Common.Enums.Status status)
        {
            return await _bugRepository.GetAsync(status);
        }

        public async Task<Data.Entities.Bug> GetAsync(long id)
        {
           return await _bugRepository.GetAsync(id);
        }
    }
}
