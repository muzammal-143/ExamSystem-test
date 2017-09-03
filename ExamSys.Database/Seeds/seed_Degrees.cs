using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Degrees
    {
        public static void seed(ExamDB context)
        {
            
            IList<Degrees> Degrees = new List<Degrees>()
            {
                new Degrees()
                {
                    id = 1,
                    Title = "Under graduate",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Degrees()
                {
                    id = 2,
                    Title = "Graduate",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
                new Degrees()
                {
                    id = 3,
                    Title = "Post graduate",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
            };
            foreach (var item in Degrees)
                context.Degrees.Add(item);

            context.SaveChanges();

        }
    }
}
