using ExamSys.Database;
using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Logics.Models
{
    public class GazzeteCreation
    {
        private ExamDB db = new ExamDB();
        private Tools tool = new Tools();
        private StudentsRefreshStatuses refreshStatuses = new StudentsRefreshStatuses();
        private Faculties ActiveUser { get; set; }
        // check if exists
        public bool CreateResultCheck()
        {
            var verify = from stu in db.Students.Where(m => m.Status <= 2).ToList()
                         from res in db.Semester_Result.ToList()
                         where
                             stu.id == res.Student && stu.Semester == res.Semester
                         select
                             new
                             {
                                 res
                             };

            if (verify.Count() == 0) return true;
            else return false;

        }
        public bool CreateResultCheck(int dept)
        {
            var verify = from stu in db.Students.Where(m => m.Status == 1 ||  m.Status == 2 && m.Department == dept).ToList()
                         from res in db.Semester_Result.ToList()
                         where
                             stu.id == res.Student && stu.Semester == res.Semester
                         select
                             new
                             {
                                 res
                             };

            if (verify.Count() == 0) return true;
            else return false;
        }
        public bool CreateResultCheck(int dept, int semester)
        {
            var verify = from stu in db.Students.Where(m => m.Status == 1 ||  m.Status == 2 && m.Department == dept & m.Semester == semester).ToList()
                         from res in db.Semester_Result.ToList()
                         where
                             stu.id == res.Student && stu.Semester == res.Semester
                         select
                             new
                             {
                                 res
                             };

            if (verify.Count() == 0) return true;
            else return false;
        }
        public bool CreateResultCheck(int dept, int semester, int Course)
        {
            var verify = from stu in db.Students.Where(m => m.Status == 1 ||  m.Status == 2 && m.Department == dept & m.Semester == semester).ToList()
                         from res in db.Semester_Details_Results.Where(m => m.Course == Course).ToList()
                         where
                             stu.id == res.Student && stu.Semester == res.Semester
                         select
                             new
                             {
                                 res
                             };

            if (verify.Count() == 0) return true;
            else return false;
        }


        // create result
        public void CreateResult(Faculties activeUser)
        {
            ActiveUser = activeUser;
            // get student result by group w.r.t students
            var students = db.Students.Where(m => m.Status <= 2).ToList();
            
            foreach (var stu in students) 
                CreatetNow(stu, 
                    db.Semester_Details_Results.Where(
                        m=>m.Student == stu.id &
                            m.Semester == stu.Semester
                    ).ToList()
                );

            refreshStatuses.RefreshStatuses();
        }
        public void CreateResult(Faculties activeUser, int dept)
        {
            // get student result by group w.r.t students
            var results = from s in db.Students.Where(m => m.Status == 1 ||  m.Status == 2 & m.Department ==  dept)
                          join r in db.Semester_Details_Results
                          on s.Semester equals r.Semester into stu_Res
                          select new
                          {
                              student = s,
                              result = stu_Res
                          };

            foreach (var stu in results) CreatetNow(stu.student, stu.result.ToList());
            refreshStatuses.RefreshStatuses();
        }
        public void CreateResult(Faculties activeUser,int dept, int semester)
        {
            // get student result by group w.r.t students
            var results = from s in db.Students.Where(m => m.Status == 1 ||  m.Status == 2 & m.Department == dept & m.Semester == semester)
                          join r in db.Semester_Details_Results
                          on s.Semester equals r.Semester into stu_Res
                          select new
                          {
                              student = s,
                              result = stu_Res
                          };

            foreach (var stu in results) CreatetNow(stu.student, stu.result.ToList());

            refreshStatuses.RefreshStatuses();
        }
        public void CreateResult(Faculties activeUser,int dept, int semester, int Course)
        {
            // get student result by group w.r.t students
            var results = from s in db.Students.Where(m => m.Status == 1 ||  m.Status == 2 & m.Department == dept & m.Semester == semester)
                          join r in db.Semester_Details_Results.Where(m=>m.Course == Course)
                          on s.Semester equals r.Semester into stu_Res
                          select new
                          {
                              student = s,
                              result = stu_Res
                          };

            foreach (var stu in results) CreatetNow(stu.student, stu.result.ToList());

            refreshStatuses.RefreshStatuses();
        }

         
        // other methods
        public void CreatetNow(Students student , List<Semester_Details_Results> results )
        {
            var courses = results.GroupBy(m => m.Course).ToList();
            foreach (var course in courses)
            {
                
                // getting subject results
                double sessionalObtain = SessionalMarks(course.ToList()); // obtain sessional marks

                var final   = course.SingleOrDefault(m => m.Result_Type == 1);
                var mid     = course.SingleOrDefault(m => m.Result_Type == 2);

                double finalMarks = final != null ? final.Obtain : 0;
                double midMarks = mid != null ? mid.Obtain : 0;

                double marks =  100 * ( finalMarks + midMarks + sessionalObtain ) / (50 + 30 + 20);
                var grades = tool.getGP(marks);

                //course id
                int cid = course.First().id;
                // check if student of course already exists
                var Sem_Result = db.Semester_Result.SingleOrDefault(m=>m.Course == cid);
                if (Sem_Result!=null){
                    //Sem_Result.Student = student.id;
                    //Sem_Result.Semester = student.Semester;
                    Sem_Result.Faculty = ActiveUser.id;
                    //Sem_Result.Department = student.Department;
                    //Sem_Result.Course = final.Course;
                    Sem_Result.OM = marks;
                    Sem_Result.TM = 100;
                    Sem_Result.GP = grades.Points;
                    Sem_Result.LG = grades.Grade;
                    //Sem_Result.created_at = DateTime.Now;
                    Sem_Result.edited_at = DateTime.Now;
                }
                else{
                    db.Semester_Result.Add(
                        new Semester_Result()
                        {
                            Student     = student.id,
                            Semester    = student.Semester,
                            Faculty     = ActiveUser.id,
                            Department  = student.Department,
                            Course      = final.Course,
                            OM          = marks,
                            TM          = 100,
                            GP          = grades.Points,
                            LG          = grades.Grade,
                            created_at  = DateTime.Now,
                            edited_at   = DateTime.Now,
                        }
                    );
                }
                
            }
            db.SaveChanges();

        }
        public double SessionalMarks(List<Semester_Details_Results> course) 
        {
            var c_results = course.Where(m=>m.Result_Type>3).GroupBy(m => m.Result_Type).ToList();
            double sessionalMarks = 0;
            foreach (var c_result in c_results)
            {
                double obtain = c_result.Sum(m => m.Obtain);
                double total = c_result.Sum(m => m.Total);
                sessionalMarks += (obtain / total) * 5;
            }
            return sessionalMarks;
        }

    }
}
