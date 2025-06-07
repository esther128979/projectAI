using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.Services
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext db;
        public CategoryService(AppDbContext m)
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
            catch (Exception ex)
            {
                {
                    throw new Exception("Error creating Category", ex);
                }
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

        public async Task<List<Category>> GetAll()
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



        public async Task<Category> Update(Category t)
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
        public async Task<Category?> GetCategoryById(int id)
        {
            try
            {
                return await db.Categories
                    .FirstOrDefaultAsync(c => c.CategoryCode == id);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בהחזרת קטגוריה לפי מזהה", ex);
            }
        }





    }
}
