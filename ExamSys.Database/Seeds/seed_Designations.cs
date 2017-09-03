using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Designations
    {
        public static void seed(ExamDB context)
        {
            
            IList<Designations> Designations = new List<Designations>()
            {
                new Designations()
                {
                    id =1,
                    Title = "Admin",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Designations()
                {
                    id =2,
                    Title = "Lecturer",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Designations()
                {
                    id =3,
                    Title = "Lab_Incharge",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Designations()
                {
                    id =4,
                    Title = "Worker",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Designations()
                {
                    id =5,
                    Title = "Student",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
            };
            foreach (var item in Designations)
                context.Designations.Add(item);

            context.SaveChanges();

        }
    }
}
