using TravelExperience.Data.Repositories.Interfaces;

namespace TravelExperience.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITripRepository TripRepository { get; }
        Task<int> CompleteAsync();
    }

}
