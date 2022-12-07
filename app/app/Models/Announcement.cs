namespace app.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CategoryId { get; set; }

        public Announcement()
        {

        }

        public Announcement(Guid id, string title, string description, string author, string categoryId)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Author = author;
            this.CategoryId = categoryId;
        }

    }
}
