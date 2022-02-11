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

    }
}
