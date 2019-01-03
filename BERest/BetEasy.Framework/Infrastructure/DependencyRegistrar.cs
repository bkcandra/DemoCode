using BetEasy.Core.Services.DataReader;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BetEasy.Framework.Infrastructure
{
    public static class DependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            #region Services

            services.AddTransient<IDataReaderFactory, DataReaderFactory>();

            #endregion Services

        }
    }
}
