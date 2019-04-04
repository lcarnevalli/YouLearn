using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;
using YouLearn.Infra.Persistence.EF;
using YouLearn.Infra.Persistence.Repositories;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<YouLearnContext, YouLearnContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<INotifiable, Notifiable>();

            //services.AddTransient<IServiceCanal, ServiceCanal>();
            //services.AddTransient<IServicePlayList, ServicePlayList>();
            //services.AddTransient<IServiceVideo, ServicePlayVideo>();
            services.AddTransient<IServiceCanal, ServiceCanal>();

            //services.AddTransient<IRepositoryCanal, RepositoryCanal>();
            //services.AddTransient<IRepositoryCanalPlayList, RepositoryPlayList>();
            //services.AddTransient<IRepositoryVideo, RepositoryVideo>();
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();




            services.AddMvc();

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "YouLearn", Version = "v1" }); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseSwagger();
            app.UseSwaggerUI(c=> 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YouLearn - V1");
            });
        }
    }
}
