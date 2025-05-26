
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IAgeGroup : ICrud<AgeGroup>
    {
        Task<AgeGroup> GetAgeGroupById(int id);
    }
}
