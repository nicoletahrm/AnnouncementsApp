namespace app.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }

        public Announcement()
        {

        }

        public Announcement(Guid id, string title, string message, string author, string imageUrl, string categoryId)
        {
            this.Id = id;
            this.Title = title;
            this.Message = message;
            this.Author = author;
            this.ImageUrl = imageUrl;
            this.Category = categoryId;
        }

    }
}
