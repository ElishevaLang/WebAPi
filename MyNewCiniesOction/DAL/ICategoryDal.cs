using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface ICategoryDal
    {
        public Task<List<Category>> GetCategory();
        public Task<bool> PostCategory(Category category);
        public Task<bool> DeleteCategory(int categoryId);
        public Task<bool> UpdatCategory(Category category);
    }
}
