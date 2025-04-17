using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Repositories.Interfaces
{
    public interface IUserRepository
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