using SimpleCart.Infrastructure.Ioc;
using SimpleCart.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSpaStaticFiles(options => options.RootPath = "ClientApplication/dist");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseSpaStaticFiles();
app.UseSpa(spa =>
{
    spa.Options.SourcePath = NuxtIntegration.SpaSource;
    if (builder.Environment.IsDevelopment())
    {
        // Launch development server for Nuxt
        spa.UseNuxtDevelopmentServer();
    }
});;

app.Run();