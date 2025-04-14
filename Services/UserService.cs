using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Repositories.Interfaces;
using CarnivalBuddyApi.Services.Interfaces;

namespace CarnivalBuddyApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<User> GetById(string id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> Create(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task Delete(string id)
        {
            await _userRepository.Delete(id);
        }
    }
}