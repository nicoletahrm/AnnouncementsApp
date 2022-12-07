using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        static List<Category> categories = new List<Category>()
        {
            new Category(1, "course"),
            new Category(2, "laboratory"),
            new Category(3, "general")
        };

        [HttpGet]
        public IEnumerable<Category> Categories()
        {
            return categories.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public Category Category(int id)
        {
            foreach (var item in categories)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCategory(int id)
        {
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories.ElementAt(i).Id == id)
                {
                    categories.RemoveAt(i);
                }
            }
        }

        [HttpPost]
        [Route("{id},{name}")]
        public void AddCategory(int id, string name)
        {
            categories.Add(new Category(id, name));
        }
    }
}
