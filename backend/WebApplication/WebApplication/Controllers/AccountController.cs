using System.Linq;
using System.Threading.Tasks;
using DomainModel.DTO;
using DomainModel.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;
using NHibernate.Loader.Criteria;
using NHibernate.Persister.Entity;
using Services.Interfaces;
using WebApplication.Controllers.Base;

namespace WebApplication.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var users = _userService.GetQueryOver.List();
            return Content(users.First().UserName);
        }
    }
}