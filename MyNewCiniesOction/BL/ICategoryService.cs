using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategory();
        public Task<bool> PostCategory(Category category);
        public Task<bool> DeleteCategory(int categoryId);
        public Task<bool> UpdatCategory(Category category);
    }
}
