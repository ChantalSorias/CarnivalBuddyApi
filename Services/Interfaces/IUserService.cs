using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(string id);
        public Task<User> GetByEmail(string email);
        public Task<User> GetByUsername(string username);
        public Task<User> Create(User user);
        public Task Update(User user);
        public Task Delete(string id);
    }
}