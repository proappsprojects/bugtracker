using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Core.Domain;
using BugTracker.Core.Interfaces;
using BugTracker.Core.Services;
using BugTracker.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Web.Controllers
{
    [Authorize]
    public class BugController : Controller
    {

        private readonly IBugRepository _bugRepository;
        private readonly IBugTrackerService _bugTrackerService;

        public BugController(IBugRepository bugRepository, IBugTrackerService bugTrackerService)
        {
            _bugRepository = bugRepository;
            _bugTrackerService = bugTrackerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long moduleId, long businessUnitId)
        {           
            var list =  await _bugTrackerService.GetAsync(Common.Enums.Status.Open);
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bug bug)
        {
            if (ModelState.IsValid)
            {
                await _bugTrackerService.CreateAsync(bug);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var bug = await _bugTrackerService.GetAsync((long)id);
            return View("Detail", bug);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var bug = await _bugTrackerService.GetAsync(id);
            return View("Edit", bug);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bug bug)
        {

            await _bugTrackerService.EditAsync(bug);
            return RedirectToAction("Index");
        }
    }
}