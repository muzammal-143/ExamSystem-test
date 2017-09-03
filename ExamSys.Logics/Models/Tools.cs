using ExamSys.Database;
using ExamSys.Database.dbEntities;
//using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;
using System.Web.Mvc;


namespace ExamSys.Logics.Models
{
    public class Tools
    {
        public ExamDB db = new ExamDB();

        // DropDownLists
        public IEnumerable<SelectListItem> Courses
        {
            get
            {
                return from item in db.Courses select
                    new SelectListItem
                    {
                        Value = item.id.ToString(),
                        Text  = item.Name
                    };        
            }
        }
        public IEnumerable<SelectListItem> DayTimings
        {
            get
            {
                return from item in db.DayTiming
                       select
                           new SelectListItem
                           {
                               Value = item.id.ToString(),
                               Text = item.Timing
                           }; 
            }
        }
        public IEnumerable<SelectListItem> Degrees
        {
            get
            {
                return from item in db.Degrees
                    select 
                            new SelectListItem
                            {
                                Value = item.id.ToString(),
                                Text = item.Title
                            };
            }
        }
        public IEnumerable<SelectListItem> Departments
        {
            get
            {
                return from item in db.Departments select 
                    new SelectListItem
                    {
                        Text = item.FullName ,
                        Value = item.id.ToString()
                    };
            }
        }
        public IEnumerable<SelectListItem> Designations
        {
            get
            {
                return from item in db.Designations
                       select
                           new SelectListItem
                           {
                               Value = item.id.ToString(),
                               Text = item.Title
                           };
            }
        }
        public IEnumerable<SelectListItem> Faculties
        {
            get
            {
                return from item in db.Faculties
                       select
                           new SelectListItem
                           {
                               Value = item.id.ToString(),
                               Text = item.FirstName + " " + item.LastName
                           };
            }
        }
        public IEnumerable<SelectListItem> Result_Types
        {
            get
            {
                return from item in db.Result_Types
                       select
                           new SelectListItem
                           {
                               Value = item.id.ToString(),
                               Text = item.Type
                           };
            }
        }
        public IEnumerable<SelectListItem> Statuses
        {
            get
            {
                return from item in db.Statuses
                       select
                           new SelectListItem
                           {
                               Value = item.id.ToString(),
                               Text = item.Title
                           };
            }
        }
        public IEnumerable<SelectListItem> Gender
        {
            get
            {
                return new List<SelectListItem>{
                            new SelectListItem
                            {
                                Value = "Male",
                                Text = "Male"
                            },
                            new SelectListItem
                            {
                                Value = "Female",
                                Text = "Female"
                            }
                         };
                           
            }
        }

        // retuen details of grade points
        public Grades getGP(double marks) 
        {
            Grades grade = new Grades();
            foreach (var item in db.Grades.ToList())
            {
                grade = item;
                if (marks >= item.Lower_Range && marks <= item.Upper_Range) break;
            }
            return grade;
        }

        public double getGPA(List<Semester_Result> results)
        {
            double TotalCH = 0;
            double TotalGP = 0;
            var Cources = db.Courses.ToList();
            foreach (var item in results)
            {
                double ch = Cources.SingleOrDefault(m => m.id == item.Course).CH;
                TotalGP += item.GP * ch;
                TotalCH += ch;
            }
            var r = (double)(TotalGP / TotalCH);
            return r;
        }
        //Details Lists
        // All students
        public List<Students> Students(int session) 
        {
            return db.Students.Where(m => m.Session == session).ToList();
        }
        // Department students
        public List<Students> Students(int session, int dept)
        {
            return db.Students.Where(m => m.Session == session & m.Department == dept).ToList();
        }
        // Department & Semester
        public List<Students> Students(int session, int dept,int semester)
        {
            return db.Students.Where(m => m.Session == session & m.Department == dept & m.Semester == semester).ToList();
        }

        public List<Courses> SemesterSub(int session,int semester) 
        {
            var semesterCources = db.Session_Courses.Where(m => m.Session == session & m.Semester == semester).Select(m => m.id).ToArray();
            return db.Courses.Where(m => semesterCources.Contains(m.id)).ToList();
        }







    }
}
