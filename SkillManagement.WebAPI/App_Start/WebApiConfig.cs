using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Repositories.SQL_Repositories;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.Services.SQL_Services;
using SkillManagement.DataAccess.sqlunitOfWork;
using System.Web.Http;
using Unity;

namespace SkillManagement.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "AddEmpolyee",
            //    routeTemplate: "Employees"
            //);
        }

    }
}
