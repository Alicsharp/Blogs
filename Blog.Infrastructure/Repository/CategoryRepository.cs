using Blog.Application.Common.Interfaces;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{


    namespace YourNamespace
    {
        public class CategoryRepository : ICategoryRepository
        {
            private readonly BlogDbContext _context;

            public CategoryRepository(BlogDbContext context)
            {
                _context = context;
            }

            public async Task<Category?> GetByIdAsync(int id)
            {
                return await _context.Categories.FindAsync(id);
            }

            public async Task<List<Category>> GetAllAsync()
            {
                var categories = await _context.Categories
                    .Include(c => c.Childs) // Including the Child Categories if needed
                    .Include(c => c.ParentCategory) // Including the Parent Category if you want to load the related Parent
                    .ToListAsync();
                return categories;
            }

            public async Task AddAsync(Category category)
            {
                await _context.Categories.AddAsync(category);
            }

            public async Task UpdateAsync(Category category)
            {
                _context.Categories.Update(category);
                await Task.CompletedTask; // Optional for consistency
            }

            public async Task DeleteAsync(int id)
            {
                var category = await GetByIdAsync(id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                }
            }

            public void Save()
            {
                _context.SaveChanges();
            }

            public async Task<Category?> GetTracking(long id)
            {
                return await _context.Set<Category>().AsTracking()
                      .Include(c => c.Childs) // بارگذاری چایلدها
                        .Where(r => r.Id == id)
                   .FirstOrDefaultAsync();
            }
        }
    }

}
