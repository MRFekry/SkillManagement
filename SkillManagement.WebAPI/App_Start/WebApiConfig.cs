using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.sqlunitOfWork;
using SkillManagement.WebAPI.Unity;
using System.Web.Http;
using Unity;

namespace SkillManagement.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Unity providers registerations
            var container = new UnityContainer();

            container.RegisterType<ISQLEmployeeRepository, SQLEmployeeRepository>();
            container.RegisterType<ISQLSkillRepository, SQLSkillRepository>();
            container.RegisterType<ISQLScoreRepository, SQLScoreRepository>();
            container.RegisterType<ISQLunitOfWork, SQLsqlunitOfWork>();
            container.RegisterType<ISQLEmployeeService, SQLEmployeeService>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<ISQLSkillService, SQLSkillService>();
            container.RegisterType<ISQLScoreService, SQLScoreService>();

            config.DependencyResolver = new UnityResolver(container);

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
