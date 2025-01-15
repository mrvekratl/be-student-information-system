var builder = WebApplication.CreateBuilder(args);

// CORS ayarlarýný ekleyin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("file:///C:/Users/Monster/Desktop/BE124/G%C3%96REV_6/TESL%C4%B0M/Ogrenci-Bilgi-Sistemi/Frontend/Index-OBS.html") // Buraya izin verilen frontend adresini ekleyin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
