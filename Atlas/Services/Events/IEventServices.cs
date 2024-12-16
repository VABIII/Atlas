using Atlas.Data;

namespace Atlas.Services.Events
{
    public interface IEventServices
    {
        Task<List<Venues>>GetEvents();

    }
}

