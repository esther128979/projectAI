using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // ← חשוב להוסיף
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public enum eAgeGroup
    {
        [Display(Name = "תינוקות")]
        Babies = 1,

        [Display(Name = "ילדים")]
        Children = 2,

        [Display(Name = "נוער")]
        Teens = 3,

        [Display(Name = "מבוגרים")]
        Adult = 4,

        [Display(Name = "גיל הזהב")]
        GoldenAge = 5
    }

    public enum eStatus
    {
        [Display(Name = "בתהליך")]
        InProgress = 0,

        [Display(Name = "הושלם")]
        Completed = 1
    }

    public enum eGender
    {
        [Display(Name = "זכר")]
        Male = 0,

        [Display(Name = "נקבה")]
        Female = 1
    }

    public enum eCategoryGroup
    {
        [Display(Name = "ילדים")]
        Children = 1,

        [Display(Name = "מתכונים")]
        Recipes = 2,

        [Display(Name = "טבע")]
        Nature = 3,

        [Display(Name = "עלילה")]
        Plot = 4
    }

    public enum eRole
    {
        [Display(Name = "מנהל")]
        Admin = 1,

        [Display(Name = "לקוח")]
        Customer = 2
    }
}
