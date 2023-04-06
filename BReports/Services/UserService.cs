using BReports.Data;
using BReports.Models.DBModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace BReports.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create()
        {
        
        }

        public void Delete(int id)
        {
        }

        public List<ApplicationUser> GetAll()
        {
            return this.db.Users.ToList();
        }

        public ApplicationUser GetById(int id)
        {
           return this.db.Users.FirstOrDefault();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }

        void IUserService.GetAll()
        {
          //  throw new NotImplementedException();
        }

        void IUserService.GetById(int id)
        {
          //  throw new NotImplementedException();
        }
    }
}
