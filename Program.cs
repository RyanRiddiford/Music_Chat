using Amazon;
using Amazon.RDS;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;

//using Microsoft
using music_chat.Models;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure AWS services
var awsBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var options = awsBuilder.Build().GetAWSOptions();
var s3client = options.CreateServiceClient<IAmazonS3>();
var rdsClient = options.CreateServiceClient<IAmazonRDS>();
AWSConfigs.UseSdkCache = false;

//DI singleton services for HTTP requests and AWS services
builder.Services.AddSingleton<IAmazonS3>(s3client);
builder.Services.AddSingleton<IAmazonRDS>(rdsClient);
builder.Services.AddHttpClient("api", client =>
{
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpg"));
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
});

//Add and configure session
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("Host=database-1.cfakbm3e1xh9.us-east-1.rds.amazonaws.com;Port=5432;Username=postgres;Password=password123;Database=database_1;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Auth}/{action=Login}/{id?}");
app.Run();