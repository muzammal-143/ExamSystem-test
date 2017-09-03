using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Students
    {
        
        public int          id { get; set; }

        //[Index(IsUnique = true)]
        public string       Roll_No         { get; set; }
        public string       First_Name      { get; set; }
        public string       Last_Name       { get; set; }
        public string       Password        { get; set; }
        public int          Session         { get; set; }
        public string       Gender          { get; set; }

        public string       Picture         { get; set; }

        //[Index(IsUnique = true)]
        public string       Email           { get; set; }

        //[Index(IsUnique = true)]
        public string       RegistrationNO  { get; set; }

        public int          Semester        { get; set; }
        
        //Relations
        //public Statuses     Status        { get; set; }
        //public Departments  Department    { get; set; }
        public int          Department      { get; set; }
        public int          Status          { get; set; }
        public int          Designation     { get; set; }

        public string       Comment         { get; set; }

        //[type(DateTime.Today.ToShortDateString)]
        public DateTime     created_at      { get; set; }
        public DateTime     edited_at       { get; set; }


    }
}
