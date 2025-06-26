var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure logging to be verbose

builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Console (visível no Log Stream se configurado)
builder.Logging.AddDebug();   // Opcional (útil localmente)
builder.Logging.AddAzureWebAppDiagnostics(); // <- ESSENCIAL no Azure
builder.Logging.SetMinimumLevel(LogLevel.Trace);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
