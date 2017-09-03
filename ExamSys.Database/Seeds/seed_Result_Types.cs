using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Result_Types
    {
        public static void seed(ExamDB context)
        {
            

            IList<Result_Types> Result_Types = new List<Result_Types>()
            {
                new Result_Types()
                {
                    id = 1,
                    Type = "Final",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 2,
                    Type = "Mid",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 3,
                    Type = "Sessional",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 4,
                    Type = "Attendance",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 5,
                    Type = "Quiz",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 6,
                    Type = "Assignment",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 7,
                    Type = "Presentation",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Result_Types()
                {
                    id = 8,
                    Type = "Course Grade points",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
            };

            foreach (var item in Result_Types)
                context.Result_Types.Add(item);

            context.SaveChanges();

        }
    }
}
