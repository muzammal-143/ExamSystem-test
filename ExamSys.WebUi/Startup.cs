using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamSys.WebUi.Startup))]
namespace ExamSys.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
