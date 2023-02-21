using System.Reflection;
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ServicesConfiguration
{
       public static IServiceCollection AddApplication (this IServiceCollection services)
       {
              services.AddAutoMapper(Assembly.GetExecutingAssembly());
              services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
              services.AddMediatR(Assembly.GetExecutingAssembly());
              services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

              return services;
       }
}
