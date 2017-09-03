using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Semester_Details_Results
    {
        public static void seed(ExamDB context)
        {
            

            IList<Semester_Details_Results> Semester_Details_Results = new List<Semester_Details_Results>()
            {
                new Semester_Details_Results()
                {
                    id          = 1,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 33,
                    Total       = 40,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 1,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 1,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 1,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 26,
                    Total       = 35,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 1,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 2,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 1,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 7,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 1,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 4,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 2,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 9,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 1,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 5,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 3,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 4,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 1,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 6,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 4,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 8,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 1,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 7,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },

                //----------------------------------------------

                new Semester_Details_Results()
                {
                    id          = 1,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 33,
                    Total       = 40,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 2,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 1,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 1,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 26,
                    Total       = 35,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 2,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 2,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 1,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 7,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 2,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 4,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 2,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 9,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 2,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 5,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 3,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 4,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 2,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 6,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
                new Semester_Details_Results()
                {
                    id          = 4,
                    //Session     = 2016,
                    Semester    = 1,
                    Obtain      = 8,
                    Total       = 10,
                    Edit        = false,
                    Save        = false,
                    Comment     = "",
                    Extension   = DateTime.Now,
                    Student     = 2,
                    Department  = 1,
                    Faculty     = 1,
                    Course      = 1,
                    Result_Type = 7,
                    created_at  = DateTime.Now,
                    edited_at   = DateTime.Now,
                },
            };
            foreach (var item in Semester_Details_Results)
                context.Semester_Details_Results.Add(item);

            context.SaveChanges();
        }
    }
}
