using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.UnitOfWork;
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

            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<ISkillRepository, SkillRepository>();
            container.RegisterType<IScoreRepository, ScoreRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<ISkillService, SkillService>();
            container.RegisterType<IScoreService, ScoreService>();

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
