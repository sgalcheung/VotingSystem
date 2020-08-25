using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRCoder;
using VotingSystem.Models;

namespace VotingSystem.Controllers
{
    [Authorize]
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

        public IActionResult Edit(Guid id)
        {
            //var vote = _voteService.GetVote(id);

            var model = _voteService.GetVoteForUpdate(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateVoteCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _voteService.UpdateVote(command);
                    return RedirectToAction(nameof(Details), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                // Add a model-level error by using an empty string key
                ModelState.AddModelError(string.Empty, "An error occured saving the vote");
            }

            // If we got to here, something went wrong
            return View(command);
        }

        public IActionResult Delete(Guid id)
        {
            var vote = _voteService.GetVote(id);

            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _voteService.DeleteVote(id);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Vote(Guid id)
        {
            var vote = _voteService.GetVoteToVote(id);

            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Vote(VoteCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _voteService.ToVote(command);
                    return RedirectToAction(nameof(Vote), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                // Add a model-level error by using an empty string key
                ModelState.AddModelError(string.Empty, "An error occured to vote");
            }

            // If we got to here, something went wrong
            return RedirectToAction(nameof(Vote), new { id = command.Id });
        }

        public IActionResult GetShareQrCode(string plainText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return File(ms.ToArray(), "image/jpeg");
        }

        [HttpPost]
        public IActionResult Publish(Guid id)
        {
            _voteService.Publish(id);

            return Ok();
        }

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(User);
    }
}
