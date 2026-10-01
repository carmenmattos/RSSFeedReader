using Microsoft.Extensions.FileProviders;
using RSSFeedReader.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SubscriptionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClientPolicy", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

var sourceRoot = Path.Combine(app.Environment.ContentRootPath, "..", "..", "frontend", "RSSFeedReader.UI", "wwwroot");
var frameworkRoot = Path.Combine(app.Environment.ContentRootPath, "..", "..", "frontend", "RSSFeedReader.UI", "bin", "Debug", "net8.0", "wwwroot", "_framework");

if (Directory.Exists(sourceRoot))
{
    var sourceFileProvider = new PhysicalFileProvider(sourceRoot);

    app.UseDefaultFiles(new DefaultFilesOptions
    {
        FileProvider = sourceFileProvider,
        RequestPath = ""
    });

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = sourceFileProvider,
        RequestPath = ""
    });

    app.MapFallbackToFile("index.html", new StaticFileOptions { FileProvider = sourceFileProvider });
}

if (Directory.Exists(frameworkRoot))
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(frameworkRoot),
        RequestPath = "/_framework"
    });
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BlazorClientPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
