using BugTracker.BLL;
using BugTracker.DAL;
using BugTracker.DAL.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.RegisterBLLDependencies(builder.Configuration);
services.RegisterDALDependencies(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-8.0&tabs=visual-studio
using (var scope = app.Services.CreateScope())
{
    var providerServices = scope.ServiceProvider;

    var context = providerServices.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("_myAllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();