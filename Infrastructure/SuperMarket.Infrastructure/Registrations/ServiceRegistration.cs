using Microsoft.Extensions.DependencyInjection;
using SuperMarket.Application.Interfaces.ITokenHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Infrastructure.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services) 
        { 
            services.AddScoped<ITokenHandler, Implementations.Services.TokenHandler>();
        }
    }
}
