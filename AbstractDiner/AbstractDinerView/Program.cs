using AbstractDinerBusinessLogic.BusinessLogic;
using AbstractDinerBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity.Lifetime;
using Unity;
using AbstractDinerDatabaseImplement.Implements;

namespace AbstractDinerView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISnackStorage, SnackStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseStorage, WarehouseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SnackLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WarehouseLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
