using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Authentication;
using To_Do_List_API.Interfaces;
using To_Do_List_API.Persistence;
using To_Do_List_API.Persistence.Repositories;
using To_Do_List_API.Services;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("toDoListDb"));
    });

    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddScoped<IToDoItemsService, ToDoItemsService>();
    builder.Services.AddScoped<IToDoItemsRepository, ToDoItemsRepository>();

    builder.Services.AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
}



// Configure the HTTP request pipeline.
var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
