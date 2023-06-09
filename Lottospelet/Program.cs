﻿using Autofac;
using Lottospelet.Interfaces;

namespace Lottospelet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

        }
    }
}