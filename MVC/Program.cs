var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=About}/{id?}");
app.MapControllerRoute(
    name: "doctor",
    pattern: "doctor",
    defaults: new { controller = "Doctor", action = "FeverCheck" });

app.MapControllerRoute(
    name: "game",
    pattern: "game",
    defaults: new { controller = "GuessingGame", action = "GuessingGame" });


app.Run();
