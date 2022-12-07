using app.Models;

namespace app.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement>
    {
        List<Announcement> GetAnnouncementsByCategoryId(string categoryId);
    }
}
