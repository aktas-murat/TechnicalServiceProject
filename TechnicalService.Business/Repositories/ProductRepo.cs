
using TechnicalService.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using TechnicalService.Core.Entities;
using TechnicalService.Data.Data;

namespace TechnicalService.Businesss.Repositories
{
    public class CategoryRepo : RepositoryBase<Product, int>
    {
        public CategoryRepo(MyContext context) : base(context)
        {
        }
    }
}