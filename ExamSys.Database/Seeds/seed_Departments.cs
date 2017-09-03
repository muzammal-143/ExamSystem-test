using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    class seed_Departments : DropCreateDatabaseAlways<ExamDB>
    {
        public static void seed(ExamDB context)
        {
            

            IList<Departments> Departments = new List<Departments>()
            {
                new Departments()
                {
                    id = 1,
                    Degree = 1,
                    DayTiming = 1,
                    FullName = "Computer Science",
                    ShortName = "BSCS",
                    TotalSemesters =  8,
                    Color = "GREEN",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Departments()
                {
                    id = 2,
                    Degree = 1,
                    DayTiming = 2,
                    FullName = "Business Administration",
                    ShortName = "BBA",
                    TotalSemesters =  8,
                    Color = "RED",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
            };
            foreach (var item in Departments) context.Departments.Add(item);

            context.SaveChanges();

        }
    }
}
