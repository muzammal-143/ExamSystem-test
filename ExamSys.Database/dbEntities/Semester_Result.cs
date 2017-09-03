using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Semester_Result
    {
        public int          id          { get; set; }
        //public int          Session     { get; set; }
        public int          Semester    { get; set; }
        public double       TM          { get; set; }
        public double       OM          { get; set; }
        public double       GP          { get; set; }
        public string       LG          { get; set; }
        
        //Relations
        //public Students      Student     { get; set; }
        //public Departments   Department  { get; set; }
        //public Faculties     Faculty     { get; set; }
        //public Courses       Course      { get; set; }
        //public Result_Types  Result_Type { get; set; }
        public int Student { get; set; }
        public int Department { get; set; }
        public int Faculty { get; set; }
        public int Course { get; set; }
        //public int Result_Type { get; set; }

        //public int Status { get; set; }

        public DateTime created_at { get; set; }
        public DateTime edited_at { get; set; }
    }
}
