using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Highway.Data.Interfaces;
using Highway.Data.EventManagement;
using __NAME__.Models;
using Highway.Data;
using System.Data.Entity;

namespace __NAME__.Installers
{
    // TODO Change the connection string to match your environment.
    public class HighwayDataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDataContext>().ImplementedBy<DataContext>()
                    .DependsOn(new { connectionString = @"Data Source=.;Initial Catalog=ChangeMyConnectionString;Integrated Security=SSPI;" }),
                Component.For<IRepository>().ImplementedBy<Repository>(),
                Component.For<IEventManager>().ImplementedBy<EventManager>(),
                Component.For<IMappingConfiguration>().ImplementedBy<Mappings>(),
                Component.For<IDatabaseInitializer<DataContext>>().ImplementedBy<DatabaseInitializer>()
                );
        }
    }
}
