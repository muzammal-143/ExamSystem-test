using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.Seeds
{
    public class seed_All
    {
        ExamDB db = new ExamDB();
        public void start() 
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Courses");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE DayTimings");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Degrees");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Departments");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Designations");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Faculties");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Grades");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Result_Types");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Semester_Details_Results");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Semester_Result");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Statuses");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Session_Courses");
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Students");
            db.SaveChanges();

            seed_Courses.seed(db);
            seed_DayTiming.seed(db);
            seed_Degrees.seed(db);
            seed_Departments.seed(db);
            seed_Designations.seed(db);
            seed_Faculties.seed(db);
            seed_Grades.seed(db);
            seed_Result_Types.seed(db);
            seed_Semester_Details_Results.seed(db);
            seed_Statuses.seed(db);
            seed_Session_Courses.seed(db);
            seed_Students.seed(db);

            
            
        }
    }
}
