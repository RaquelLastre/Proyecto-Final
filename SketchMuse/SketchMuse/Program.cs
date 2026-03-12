using SketchMuse.Application.Interfaces;
using SketchMuse.Infrastructure.ExternalApis;

var builder = WebApplication.CreateBuilder(args);

//inserta en el constructor el HttpClient. IConfiguration ya está añadido entre otras cosas al poner la linea anterior
builder.Services.AddHttpClient<BingImageService>();
//Scoped define cuanto vive el objeto (transient: nuevo cada vez, scoped: nuevo en cada peticion HTTP, singleton: unico), es el que se suele usar en APIs
builder.Services.AddScoped<IImagenesService, ImagenesService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
