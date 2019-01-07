using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TIEDPAG.Common;
using TIEDPAG.Dispense.DAL;

namespace TIEDPAG.Dispense.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<tiedpag_dispenseContext>(o => o.UseMySQL(connection));

            //services.AddScoped<DbContext>(p => p.GetService<tiedpag_dispenseContext>());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterAssemblyTypes(
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "TIEDPAG.*.dll", SearchOption.TopDirectoryOnly)
                .ToArray().Select(Assembly.LoadFile).ToArray())
                .Where(t => t.IsAssignableTo<IDiBase>())
                .AsSelf()
                .AsImplementedInterfaces();

            //builder.RegisterType<DAL.BaseDAL<Model.Area>>().AsSelf();
            //builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsSelf();
            //builder.RegisterAssemblyTypes(typeof(Biz.BLL).Assembly).AsSelf();
            //builder.RegisterAssemblyTypes(typeof(DAL.tiedpag_dispenseContext).Assembly).AsSelf();
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
