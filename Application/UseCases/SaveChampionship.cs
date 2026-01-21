using System;
using System.Threading.Tasks;
using my_championship.Domain.Entities;
using my_championship.Infrastructure.Repositories; // Added for ChampionshipRepository

namespace my_championship.Domain.UseCases
{
    public class SaveChampionship
    {
        private readonly ChampionshipRepository _repository;

        public SaveChampionship(ChampionshipRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Championship championship)
        {
            if (championship == null)
            {
                throw new ArgumentNullException(nameof(championship), "Championship cannot be null.");
            }

            await _repository.AddAsync(championship);
        }
    }
}