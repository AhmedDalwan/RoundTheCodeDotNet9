using System.Net;
using RoundTheCodeDotNet9.Interfaces;
using RoundTheCodeDotNet9.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddKeyedSingleton<IMyService, MySingletonService>("singleton");
builder.Services.AddKeyedScoped<IMyService, MyScopedService>("scoped");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


// Before
//var theResult = Results.InternalServerError("It's broken");
//app.MapGet("/server-error", () => theResult);

// After
var theResult = TypedResults.InternalServerError("It's broken");
app.MapGet("/server-error", () => theResult);

var product = app.MapGroup("/product")
.ProducesProblem((int)HttpStatusCode.InternalServerError)
.ProducesValidationProblem((int)HttpStatusCode.BadRequest);

product.MapGet("/", () => true);

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
