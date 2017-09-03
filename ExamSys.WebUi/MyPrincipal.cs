using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace ExamSys.WebUi
{
    public class MyPrincipal : IPrincipal
    {

        private MyIdentity MyIdentity { get; set; }

        public MyPrincipal(MyIdentity _identity)
        {
            MyIdentity = _identity;
        }

        public IIdentity Identity
        {
            get { return MyIdentity; }
        }

        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(role);
        }
    }
}