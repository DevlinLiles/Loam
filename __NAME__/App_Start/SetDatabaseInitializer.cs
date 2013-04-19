using System;
using System.Linq;
using System.Collections.Generic;
using Highway.Data;
using System.Data.Entity;

[assembly: WebActivator.PostApplicationStartMethod(typeof(__NAME__.App_Start.SetDatabaseInitializer), "PostStartup")]
namespace __NAME__.App_Start
{
    public static class SetDatabaseInitializer
    {
        public static void PostStartup()
        {
#pragma warning disable 618
            var initializer = IoC.Container.Resolve<IDatabaseInitializer<DataContext>>();
#pragma warning restore 618
            Database.SetInitializer(initializer);
        }
    }
}
