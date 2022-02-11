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
 
    public class UserFriendshipController : ControllerBase
    {
            private readonly IFriendshipService _friendshipController;
            public UserFriendshipController(IFriendshipService friendshipController)
            {
                _friendshipController = friendshipController;
            }

            [HttpGet("GetUserFriendsCount")]
            public ActionResult<int> GetNumber(int userID)
            {
               return Ok(_friendshipController.GetUserFriendsCountById(userID));
            }

        [HttpGet("GetFriends")]
        public ActionResult<List<FriendVM>> GetFriendById(int id)
        {
            List<FriendVM> result = new List<FriendVM>();
            List<Friend> friend = _friendshipController.GetFriendsByUserId(id);

            foreach (Friend friendById in friend)
            {
                FriendVM returnToTheClientModel = new FriendVM(friendById);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpGet("GetPendingFriendsRequest")]
        public ActionResult<List<FriendVM>> GetPendingFriendRequest(int id)
        {
            List<FriendVM> result = new List<FriendVM>();
            List<Friend> friends = _friendshipController.GetPendingFriends(id);

            foreach (Friend friendById in friends)
            {
                FriendVM returnToTheClientModel = new FriendVM(friendById);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

    }
}
