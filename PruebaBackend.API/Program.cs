using Microsoft.EntityFrameworkCore;
using PruebaBackend.API.Data;
using DbContext = PruebaBackend.API.Data.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Configuramos la conexion de la bd postgres

builder.Services.AddControllers();
builder.Services.AddDbContext<DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Aqui aplico las migraciones aplicando el scope para la migracion
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
    // Aplicamos las migraciones
    dbContext.Database.Migrate(); 
}

// Esto lo use para evitar cualquier restriccion por el puerto y la ip local
app.Urls.Add("http://0.0.0.0:80");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.

// Como estamos en local comento esto para evitar cualquier fallo
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
