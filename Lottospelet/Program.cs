﻿using Autofac;
using Lottospelet.Interfaces;
using static System.Net.Mime.MediaTypeNames;

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