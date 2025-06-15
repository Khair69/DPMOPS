using DPMOPS.Services.Comment;
using DPMOPS.Services.Comment.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DPMOPS.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly ICommentService _commentService;

        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IList<CommentDto> Comments { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            Comments = await _commentService.GetAllRequestsCommentsAsync(id);
        }

        [BindProperty]
        public AddCommentDto NewComment { get; set; }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                Comments = await _commentService.GetAllRequestsCommentsAsync(id);
                return Page();
            }

            NewComment.ServiceRequestId = id;
            NewComment.AccountId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var success = await _commentService.AddCommentAsync(NewComment);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToPage("Index", new {id = id});
        }
    }
}
