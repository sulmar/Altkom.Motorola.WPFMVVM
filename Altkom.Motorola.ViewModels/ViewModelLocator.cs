using Altkom.Motorola.FakeServices;
using Altkom.Motorola.Framework;
using Altkom.Motorola.IServices;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.ServiceLocation;

namespace Altkom.Motorola.ViewModels
{
    public class ViewModelLocator
    {

        // PM> Install-Package CommonServiceLocator

        // private IContainer container;
       // private IUnityContainer container;

        public ViewModelLocator()
        {
           // UseUnity();

             UseAutoFac();
        }

        private void UseUnity()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ShellViewModel>();
            container.RegisterType<DevicesViewModel>();
            container.RegisterType<DeviceViewModel>();
            container.RegisterType<ContactsViewModel>();
            container.RegisterType<IDevicesService, FakeDevicesService>();
            container.RegisterType<IContactsService, FakeContactsService>();
            container.RegisterSingleton<INavigationService, FrameNavigationService>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }

        private void UseAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ShellViewModel>();
            builder.RegisterType<DevicesViewModel>();
            builder.RegisterType<DeviceViewModel>();
            builder.RegisterType<ContactsViewModel>();
            builder.RegisterType<FakeDevicesService>().As<IDevicesService>();
            builder.RegisterType<FakeContactsService>().As<IContactsService>();

            builder.RegisterType<FrameNavigationService>().As<INavigationService>().SingleInstance();

            var container = builder.Build();

            // PM> Install-Package Autofac.Extras.CommonServiceLocator
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }

        // Bezpośrednie kodowanie
        // public ShellViewModel ShellViewModel => new ShellViewModel(new FakeDevicesService());

        // Poprzez kontener
        // public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public DevicesViewModel DevicesViewModel => ServiceLocator.Current.GetInstance<DevicesViewModel>();
        public DeviceViewModel DeviceViewModel => ServiceLocator.Current.GetInstance<DeviceViewModel>();
        public ContactsViewModel ContactsViewModel => ServiceLocator.Current.GetInstance<ContactsViewModel>();
    }
}
