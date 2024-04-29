using FluentValidation;
using FluentValidation.AspNetCore;
using ValidationAutomapperHomework.AutoMapperProfiles;
using ValidationAutomapperHomework.Models;
using ValidationAutomapperHomework.View_Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<LoginViewModel>();
builder.Services.AddDbContext<UsersDBContext>();
builder.Services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Users}/{action=Index}");

app.Run();
