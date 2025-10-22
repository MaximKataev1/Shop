using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICategories, MockCaregorys>();
builder.Services.AddTransient<IItems, MockItems>();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();
