using SignalRDemoProject.Business;
using SignalRDemoProject.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
                                policy.AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials()
                                .SetIsOriginAllowed(origin => true)
                                ));

builder.Services.AddTransient<MyBusiness>();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
//https://localhost:7069/myhub
app.MapHub<MyHub>("/myhub");
app.MapHub<MessageHub>("/messagehub");
app.Run();
