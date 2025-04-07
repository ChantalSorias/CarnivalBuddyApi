using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Repositories.Interfaces
{
    public interface ICarnivalRepository
    {
        public Task<List<Carnival>> GetAll();
        public Task<Carnival> GetById(string id);
        public Task<Carnival> Create(Carnival carnival);
        public Task Update(Carnival carnival);
        public Task Delete(string id);
    }
}