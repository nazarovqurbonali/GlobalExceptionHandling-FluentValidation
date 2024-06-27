using Crud.Base.Extensions.CustomMiddlewares;
using Crud.Student.V1.Service;
using Crud.Student.V1.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Base.Extensions.Infrastructure;

public static class InfrastructureExtensions
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
     
        
        //register exception handler
        builder.Services.AddProblemDetails();
        
        //connection database
        
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings:Connection").Value);
        });
        builder.Services.AddScoped<IStudentService, StudentService>();
        
        //register validators 
        builder.Services.AddValidatorsFromAssemblyContaining<CreateStudentValidator>();
        
        
        return builder;
    }


    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseCustomProblemDetails();
        return app;
    }
}