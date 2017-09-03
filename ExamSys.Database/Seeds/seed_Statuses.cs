using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Statuses 
    {
        public static void seed(ExamDB context)
        {

            

            IList<Statuses> Statuses = new List<Statuses>()
            {
                new Statuses()
                {
                    id = 1,
                    Title = "Active",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Statuses()
                {
                    id = 2,
                    Title = "Probation",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Statuses()
                {
                    id = 3,
                    Title = "Drop",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Statuses()
                {
                    id = 4,
                    Title = "SemesterFreeze",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Statuses()
                {
                    id = 5,
                    Title = "Block",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Statuses()
                {
                    id = 6,
                    Title = "DegreeComplete",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Statuses()
                {
                    id = 7,
                    Title = "CourseClear",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                }

            };
            foreach (var item in Statuses)
                context.Statuses.Add(item);

            context.SaveChanges();

        }

        
    }
}
