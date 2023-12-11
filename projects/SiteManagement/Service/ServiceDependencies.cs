using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.BusinessRules;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IApartmentService,ApartmentService>();
        services.AddScoped<IBlockService,BlockService>();

        services.AddScoped<ApartmentRules>();
        services.AddScoped<BlockRules>();

        return services;
    }
}
