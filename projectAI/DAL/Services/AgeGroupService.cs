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
    public class AgeGroupService : IAgeGroup
    {
        private readonly AppDbContext db;
        public AgeGroupService(AppDbContext m)
        {
            db = m;
        }
        public async Task<AgeGroup> Create(AgeGroup t)
        {
            try
            {
                db.AgeGroups.Add(t);
                await db.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                {
                    throw new Exception("Error creating AgeGroup", ex);
                }
            }

        }


        public async Task<AgeGroup> Delete(AgeGroup t)
        {
            try
            {
                var AgeGroup = await db.AgeGroups.FindAsync(t.AgeCode);
                if (AgeGroup == null)
                    return null;

                db.AgeGroups.Remove(AgeGroup);
                await db.SaveChangesAsync();
                return AgeGroup;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing AgeGroup", ex);
            }
        }

        public async Task<List<AgeGroup>> GetAll()
        {
            try
            {
                return await db.AgeGroups.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving AgeGroup", ex);
            }
        }



        public async Task<AgeGroup> Update(AgeGroup t)
        {
            try
            {
                var existing = await db.AgeGroups.FindAsync(t.AgeCode);
                if (existing == null)
                    return null;

                existing.AgeDescription = t.AgeDescription;

                await db.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעדכון קבוצת גיל", ex);
            }

        }
        public async Task<AgeGroup?> GetAgeGroupById(int id)
        {
            try
            {
                return await db.AgeGroups
                    .FirstOrDefaultAsync(c => c.AgeCode == id);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בהחזרת קבוצת גיל לפי מזהה", ex);
            }
        }





    }
}
