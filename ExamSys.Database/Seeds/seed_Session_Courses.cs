using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Session_Courses
    {
        public static void seed(ExamDB context)
        {

            IList<Session_Courses> Session_Courses = new List<Session_Courses>()
            {
                new Session_Courses()
                {
                    id          = 1,
                    Course      = 1,
                    Department  = 1,
                    Faculty     = 2,
                    Semester    = 1,
                    Session     = 2016,
                    created_at  = DateTime.Now ,
                    edited_at   = DateTime.Now
                },
                new Session_Courses()
                {
                    id          = 2,
                    Course      = 2,
                    Department  = 1,
                    Faculty     = 2,
                    Semester    = 2,
                    Session     = 2016,
                    created_at  = DateTime.Now ,
                    edited_at   = DateTime.Now
                },
            };
            foreach (var item in Session_Courses)
            {
                context.Session_Courses.Add(item);
            }

            context.SaveChanges();

        }
    }
}
