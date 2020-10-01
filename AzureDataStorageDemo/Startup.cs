using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlobStorage;

using CosmosDb;

using Domain.Core;
using Domain.Events;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using TableStorage;

namespace AzureDataStorageDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BlobStorageOptions>(options => Configuration.GetSection("BlobStorageOptions").Bind(options));

            services.Configure<TableStorageOptions>(options => Configuration.GetSection("TableStorageOptions").Bind(options));
            services.Configure<CosmosOptions>(options => Configuration.GetSection("CosmosOptions").Bind(options));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDomainEventRasier, DomainEventRaiser>();

            services.AddScoped<IBlobClient, BlobClient>();
            services.AddScoped<TableStorage.ITableClient, TableStorage.TableClient>();
            services.AddScoped<CosmosDb.ITableClient, CosmosDb.TableClient>();

            services.AddScoped<IHandles<CreateUserEvent>, BlobStorage.CreateUserHandler>();
            services.AddScoped<IHandles<CreateUserEvent>, TableStorage.CreateUserHandler>();
            services.AddScoped<IHandles<CreateUserEvent>, CosmosDb.CreateUserHandler>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
