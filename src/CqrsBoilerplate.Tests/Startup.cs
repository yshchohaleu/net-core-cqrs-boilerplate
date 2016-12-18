using System.IO;
using System.Linq;
using AutoMapper;
using CqrsBoilerplate.Entities.Contexts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyModel;

namespace CqrsBoilerplate.Tests
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configPath = Path.Combine(env.ContentRootPath, "../../../");

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"{configPath}/appsettings.json ")
                .AddJsonFile($"{configPath}/appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var referencedAssembles = DependencyContext.Default.RuntimeLibraries;
            var coreAssembly = referencedAssembles.Single(x => x.Name.Equals("CqrsBoilerplate"));
            var assembly = Assembly.Load(new AssemblyName(coreAssembly.Name));
            services.AddMediatR(assembly);

            services.AddTransient<UsersContext>();
            services.AddDbContext<UsersContext>(options => options.UseNpgsql(Configuration["Databases:UsersDbSqlConnectionString"]));
        }

        public void Configure(IApplicationBuilder app)
        {
            TestContext.Current.ServiceProvider = app.ApplicationServices;

            var config = new MapperConfiguration(TypeMappings.Configure);
            AutoMapper.Mapper.Initialize(TypeMappings.Configure);
        }

    }
}
