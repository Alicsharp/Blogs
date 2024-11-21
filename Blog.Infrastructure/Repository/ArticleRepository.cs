using Blog.Application.Common.Interfaces;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repository
{


    namespace YourNamespace
    {
        public class ArticleRepository : IArticleRepository
        {
            private readonly BlogDbContext _context;

            public ArticleRepository(BlogDbContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.Article?> GetByIdAsync(int id)
            {
                return await _context.Articles.FindAsync(id);
            }

          

            public async Task AddAsync(Domain.Entities.Article article)
            {
                await _context.Articles.AddAsync(article);
            }

            public async Task UpdateAsync(Domain.Entities.Article article)
            {
                _context.Articles.Update(article);
                await Task.CompletedTask; // Optional, for consistency
            }

            public async Task<bool> DeleteAsync(int id)
            {
                // 1. پیدا کردن رکورد مورد نظر به صورت غیرهمزمان
                var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
                if (article == null)
                {
                    return false; // رکورد پیدا نشد
                }

                // 2. حذف رکورد
                _context.Articles.Remove(article);

                // 3. ذخیره تغییرات در دیتابیس
                await _context.SaveChangesAsync();

                return true; // حذف با موفقیت انجام شد
            }

            public void Save()
            {
                _context.SaveChanges();
            }

           async Task<List<Article>> IArticleRepository.GetAllAsync()
            {
                return await _context.Articles.ToListAsync();
            }

            public async Task<Article> GetTracking(long id)
            {
                return await _context.Set<Article>().AsTracking()
                       .Where(r => r.Id == id).FirstOrDefaultAsync();
            }
        }
    }

}
