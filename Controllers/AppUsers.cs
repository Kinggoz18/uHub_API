using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using uHub_API.Models;
using uHub_API.Services;
using uHub_API.Lib;

namespace uHub_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppUsers : ControllerBase
    {
        private  readonly ApplicationDbContext _context;
        public AppUsers(ApplicationDbContext context)
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