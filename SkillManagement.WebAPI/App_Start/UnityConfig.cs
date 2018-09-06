using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Repositories.SQL_Repositories;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.Services.SQL_Services;
using SkillManagement.DataAccess.sqlunitOfWork;
using System;

using Unity;

namespace SkillManagement.WebAPI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
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

        }
    }
}