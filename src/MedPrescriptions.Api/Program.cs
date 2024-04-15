using Prescriptions.Application;
using Prescriptions.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddEndpointsApiExplorer();

services.AddControllers(opt =>
{

});

services.AddApplication();
services.AddPersistence(opt =>
{
  opt.UseSqlite("Data Source=test.db");
});
services.AddSwaggerGen();

services.AddAuthentication("Bearer")
    .AddJwtBearer();
services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI(swaggerUiOptions => 
    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "EventReminder API"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
