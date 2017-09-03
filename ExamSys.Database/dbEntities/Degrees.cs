using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database.dbEntities
{
    public class Degrees
    {
        public int id { get; set; }

        //[Index(IsUnique = true)]
        public string Title { get; set; }

        public DateTime created_at { get; set; }
        public DateTime edited_at { get; set; }
    }
}
