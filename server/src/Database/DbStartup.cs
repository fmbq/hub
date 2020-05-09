using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FMBQ.Hub.Database
{
    public class DbStartup : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public DbStartup(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // using (var scope = serviceProvider.CreateScope())
            // {
                DbConnection connection = serviceProvider
                    .GetService<IConnectionProvider>()
                    .Connection;

                await DbInstrumenter.InstrumentIfNeeded(connection);
            // }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
