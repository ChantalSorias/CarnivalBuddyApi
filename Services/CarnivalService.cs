using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Repositories.Interfaces;

namespace CarnivalBuddyApi.Services
{
    public class CarnivalService : ICarnivalService
    {
        private readonly ICarnivalRepository _carnivalRepository;

        public CarnivalService(ICarnivalRepository carnivalRepository)
        {
            _carnivalRepository = carnivalRepository;
        }

        public async Task<Carnival> GetById(string id)
        {
            return await _carnivalRepository.GetById(id);
        }

        public async Task<List<Carnival>> GetAll()
        {
            return await _carnivalRepository.GetAll();
        }

        public async Task<Carnival> Create(Carnival carnival)
        {
            return await _carnivalRepository.Create(carnival);
        }

        public async Task Update(Carnival carnival)
        {
            await _carnivalRepository.Update(carnival);
        }

        public async Task Delete(string id)
        {
            await _carnivalRepository.Delete(id);
        }
    }
}