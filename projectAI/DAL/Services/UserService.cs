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
    public class UserService: IUser
    {
        private readonly AppDbContext db;
        public UserService(AppDbContext m)
        {
            db = m;
        }

        public async Task<User> Create(User t)
        {
            try
            {
                db.Users.Add(t);
                await db.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating User", ex);
            }
        }

        public async Task<User> Delete(User t)
        {
            try
            {
                var User = await db.Users.FindAsync(t.Id);
                if (User == null)
                {
                    return null;
                }

                db.Users.Remove(User);
                await db.SaveChangesAsync();
                return User;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing User", ex);
            }
        }

        public async Task<User> Update(User User)
        {
            try
            {
                db.Users.Update(User);
                await db.SaveChangesAsync();
                return User;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating User", ex);
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await db.Users.Include(u => u.Role).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving User data", ex);
            }
        }

        public async Task<User?> GetUserById(int id)
        {
            try
            {
                return await db.Users
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בהחזרת משתמש לפי מזהה", ex);
            }
        }
    }
}
