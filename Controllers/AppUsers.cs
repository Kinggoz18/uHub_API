using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using uHubAPI.Models.UserAccountModels;
using uHubAPI.Services;
using uHubAPI.DBContext;

namespace uHubAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppUsers : ControllerBase
    {
        private  readonly AccountDbContext _context;
        public AppUsers(AccountDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CreateAppUser/")]
        public ActionResult<AppUser> AddUser(AppUser userData){

            throw new NotImplementedException();
        }
    }
}