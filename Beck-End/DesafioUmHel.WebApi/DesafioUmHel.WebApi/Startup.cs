using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Senai.Senatur.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Mudar vers�o URGENTE!!!!
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Configura��es swagger (melhor entendimento dos endpoints controllers) documenta��o
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                //Adiciona os coment�rios (summary) do controller
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //*
            //Configurando o JWT (Autentifica��o)
            //*
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Verificando...

                    //Quem esta solicitando
                    ValidateIssuer = true,

                    //Quem esta recebendo
                    ValidateAudience = true,

                    //Valida o tempo de expira��o do token
                    ValidateLifetime = true,

                    //Forma da criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autenticacao")),

                    //Tempo de expira��o do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    // Nome da issuer, de onde est� vindo
                    ValidIssuer = "Senai.Senatur.WebApi",

                    // Nome da audience, de onde est� vindo
                    ValidAudience = "Senai.Senatur.WebApi"
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai.Senatur.WebApi");
            });

            // Habilita o uso de autentica��o
            app.UseAuthentication();

            // Habilita o uso de mvc
            app.UseMvc();
        }
    }
}
