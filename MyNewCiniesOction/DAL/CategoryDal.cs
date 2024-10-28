using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.Migrations;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public class CategoryDal : ICategoryDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;

        public CategoryDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            try {
            var category = await _chiniesOctionContext.Category.FindAsync(categoryId);
            if (category == null)
            {
                return false;
            }

            _chiniesOctionContext.Category.Remove(category);
            await _chiniesOctionContext.SaveChangesAsync();

            return true; 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Category>> GetCategory()

        {
            try
            {
                return await _chiniesOctionContext.Category.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
        public  async Task<bool> PostCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    return false;
                }

                await _chiniesOctionContext.Category.AddAsync(category);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdatCategory(Category category)
        {
            try
            {
                var c = _chiniesOctionContext.Category.Where(cat => cat.CategoryId == category.CategoryId).First();
                if (c == null)
                {
                    return false;
                }
                c.CategoryName = category.CategoryName;

                _chiniesOctionContext.Category.Update(c);//needed???
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
