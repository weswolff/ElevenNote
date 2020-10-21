using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _categoryId;
        public CategoryService(Guid categoryId)
        {
            _categoryId = categoryId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == _userId)
            }
        }
    }
}
