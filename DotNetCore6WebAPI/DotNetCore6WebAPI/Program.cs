using DomainLayer.Interfaces;
using DotNetCore6WebAPI.Services;
using Infrastructure.Repositories;
using Raven.Client.Documents;

var builder = WebApplication.CreateBuilder(args);


//curl "http://127.0.0.1:50071/databases"
//curl -X PUT "http://127.0.0.1:50071/admin/databases" -H "Content-Type: application/json" -d "{\"DatabaseName\": \"RavenData\", \"Settings\": {}, \"ReplicationFactor\": 1}"

var documentStore = new DocumentStore
{
    Urls = new[] { "http://127.0.0.1:50071" }, // Replace with your RavenDB server URL
    Database = "RavenData"              // Replace with your database name
};
documentStore.Initialize();

// Register DocumentStore in the DI container
builder.Services.AddSingleton<IDocumentStore>(documentStore);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200") // Your Angular app's URL
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.Run();


