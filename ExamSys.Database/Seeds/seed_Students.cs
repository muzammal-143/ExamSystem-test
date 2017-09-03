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
    public class seed_Students
    {
        public static void seed(ExamDB context)
        {
            
            
            context.Students.AddOrUpdate(
                new Students()
                {
                    id = 1,
                    First_Name = "Muzammal",
                    Last_Name = "Hussain",
                    Roll_No = "BCS.F16.32",
                    Email = "bcs.f12.32@gmail.com",
                    Password = "abcd1234",                           
                    Semester = 1,
                    Session = 2016,
                    RegistrationNO = "94384711",
                    Designation = 5,
                    Gender = "Male",
                    Picture = "",
                    Status = 1,
                    Department = 1,
                    Comment = "",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                },
                new Students()
                {
                    id = 2,
                    First_Name = "Ali",
                    Last_Name = "Hamza",
                    Roll_No = "BCS.F16.01",
                    Email = "bcs.f12.01@gmail.com",
                    Password = "abcd1234",
                    Semester = 1,
                    Session = 2016,
                    RegistrationNO = "94344711",
                    Designation = 5,
                    Gender = "Male",
                    Picture = "",
                    Status = 1,
                    Department = 1,
                    Comment = "",
                    created_at = DateTime.Now ,
                    edited_at = DateTime.Now
                }
            );

            context.SaveChanges();

        }
    }
}
