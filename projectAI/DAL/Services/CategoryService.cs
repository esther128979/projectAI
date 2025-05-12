using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using DAL.Models;

namespace Dal.Services
{
    public class CategoryService : ICategory
    {
        public Task<Category> Create(Category t)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete(Category t)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategoryByCategoryDescreption()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
