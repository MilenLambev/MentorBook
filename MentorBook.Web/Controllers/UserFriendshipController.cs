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
        public ActionResult<List<FriendsVM>> GetFriendsByUserId(int id)
        {
            List<FriendsVM> result = new List<FriendsVM>();
            List<Friends> friends = _friendshipController.GetFriendsByUserId(id);

            foreach (Friends friendsById in friends)
            {
                FriendsVM returnToTheClientModel = new FriendsVM(friendsById);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpGet("GetPendingFriendsRequest")]
        public ActionResult<List<FriendsVM>> GetPendingFriendsRequest(int id)
        {
            List<FriendsVM> result = new List<FriendsVM>();
            List<Friends> friends = _friendshipController.GetPendingFriendsRequest(id);

            foreach (Friends friendsById in friends)
            {
                FriendsVM returnToTheClientModel = new FriendsVM(friendsById);
                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }
        [HttpGet("GetCommonFriends")]

        public ActionResult<List<UserShortDataVM>> GetCommonFriends(int firstFriendId, int secondFriendId)
        {
            List<UserShortDataVM> result = new List<UserShortDataVM>();
            List<User> commonFriends = _friendshipController.GetCommonFriends(firstFriendId, secondFriendId);

            foreach (User user in commonFriends)
            {
                UserShortDataVM returnCommonFriends = new UserShortDataVM(user);
                result.Add(returnCommonFriends);
            }
            return Ok(result);
        }
    }
}
