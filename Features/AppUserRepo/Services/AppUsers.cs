using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using uHubAPI.Database.DBContext;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Services
{
    /// <summary>
    /// Service class to provide CRUD opperations to App user controller class
    /// </summary>
    public class AppUserService
    {
        private  readonly AppDbContext _context;

        public AppUserService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAppUser(AppUser userData)
        {
            throw new NotImplementedException();
        }
    }
}