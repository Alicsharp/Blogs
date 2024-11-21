using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Common.Interfaces
{
    public interface IArticleRepository
    {
        Task<Domain.Entities. Article?> GetByIdAsync(int id);
        Task<List<Domain.Entities.Article >> GetAllAsync();
        Task<Domain.Entities.Article> GetTracking(long id);

        Task AddAsync(Domain.Entities.Article article);
        Task UpdateAsync(Domain.Entities.Article  article);
        Task<bool> DeleteAsync(int id);
        void Save();
    }
}
