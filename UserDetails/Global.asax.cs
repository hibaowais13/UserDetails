using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UserDetails.Models;
using AutoMapper;

namespace UserDetails
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.Configure();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        public static class AutoMapperConfiguration
        {
            public static void Configure()
            {
            
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Role, RoleDetails>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new Role();
                var dest = mapper.Map<Role, RoleDetails>(source);


            }




        }
    }

        
    
}
