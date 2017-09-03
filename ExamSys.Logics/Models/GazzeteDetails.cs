using ExamSys.Database;
using ExamSys.Database.dbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Logics.Models
{
    public class GazzeteDetails
    {
        private ExamDB db = new ExamDB();

        // Semester Details Result
        public void SemesterDetailsResult(int session,int dept,int semester)
        {
            
        }
        public List<Semester_Details_Results> SemesterDetailsResult(int student, int semester)
        {
            return db.Semester_Details_Results
                    .Where(
                    m =>
                        m.Student == student &
                        m.Semester == semester
                    )
                    .ToList();
        }
        public List<Semester_Details_Results> SemesterDetailsResultCourse(int student, int course)
        {
            return db.Semester_Details_Results
                    .Where(
                    m =>
                        m.Student == student &
                        m.Course == course
                    )
                    .ToList();
        }


        // show Result overall
        public List<Semester_Result> SemesterResult(int student)
        {
            return db.Semester_Result
                    .Where(
                    m =>
                        m.Student == student
                    )
                    .ToList();
        }
        public List<Semester_Result> SemesterResult(int student, int semester)
        {
            return db.Semester_Result
                    .Where(
                    m =>
                        m.Student == student &
                        m.Semester == semester
                    )
                    .ToList();
        }
        public List<Semester_Result> SemesterResultCourse(int student, int course)
        {
            return db.Semester_Result
                    .Where(
                    m =>
                        m.Student == student &
                        m.Course == course
                    )
                    .ToList();
        }
    }
}
