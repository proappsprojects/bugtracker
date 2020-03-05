using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private IBugRepository _bugRepository;

        public BugController(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;

        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Data.Entities.Bug>> GetAsync()
        {
            return await _bugRepository.GetAsync();
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public async ActionResult<string> GetAsync(int id)
        //{
        //    return await _bugRepository.GetAsync(id);
        //}
    }
}
