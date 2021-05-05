using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi_G_Map.Helpers
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
            => _provider = provider;

        public void Configure(SwaggerGenOptions c)
        {

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                c.SwaggerDoc(description.GroupName,
                new OpenApiInfo
                {
                    Title = "WebApi_G_Map",
                    Version = description.ApiVersion.ToString()
                });
            }

        }
    }
}
