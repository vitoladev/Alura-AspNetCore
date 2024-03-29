using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aluraaspnetcore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*****************************
             * AddTransient
            // Adiciona uma inst�ncia transit�ria(tempor�ria), toda vez que o GetService for chamado o mecanismo de inje��o de depend�ncia
            vai criar uma nova inst�ncia da classe Catalogo pois est� como Transient
            * services.AddTransient<ICatalogo, Catalogo>();
            * services.AddTransient<IRelatorio, Relatorio>();
            /*
             * AddScoped
             * A cada requisi��o que houver no navegador, Vai ter uma inst�ncia do service dentro da mesma requisi��o
             * services.AddScoped<ICatalogo, Catalogo>();
             * services.AddScoped<IRelatorio, Relatorio>();
            */
            /*
             * � uma inst�ncia �nica que vai existir em toda aplica��o, enquanto a aplica��o estiver rodando vai ser sempre a mesma inst�ncia,
             * independente da requisi��o
            */
            var catalogo = new Catalogo();
            services.AddSingleton<ICatalogo>(catalogo);
            services.AddSingleton<IRelatorio>(new Relatorio(catalogo));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await relatorio.Print(context);
                });
            });
        }
    }
}
