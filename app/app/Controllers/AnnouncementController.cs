using app.Models;
using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await
            _announcementCollectionService.GetAll();
            return Ok(announcements);
        }

        [HttpPost]
        public async Task<bool> Create(Announcement announcement)
        {
            if (announcement.Id == Guid.Empty)
            {
                announcement.Id = Guid.NewGuid();

            }
            await _announcementCollectionService.Create(announcement);
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _announcementCollectionService.Delete(id);

        }

        [HttpGet("{id}")]
        public async Task<Announcement> Get(Guid id)
        {
            return await _announcementCollectionService.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(Guid id, Announcement announcement)
        {
            announcement.Id = id;
            return await _announcementCollectionService.Update(id, announcement);

        }

        //[HttpGet("{id}")]
        //public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        //{
        //    return await _announcementCollectionService.GetAnnouncementsByCategoryId(categoryId);
        //}


        ///// <summary>
        ///// Gets all the announcements
        ///// </summary>
        //[HttpGet]
        //public IActionResult GetAnnouncements()
        //{
        //    List<Announcement> Announcements = _announcementCollectionService.GetAll();
        //    return Ok(Announcements);
        //}

        ///// <summary>
        ///// Creates a new announcement
        ///// </summary>
        //[HttpPost]
        //public ActionResult CreateAnnouncement([FromBody] Announcement announcement)
        //{
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement cannot be null");
        //    }

        //    _announcementCollectionService.Create(announcement);

        //    return Ok(announcement);
        //}

        ///// <summary>
        ///// Updates an announcement
        ///// </summary>
        //[HttpPut]
        //public ActionResult UpdateAnnouncement([FromBody] Announcement announcement)
        //{
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement cannot be null");
        //    }

        //    if (_announcementCollectionService.Update(announcement.Id, announcement))
        //    {
        //        return Ok(announcement);
        //    }

        //    return BadRequest("Announcement could not be updated");
        //}

        ///// <summary>
        ///// Deletes an announcement
        ///// </summary>
        //[HttpDelete]
        //public ActionResult DeleteAnnouncement(Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        return Ok(_announcementCollectionService.Delete(id));
        //    }

        //    return BadRequest();
        //}
    }
}
