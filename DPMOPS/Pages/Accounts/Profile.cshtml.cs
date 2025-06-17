using DPMOPS.Services.Comment;
using DPMOPS.Services.Comment.Dtos;
using DPMOPS.Services.Follow;
using DPMOPS.Services.Follow.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DPMOPS.Pages.Accounts
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly IFollowService _followService;
        private readonly ICommentService _commentService;

        public ProfileModel(IFollowService followService, ICommentService commentService)
        {
            _commentService = commentService;
            _followService = followService;
        }

        public bool IsCitizen { get; set; } = false;
        public IList<CommentDto> Comments { get; set; }
        public IList<FollowingDto> Followings { get; set; }

        public async Task OnGet()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value == null && !User.HasClaim("IsAdmin", "true")) IsCitizen = true;
            Comments = await _commentService.GetAllUsersComments(userId);
            Followings = await _followService.GetFollowingAsync(userId);
        }
    }
}
