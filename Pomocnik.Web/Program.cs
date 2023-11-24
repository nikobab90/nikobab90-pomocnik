using Pomocnik.BAL;
using Pomocnik.DAL;
using Pomocnik.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IspitivanjeService>();
builder.Services.AddSingleton<IspitivanjeRepo>();

builder.Services.AddSingleton<ServisiranjeService>();
builder.Services.AddSingleton<ServisiranjeRepo>();

builder.Services.AddSingleton<KlijentiService>();
builder.Services.AddSingleton<KlijentiRepo>();

builder.Services.AddSingleton<ZaposleniciService>();
builder.Services.AddSingleton<ZaposleniciRepo>();
/*
builder.Services.AddSingleton<DokumentiService>();
builder.Services.AddSingleton<DokumentiRepo>();
*/

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