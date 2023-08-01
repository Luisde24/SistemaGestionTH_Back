using Microsoft.OpenApi.Models;
using SistemaGestionTH.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);



//Se configura la BD y las interfaces
builder.Services.AddInfrastructure(builder.Configuration);

//Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


//JWT
builder.Services.AddInfrastructureJWT(builder.Configuration);

//Swagger
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaGestionTH.API v1"));
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseCors("AllowSpecificOrigins");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
