using MyNewCiniesOction.DAL;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task<bool> DeleteCategory(int categoryId)
        {
            return await _categoryDal.DeleteCategory(categoryId);
        }

        public async Task<List<Category>> GetCategory()
        {
            return await _categoryDal.GetCategory();
        }

        public async Task<bool> PostCategory(Category category)
        {
            return await _categoryDal.PostCategory(category);
        }

        public async Task<bool> UpdatCategory(Category category)
        {
            return await _categoryDal.UpdatCategory(category);
        }
    }
}
