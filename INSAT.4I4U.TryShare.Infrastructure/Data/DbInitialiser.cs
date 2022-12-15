using INSAT._4I4U.TryShare.Core.Models;

namespace INSAT._4I4U.TryShare.Infrastructure.Data
{
    public class DbInitialiser
    {
        private readonly ApplicationDbContext context;

        public DbInitialiser(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Run()
        {
            context.Database.EnsureCreated();

            if (context.Tricycles.Any())
                return;

            var tricycles = new List<Tricycle>
            {
                new Tricycle
                {
                    BatteryPercentage = 24,
                    IsAvailable = false,
                    LastKnownLatitude = 425.0,
                    LastKnownLongitude = 1023.0,
                    IsInDangerZone = true,
                },
                new Tricycle
                {
                    BatteryPercentage = 24,
                    IsAvailable = false,
                    LastKnownLatitude = 3680.9,
                    LastKnownLongitude = 2474.2,
                    IsInDangerZone = false,
                }
            };

            context.Tricycles.AddRange(tricycles);
            context.SaveChanges();
        }

        public void FreeTricycles()
        {
            context.Database.EnsureCreated();

            foreach (var tricycle in context.Tricycles)
            {
                tricycle.IsAvailable = true;
            }
            context.SaveChanges();
        }
    }
}