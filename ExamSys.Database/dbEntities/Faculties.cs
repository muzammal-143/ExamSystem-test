using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Faculties
    {
        public int id {get; set;}

        //[Index(IsUnique = true)]
        public string   UserName        { get; set; }
        public string   Password        { get; set; }
        public bool     Activation      { get; set; }
        public string   FirstName       { get; set; }
        public string   LastName        { get; set; }
        public string   Gender          { get; set; }
        public string   Picture         { get; set; }
        public string   Comment         { get; set; }
        public DateTime TimeExtension   { get; set; }
        //Relation
        //public Designations Designation { get; set; }
        public int      Designation     { get; set; }

        //important fields
        //public bool     Activation { get; set; }
        public DateTime     created_at  { get; set; }
        public DateTime     edited_at   { get; set; }
    }


}
