using System.Web.Http;
using WebActivatorEx;
using Montreal.NomeSistema.Services;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Montreal.NomeSistema.Services
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Produtos");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi();
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}App_Data\Montreal.NomeSistema.Services.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
