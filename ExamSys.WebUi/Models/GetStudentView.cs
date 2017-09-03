using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamSys.WebUi.Models
{
    public class GetStudentView
    {
        public int dept     { get; set; }
        public int semester { get; set; }
        public int Course   { get; set; }
        public int result_type { get; set; }
    }
}