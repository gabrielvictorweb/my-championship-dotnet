using System;
using System.Threading.Tasks;

namespace Mychampionship.Domain.UseCases
{
    public class SaveChampionship
    {
        // Add necessary dependencies via constructor injection if needed

        public SaveChampionship()
        {
            // Initialize dependencies if any
        }

        public async Task ExecuteAsync(Championship championship)
        {
            if (championship == null)
            {
                throw new ArgumentNullException(nameof(championship), "Championship cannot be null.");
            }

            // Add logic to save the championship (e.g., database call)
            await SaveToDatabaseAsync(championship);
        }

        private Task SaveToDatabaseAsync(Championship championship)
        {
            // Simulate saving to a database
            Console.WriteLine($"Saving championship: {championship.Name}");
            return Task.CompletedTask;
        }
    }

    public class Championship
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}