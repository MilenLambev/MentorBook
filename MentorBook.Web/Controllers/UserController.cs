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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<UserShortDataVM>> Get()
        {
            List<UserShortDataVM> result = new List<UserShortDataVM>();
            List<User> allUsers = _userService.GetAllUsers();

            foreach (User user in allUsers)
            {
                UserShortDataVM returnToTheClientModel = new UserShortDataVM(user);

                result.Add(returnToTheClientModel);
            }

            return Ok(result);
        }

        [HttpGet("GetUserDetails/{id}")]
        public ActionResult<UserDetailedUserVM> GetUser(int id)
        {

            return Ok();
        }

        [HttpPost("Create")]
        public ActionResult InsertUser([FromBody] NewUserQM user)
        {
            return Ok();
        }
    }
}
