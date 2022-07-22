global using Microsoft.EntityFrameworkCore;
global using ToDoAppApi.Model;
global using ToDoAppApi.Services.Todos;
global using ToDoAppApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodosDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("TodosDatabase"));
});

builder.Services.AddTransient<ITodosService, TodosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Shows UseCors with CorsPolicyBuilder
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
