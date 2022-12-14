using app.Models;

namespace app.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement>
    {
        Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}
