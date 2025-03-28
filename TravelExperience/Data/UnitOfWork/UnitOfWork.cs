
using TravelExperience.Data.Repositories;
using TravelExperience.Data.Repositories.Interfaces;

namespace TravelExperience.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        public ITripRepository TripRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            TripRepository = new TripRepository(_context);
        }

 
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
