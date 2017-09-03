using ExamSys.Database;
using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Logics.Models
{
    public class StudentsRefreshStatuses
    {

        private ExamDB db = new ExamDB();
        private Tools tool = new Tools();


        public void RefreshStatuses()
        {
            var students = db.Students.Where(m => m.Status <= 2).ToList();

            foreach (var stu in students)
                update(stu,
                    db.Semester_Result.Where(
                        m => m.Student == stu.id &
                            m.Semester == stu.Semester
                    ).ToList());
                
        }

        public void update(Students student,List<Semester_Result> results) 
        {
            bool drop = false;
            bool probation = false;

            var Dept = db.Departments.SingleOrDefault(m => m.id == student.Department);
            List<double> GPAs = new List<double>();
            foreach (var item in results.GroupBy(m => m.Semester))
            {
                double GPA = tool.getGPA(item.ToList());
                GPAs.Add(GPA);
            }
            
            if (GPAs.Count>0)
            {
                if (GPAs.First() < 1.5) drop = true;
                else
                {
                    int count = 0;
                    foreach (var item in GPAs) if (item < 1.7) count++;
                    if (count == 1) probation = true;
                    //else drop = true;

                }

                // Updating student status
                var dbStudent = db.Students.SingleOrDefault(m => m.id == student.id);
                if (probation == true)
                {
                    dbStudent.Semester += 1;
                    dbStudent.Status = 2;
                    dbStudent.Comment = "You are in probation.";
                }
                else if (drop == true)
                {
                    dbStudent.Status = 3;
                    dbStudent.Comment = "You are Droped.";
                }
                else if (student.Semester == Dept.TotalSemesters)
                {
                    dbStudent.Status = 6;
                    dbStudent.Comment = "Your Degree has been completed.";
                }
                else
                {
                    dbStudent.Semester += 1;
                }
                db.SaveChanges();
            }
            
        }




    }
}
