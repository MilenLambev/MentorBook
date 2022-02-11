﻿using MentorBook.Business;
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

        [HttpGet("GetUserByFilter/{fillteringValue}")]
        public ActionResult<UserDetailedUserVM> GetStringInfo(string fillteringValue)
        {
            List<UserDetailedUserVM> result = new List<UserDetailedUserVM>();
            List<User> allUsers = _userService.GetUserByFilter(fillteringValue.ToLower());

            foreach (User user in allUsers)
            {
                UserDetailedUserVM infoAboutUser = new UserDetailedUserVM(user);

                result.Add(infoAboutUser);
            }

            return Ok(result);
        }

        [HttpGet("GetFullInformation/{email}")]
        public ActionResult<UserDetailedUserVM> GetUserEmail(string email)
        {
            User user = _userService.GetUserEmail(email);

            if (user != null)
            {
                UserDetailedUserVM modelTorReturn = new UserDetailedUserVM(user);
                return Ok(modelTorReturn);
            }

            return NotFound();
        }

        [HttpGet("GetUserDetails/{id}")]
        public ActionResult<UserDetailedUserVM> GetUser(int id)
        {
            User user = _userService.GetUser(id);

            if (user != null)
            {
                UserDetailedUserVM modelTorReturn = new UserDetailedUserVM(user);
                return Ok(modelTorReturn);
            }

            return NotFound();
        }

        [HttpPost("Create")]
        public ActionResult InsertUser([FromBody] NewUserQM user)
        {
            User dbUser = new User();
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Phone = user.Phone;
            dbUser.DateOfBirth = user.DateOfBirth;

            bool result = _userService.InsertUser(dbUser);

            if (result == true)
            {
                return Ok();
            }

            return new StatusCodeResult(400);
        }
    }
}
