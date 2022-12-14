using app.Models;
using app.Settings;
using MongoDB.Driver;

namespace app.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }

        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true);
            return result.ToList();
        }
        public async Task<Announcement?> Get(Guid id)
        {
            return await _announcements.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> Create(Announcement announcement)
        {
            if (announcement == null)
            {
                return false;
            }
            await _announcements.InsertOneAsync(announcement);
            return true;

        }
        public async Task<bool> Update(Guid id, Announcement announcement)
        {
            var r = await _announcements.ReplaceOneAsync(x => x.Id == id, announcement);
            if (r.ModifiedCount != 0)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var r = await _announcements.DeleteOneAsync(x => x.Id == id);
            if (!r.IsAcknowledged)
            {
                return false;
            }
            return true;
        }
        public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        {

            var result = (await _announcements.FindAsync(announcement => announcement.Category == categoryId)).ToList();
            return result;
        }
    }
}
