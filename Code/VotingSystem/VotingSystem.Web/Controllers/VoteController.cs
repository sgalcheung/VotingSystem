using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VotingSystem.Web.Models;
using VotingSystem.Web.Services;
using Microsoft.AspNetCore.Identity;

namespace VotingSystem.Web.Controllers
{
    public class VoteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VoteService _voteService;
        private readonly UserManager<IdentityUser> _userManager;

        public VoteController(
            ILogger<HomeController> logger, 
            VoteService voteService,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _voteService = voteService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(SearchVoteModel model)
        {
            var models = await _voteService.GetVotes(model);

            return View(models);
        }

        public IActionResult Create()
        {
            return View(new CreateVoteCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVoteCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await GetCurrentUserAsync();
                    var id = _voteService.CreateVote(command, user.Id);
                    return RedirectToAction(nameof(Details), new { id = id });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(command);
        }

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(User);

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Details(Guid id)
        {
            var model = _voteService.GetVoteDetail(id);
            if (model == null)
            {
                return NotFound();
            }

            //var recipe = _voteService.GetVote(id);


            return View(model);
        }

        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
