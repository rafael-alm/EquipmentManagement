﻿using equipmentManagement.Api.Output.Filters;

namespace equipmentManagement.Api.Output.Configurations;

public static class ControllersConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllers(options
                => options.Filters.Add(typeof(ApiGlobalExceptionFilter))
            );
        services.AddDocumentation();
        return services;
    }

    private static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }
}
