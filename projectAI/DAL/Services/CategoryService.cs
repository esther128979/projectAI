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

        mycontext db;
        public CategoryService(mycontext? m)
        {
            db = m;
        }
        public async Task<Category> Create(Category t)
        {
            try
            {
                db.Categories.Add(t);
                await db.SaveChangesAsync();
                return t;
            }
            catch(Exception ex) {
            {
                throw new Exception("Error creating Category", ex);
            }
        }

        public async Task<Category> Delete(Category t)
        {
            try
            {
                var category = await db.Categories.FindAsync(t.CategoryCode);
                if (category == null)
                    return null;

                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing Category", ex);
            }
        }

        public Task<List<Category>> GetAll()
        {
            try
            {
                return await db.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Categories", ex);
            }
          
        }

        public Task<List<Category>> GetCategoryByCategoryDescreption()
        {
            try
            {
                return await db.Categories
                .Where(c => !string.IsNullOrEmpty(c.CategoryDescription))
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בהחזרת קטגוריה לפי תאור קטגוריה", ex);
            }
           
        }
        
        public Task<Category> Update(Category t)
        {
            try
            {
                var existing = await db.Categories.FindAsync(t.CategoryCode);
                if (existing == null)
                    return null;

                existing.CategoryDescription = t.CategoryDescription;

                await db.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעדכון קטגוריה", ex);
            }
        }
    }
}
