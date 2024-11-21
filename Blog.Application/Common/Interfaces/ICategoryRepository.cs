using Blog.Domain.Entities;

namespace Blog.Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Domain.Entities.Category?> GetByIdAsync(int id);
        Task<List<Domain.Entities.Category>> GetAllAsync();
        Task AddAsync(Domain.Entities.Category  category);
        Task UpdateAsync(Domain.Entities.Category category); 
        Task<Domain.Entities.Category?> GetTracking(long id);
        Task DeleteAsync(int id);
        void Save();
    }
}
