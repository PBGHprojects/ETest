using E.Entities;
using E.Service;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ETest.Web
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> _container =
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        public static IUnityContainer Container => _container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterEntities()
                .RegisterServices();
        }

        public static void RegisterComponents()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }
    }
}