using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_DayTiming
    {
        public static void seed(ExamDB context)
        {
            
            IList<DayTiming> DayTiming = new List<DayTiming>()
            {
                new DayTiming()
                {
                    id = 1,
                    Timing = "Morning",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new DayTiming()
                {
                    id = 2,
                    Timing = "Evening",
                    created_at = DateTime.Now,
                    edited_at = DateTime.Now
                },
            };
            foreach (var item in DayTiming)
                context.DayTiming.AddOrUpdate(item);

            context.SaveChanges();

        }
    }
}
