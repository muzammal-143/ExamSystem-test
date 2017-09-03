using ExamSys.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ExamSys.WebUi
{
    public class MyIdentity:IIdentity
    {

        public IIdentity Identity { get; set; }
        public LoginView User { get; set; }


        public MyIdentity(LoginView user)
        {
            Identity = new GenericIdentity(user.UserName);
            User = user;
        }

        public string AuthenticationType
        {

            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public string Name
        {
            get { return Identity.Name; }
        }
    }
}