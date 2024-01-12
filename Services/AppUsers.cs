using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using uHub_API.Lib;
using uHub_API.Models;

namespace uHub_API.Services
{
    /// <summary>
    /// ....
    /// </summary>
    public class AppUserService
    {
        private  readonly ApplicationDbContext _context;
        public AppUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAppUser(AppUser userData)
        {
            throw new NotImplementedException();
        }
    }
}