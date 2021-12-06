namespace Lottotry.WebApi.Extensions.Services
{
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;

    public static class SwaggerServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Lottory Service Microservice",
                        Description = "Lottotry is a unique web (online) based lottery analysis, prediction, guess and rich statistics software tools.",
                        Contact = new OpenApiContact
                        {
                            Name = "Lottotru Support Team",
                            Email = "info@lottotry.com",
                            Url = new Uri("http://www.lottotry.com"),
                        },
                    });

                config.IncludeXmlComments(string.Format(@$"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}Lottotry.WebApi.WebApi.xml"));
            });
        }
    }
}
