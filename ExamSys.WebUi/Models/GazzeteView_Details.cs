using ExamSys.Database;
using ExamSys.Database.dbEntities;
using ExamSys.Logics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamSys.WebUi.Models
{
    public class GazzeteView_Details 
    {
        public Students Student { get; set; }
        public List<GazzeteView_Courses> GazzeteView_Courses = new List<GazzeteView_Courses>();
        public double GPA { get; set; }

        private ExamDB db = new ExamDB();
        private Tools tools = new Tools();
        public List<GazzeteView_Details> get(int session, int dept, int semester)
        {
            //Active students
            List<Students> Students = db.Students.Where(m => m.Session == session & m.Department == dept & (m.Status <= 2 | m.Status == 6)).ToList(); //& m.Semester <= semester
            List<Session_Courses> Session_Semester_Courses = db.Session_Courses.Where(m => m.Session == session & m.Department == dept & m.Semester == semester).ToList();

            List<GazzeteView_Details> gazzeteViewDetails = new List<GazzeteView_Details>();
            if(Students.Count>0)
            foreach (var stu in Students)
            {
                GazzeteView_Details gvd = new GazzeteView_Details();
                gvd.Student = stu;
                
                if (Session_Semester_Courses.Count > 0)
                {
                    foreach (var ssc in Session_Semester_Courses)
                    {
                        GazzeteView_Courses gvc = new GazzeteView_Courses();

                        gvc.Course = db.Courses.Find(ssc.Course);
                        var courseResults = db.Semester_Details_Results.Where(m => m.Student == stu.id && m.Course == ssc.Course & m.Semester == semester).ToList();
                        var final = courseResults.SingleOrDefault(m => m.Result_Type == 1);
                        var mid = courseResults.SingleOrDefault(m => m.Result_Type == 2);
                        GazzeteCreation gc = new GazzeteCreation();
                        gvc.ObtainMarks = final.Obtain + mid.Obtain + gc.SessionalMarks(courseResults);
                        gvc.TotalMarks = final.Total + mid.Total + 20;
                        var points = db.Semester_Result.SingleOrDefault(m => m.Student == stu.id & m.Course == ssc.Course);
                        gvc.Points = points != null ? points.GP : 0;

                        if (gvc == null) continue;
                        gvd.GazzeteView_Courses.Add(gvc);
                    }
                    //GPA
                    gvd.GPA = tools.getGPA(
                        db.Semester_Result
                        .Where(
                            m => m.Student == stu.id &
                                 m.Semester == semester
                                 ).ToList()
                        );//</GPA
                    if(gvd!=null) gazzeteViewDetails.Add(gvd);
                }
            }
            return gazzeteViewDetails;
        }

    
    
    }
    public class GazzeteView_Courses 
    {
        public Courses Course       { get; set; }
        public double TotalMarks    { get; set; }
        public double ObtainMarks   { get; set; }
        public double Points        { get; set; }
    }

}