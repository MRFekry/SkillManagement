using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Repositories.SQL_Repositories;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.Services.SQL_Services;
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

            #region SQL repositories
            container.RegisterType<ISQLEmployeeRepository, SQLEmployeeRepository>();
            container.RegisterType<ISQLSkillRepository, SQLSkillRepository>();
            container.RegisterType<ISQLScoreRepository, SQLScoreRepository>();
            container.RegisterType<ISQLEmployeeSkillRepository, SQLEmployeeSkillRepository>();
            #endregion

            #region SQL services
            container.RegisterType<ISQLEmployeeService, SQLEmployeeService>();
            container.RegisterType<ISQLSkillService, SQLSkillService>();
            container.RegisterType<ISQLScoreService, SQLScoreService>();
            container.RegisterType<ISQLEmployeeSkillService, SQLEmployeeSkillService>();
            #endregion

            container.RegisterType<ISQLunitOfWork, SQLsqlunitOfWork>();
            
            container.RegisterType<IConnectionFactory, ConnectionFactory>();

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
