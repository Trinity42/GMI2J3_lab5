using Autofac;
using Lottospelet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<externalIDTjänst>().As<IexternalIDTjänst>();
            builder.RegisterType<ViTestarOmDettaFungerar>().As<IViTestarOmDettaFungerar>();
            builder.RegisterType<PersonProcessor>().As<IPersonProcessor>();
            builder.RegisterType<SqliteDataAccess>().As<ISqlitDataAccess>();
            builder.RegisterType<Lottorad>().As<ILottorad>();


            return builder.Build();
        }
    }
}
