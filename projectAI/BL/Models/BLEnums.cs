using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public enum eAgeGroup
    {
        Babies =1,
        Children=2,
        Teens=3,
        Adult=4,
        GoldenAge=5
    }
    public enum eStatus
    {
        InProgress = 0,
        Completed = 1
    }
    public enum eGender
    {
        Male=0,
        Female=1
    }
    public enum eCategoryGroup
    {
        Children=1,
        Recipes=2,
        Nature=3,
        Plot=4
    }
    public enum eRole { Admin = 1, Customer = 2 }

}
