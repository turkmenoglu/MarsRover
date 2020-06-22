using MarsRover.Application.Contracts;
using MarsRover.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarsRover.Application
{
    public static class Bootstrapper
    {
        private static IServiceProvider _serviceProvider;

        public static void Init()
        {
            var services = new ServiceCollection()
                .AddSingleton<ILandingSurface, Plataeu>()
                .AddSingleton<IRoverSquadManager, RoverSquadManager>()
                .AddSingleton<ICommandCenter, CommandCenter>();           
            
            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }        
    }
}