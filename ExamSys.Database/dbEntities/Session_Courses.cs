using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Session_Courses
    {   

        public int         id         { get; set; }
        public int         Session    { get; set; }
        public int         Semester   { get; set; }

        //Relations
        //public Departments   Department  { get; set; }
        //public Faculties     Faculty     { get; set; }
        //public Courses       Course      { get; set; }
        
        public int Department { get; set; }
        public int Faculty { get; set; }
        public int Course { get; set; }
        

        public DateTime created_at { get; set; }
        public DateTime edited_at { get; set; }

    }
}
