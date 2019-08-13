using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace MarvelComicsLibrary.Application.Extensions
{
    public static class SwaggerMiddleware
    {
        public static void ConfigSwaggerApp(this IApplicationBuilder app)
        {
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Marvel Comics Library API");
            });
        }

        public static void ConfigSwaggerDoc(this IServiceCollection services)
        {
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API - Marvel Comics Library",
                        Version = "v1",
                        Description = "Marvel Comics Library",
                        Contact = new Contact
                        {
                            Name = "Claudio Parra",
                            Url = "https://github.com/parraclaudio/MarvelComicsLibrary"
                        }
                    });

                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }
    }
}
