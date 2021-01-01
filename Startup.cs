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
            // Adiciona uma instância transitória(temporária), toda vez que o GetService for chamado o mecanismo de injeção de dependência
            vai criar uma nova instância da classe Catalogo pois está como Transient
            * services.AddTransient<ICatalogo, Catalogo>();
            * services.AddTransient<IRelatorio, Relatorio>();
            /*
             * AddScoped
             * A cada requisição que houver no navegador, Vai ter uma instância do service dentro da mesma requisição
             * services.AddScoped<ICatalogo, Catalogo>();
             * services.AddScoped<IRelatorio, Relatorio>();
            */
            /*
             * É uma instância única que vai existir em toda aplicação, enquanto a aplicação estiver rodando vai ser sempre a mesma instância,
             * independente da requisição
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
