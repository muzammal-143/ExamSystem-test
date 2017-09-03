using ExamSys.Database.dbEntities;
using ExamSys.Database.Seeds;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys.Database
{
    public class ExamDB : DbContext
    {
        public DbSet<Courses>                  Courses                     { get; set; }
        public DbSet<DayTiming>                DayTiming                   { get; set; }
        public DbSet<Degrees>                  Degrees                     { get; set; }
        public DbSet<Departments>              Departments                 { get; set; }
        public DbSet<Designations>             Designations                { get; set; }
        public DbSet<Faculties>                Faculties                   { get; set; }
        public DbSet<Grades>                   Grades                      { get; set; }
        public DbSet<Result_Types>             Result_Types                { get; set; }
        public DbSet<Semester_Details_Results> Semester_Details_Results    { get; set; }
        public DbSet<Semester_Result>          Semester_Result             { get; set; }
        public DbSet<Session_Courses>          Session_Courses             { get; set; }
        public DbSet<Statuses>                 Statuses                    { get; set; }
        public DbSet<Students>                 Students                    { get; set; }

    }
}
