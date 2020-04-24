using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.DataAccess;
using Prism.Events;

namespace FriendOrganizer.UI.Startup
{
   public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<NavigationviewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDatailViewModel>().As<IFriendDatailViewModel>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            return builder.Build();

        }
    }
}
