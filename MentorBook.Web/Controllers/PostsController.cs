using MentorBook.Business;
using MentorBook.Data.Models;
using MentorBook.Web.Models.QueryModels;
using MentorBook.Web.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IPostsService _postsService;
        public PostsController(ILogger<PostsController> logger, IPostsService postsService)
        {
            _logger = logger;
            _postsService = postsService;
        }

        [HttpGet("GetAggregatedPostsOfFriends")]
        public ActionResult<List<PostVM>> GetAggregatedPostsOfFriends(int userId)
        {
            List<PostVM> result = new List<PostVM>();
            List<Post> postsOfFriends = _postsService.GetAggregatedPostsOfFriends(userId);

            foreach (Post post in postsOfFriends)
            {
                PostVM returnToTheClientModel = new PostVM(post);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpGet("GetComments")]
        public ActionResult<List<CommentVM>> GetComments(int rootPostId)
        {
            List<CommentVM> result = new List<CommentVM>();
            List<Post> postsOfFriends = _postsService.GetComments(rootPostId);

            foreach (Post post in postsOfFriends)
            {
                CommentVM returnToTheClientModel = new CommentVM(post);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpGet("CreateComment")]
        public ActionResult<List<CreateCommentQM>> CreateComment(int rootPostId, int AuthorID, string CommentContent)
        {
            bool result = _postsService.CreateComment(rootPostId, AuthorID, CommentContent);

            if(result == true)
            {
                return Ok(result);
            }
            
            return new StatusCodeResult(400);
        }

        [HttpGet("GetPostsOfUser")]
        public ActionResult<List<PostVM>> GetPostsOfUser(int userId)
        {
            List<PostVM> result = new List<PostVM>();
            List<Post> postsOfFriends = _postsService.GetPostsOfUser(userId);

            foreach (Post post in postsOfFriends)
            {
                PostVM returnToTheClientModel = new PostVM(post);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }
    }
}
