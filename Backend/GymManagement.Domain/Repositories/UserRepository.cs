using GenericServices;
using GymManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ICrudServices service;

        public UserRepository([FromServices] ICrudServices service)
        {
            this.service = service;
        }

        public User Get(string username, string password)
        {
            return service.ReadSingle<User>(u => u.Username == username && u.Password == password);
        }
    }
}
