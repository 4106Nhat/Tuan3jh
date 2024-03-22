
namespace Tuan3.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
        private readonly ApplicationDbContext _context;
        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Tương tự như EFProductRepository, nhưng cho Category
    }
}
