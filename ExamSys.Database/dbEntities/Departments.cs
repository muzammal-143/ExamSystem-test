using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Departments
    {
        public int id { get; set; }

        //[Index(IsUnique = true)]
        public string   ShortName       { get; set; }
        public string   FullName        { get; set; }
        public int      TotalSemesters  { get; set; }
        public string   Color           { get; set; }
        
        //Relation
        //public Degrees      Degree      { get; set; }
        //public DayTiming    DayTiming   { get; set; }
        public int Degree { get; set; }
        public int DayTiming { get; set; }

        public DateTime created_at { get; set; }
        public DateTime edited_at { get; set; }
    }



}
