using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using uHubAPI.DBContext;
using uHubAPI.Lib;
using uHubAPI.Models.UserAccountModels;

namespace uHubAPI.Services
{
    /// <summary>
    /// Service class to provide CRUD opperations to App user controller class
    /// </summary>
    public class AppUserService
    {
        private  readonly AccountDbContext _context;

        public AppUserService(AccountDbContext context)
        {
            _context = context;
        }

        public void CreateAppUser(AppUser userData)
        {
            throw new NotImplementedException();
        }
    }
}