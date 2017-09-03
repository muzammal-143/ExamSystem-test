using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Grades
    {
        public static void seed(ExamDB context)
        {
            

            IList<Grades> Grades = new List<Grades>()
            {
                new Grades()
                {
                    id = 1,
                    Lower_Range = 0,
                    Upper_Range = 49,
                    Points = 0,
                    Grade = "F",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 2,
                    Lower_Range = 50,
                    Upper_Range = 52,
                    Points = 1.0,
                    Grade = "D",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 3,
                    Lower_Range = 53,
                    Upper_Range = 56,
                    Points = 1.33,
                    Grade = "D+",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 4,
                    Lower_Range = 57,
                    Upper_Range = 59,
                    Points = 1.66,
                    Grade = "C-",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 5,
                    Lower_Range = 60,
                    Upper_Range = 63,
                    Points = 2.0,
                    Grade = "C",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 6,
                    Lower_Range = 63,
                    Upper_Range = 66,
                    Points = 2.33,
                    Grade = "C+",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 7,
                    Lower_Range = 67,
                    Upper_Range = 69,
                    Points = 2.66,
                    Grade = "B-",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 8,
                    Lower_Range = 70,
                    Upper_Range = 74,
                    Points = 3.00,
                    Grade = "B",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 9,
                    Lower_Range = 75,
                    Upper_Range = 79,
                    Points = 3.33,
                    Grade = "B+",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Grades()
                {
                    id = 10,
                    Lower_Range = 80,
                    Upper_Range = 84,
                    Points = 3.66,
                    Grade = "A",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },new Grades()
                {
                    id = 11,
                    Lower_Range = 85,
                    Upper_Range = 100,
                    Points = 4.0,
                    Grade = "A+",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
            };
            foreach (var item in Grades)
                context.Grades.Add(item);

            context.SaveChanges();

        }
    }
}
