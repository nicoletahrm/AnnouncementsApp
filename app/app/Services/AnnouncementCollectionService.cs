using app.Models;

namespace app.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        List<Announcement> _announcements = new List<Announcement>()
        {
            new Announcement { Id = Guid.NewGuid(), Title = "First Announcement", Description = "First Announcement Description", Author = "Author_1", CategoryId = "1" },
            new Announcement { Id = Guid.NewGuid(), Title = "Second Announcement", Description = "Second Announcement Description", Author = "Author_1", CategoryId = "1" },
            new Announcement { Id = Guid.NewGuid(), Title = "Third Announcement", Description = "Third Announcement Description", Author = "Author_2", CategoryId = "1" },
            new Announcement { Id = Guid.NewGuid(), Title = "Fourth Announcement", Description = "Fourth Announcement Description", Author = "Author_3", CategoryId = "1" },
            new Announcement { Id = Guid.NewGuid(), Title = "Fifth Announcement", Description = "Fifth Announcement Description", Author = "Author_4", CategoryId = "1" },
        };

        public Announcement Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Announcement> GetAll()
        {
            return _announcements;
        }

        public List<Announcement> GetAnnouncementsByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }

        public bool Create(Announcement model)
        {
            if (model != null)
            {
                model.Id = Guid.NewGuid();
                _announcements.Add(model);
                return true;
            }

            return false;
        }

        public bool Update(Guid id, Announcement model)
        {

            var announcementToUpdate = _announcements.FirstOrDefault(x => x.Id == id);

            if (announcementToUpdate == null)
            {
                return false;
            }

            Guid oldId = announcementToUpdate.Id;

            _announcements.Remove(announcementToUpdate);
            model.Id = oldId;
            _announcements.Add(model);

            return true;
        }

        public bool Delete(Guid id)
        {
            var announcementToDelete = _announcements.FirstOrDefault(x => x.Id == id);

            if (announcementToDelete != null)
            {
                _announcements.Remove(announcementToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
