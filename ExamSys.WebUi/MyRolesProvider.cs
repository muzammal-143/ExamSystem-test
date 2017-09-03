using ExamSys.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ExamSys.WebUi
{
    public class MyRolesProvider:RoleProvider
    {
        private ExamDB DB = new ExamDB();
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }


            string[] Roles = new string[1];
            var admin   = DB.Faculties.SingleOrDefault(m => m.UserName == username);
            var student = DB.Students.SingleOrDefault( m => m.Roll_No  == username);
            if (admin != null)
            {
                Roles[0] = DB.Designations.Find(admin.Designation).Title;
            }
            else if (student != null)
            {
                Roles[0] = DB.Designations.Find(student.Designation).Title;
            }
            else
            {
                return null;
            }
            return Roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}