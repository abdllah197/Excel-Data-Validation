using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IExcelSheetService, ExcelSheetService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
