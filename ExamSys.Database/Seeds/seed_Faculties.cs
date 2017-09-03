using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_Faculties
    {
        public static void seed(ExamDB context)
        {
            
            IList<Faculties> Faculties = new List<Faculties>()
            {
                new Faculties()
                {
                    id = 1,
                    FirstName = "Muzammal",
                    LastName = "Hussain",
                    UserName = "Muzammal" ,
                    Password = "abcd1234",
                    Designation = 1,
                    Activation = true,
                    Gender = "Male",
                    Picture = "",
                    Comment = "",
                    TimeExtension = DateTime.Now ,
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Faculties()
                {
                    id = 2,
                    FirstName = "Kamran",
                    LastName = "Shoukat",
                    UserName = "Kamran" ,
                    Password = "abcd1234",
                    Designation = 2,
                    Activation = true,
                    Gender = "Male",
                    Picture = "",
                    Comment = "",
                    TimeExtension = DateTime.Now ,
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
            };
            foreach (var item in Faculties)
                context.Faculties.Add(item);

            context.SaveChanges();

        }
    }
}
