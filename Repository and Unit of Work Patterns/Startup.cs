using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repository_and_Unit_of_Work_Patterns.Startup))]
namespace Repository_and_Unit_of_Work_Patterns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
