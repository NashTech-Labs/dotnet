using CrudApiWithMongoDB.Models;
using CrudApiWithMongoDB.Service;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<IMongoDatabase>(options=>{
var mongoSettings=builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
var client=new MongoClient(mongoSettings.ConnectionString);
return client.GetDatabase(mongoSettings.DatabaseName);

});
builder.Services.AddSingleton<IPersonService,PersonService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
