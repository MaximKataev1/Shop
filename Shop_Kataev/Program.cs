using Shop_Kataev.Data.DataBase;
using Shop_Kataev.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICategories, DBCategory>();
builder.Services.AddTransient<IItems, DBItems>();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();
