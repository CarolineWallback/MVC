var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=About}/{id?}");
app.MapControllerRoute(
    name: "doctor",
    pattern: "doctor",
    defaults: new { controller = "Doctor", action = "FeverCheck" });


app.Run();
