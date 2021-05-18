using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.DTO;
using DomainModel.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApplication.Controllers.Base;

namespace WebApplication.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public AccountController(IUserService userService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetQueryOver().ListAsync();
            return Content(users.SingleOrDefault().ToString());
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Login
            };
            List<string> errors = new List<string>();
            if(_userService.GetByUserName(model.Login) != null)
                errors.Add("User with this login already exist");
            
            if(_userService.GetByUserEmail(model.Email) != null)
                errors.Add("User with this email already exist");
            
            foreach (var validator in _userManager.PasswordValidators)
            {
                var validationResult = await validator.ValidateAsync(_userManager, user, model.Password);
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.Description);
                }
            }
            
            if (errors.Any())
                return BadRequest(errors);
            
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            await _userManager.CreateAsync(user);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignIn(UserModel userModel)
        {
            var user = _userService.GetByUserName(userModel.Login) ?? _userService.GetByUserEmail(userModel.Login);
            if(user == null)
                return Unauthorized(new [] {"Incorrect login or password"});
            
            var result = await _signInManager.PasswordSignInAsync(user, userModel.Password, true, false);
            return result.Succeeded ? Ok() : Unauthorized(new [] {"Incorrect login or password"});
        }
    }
}