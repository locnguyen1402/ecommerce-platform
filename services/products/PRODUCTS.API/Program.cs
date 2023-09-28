var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()!;
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigController();

builder.Services
    .AddAutoMapper()
    .AddValidation();

builder.Services.RegisterOLRestClient(appSettings.Integration.OpenLibrary.RestClients.BaseUrl);
// builder.Services.RegisterOLRestClient("https://openlibrary.org");

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
