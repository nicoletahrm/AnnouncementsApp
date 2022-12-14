using System.Configuration;

namespace app.Settings
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string AnnouncementsCollectionName { get => "Announcements";  set => throw new NotImplementedException(); }

        public string ConnectionString { get => "mongodb+srv://unitbv_user:unitbvTesting2022@cluster0.gos4t.mongodb.net/?retryWrites=true&w=majority"; set => throw new NotImplementedException(); }
        public string DatabaseName { get => "NewsUNITBV";  set => throw new NotImplementedException(); }
    }
}
