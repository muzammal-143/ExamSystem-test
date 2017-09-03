using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Result_Types
    {
        public int id { get; set; }
        public string Type { get; set; }

        public DateTime created_at { get; set; }
        public DateTime edited_at { get; set; }
    }
}
