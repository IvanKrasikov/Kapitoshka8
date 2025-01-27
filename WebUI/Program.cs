using BusinessLogic;
using Domain.Entities.Nodes;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(NodeDb).Assembly));
builder.Services.AddScoped<INodeDb, NodeDb>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var _db = services.GetRequiredService<INodeDb>();

    if (_db.IsNull())
    {
        _db.Add(new Node("Спортивные секции", 0, 0));
        _db.Add(new Node("Футбол", 5, 1));
        _db.Add(new Node("Цирковая школа", 0, 1));
        _db.Add(new Node("Клоунада", 6, 3));
        _db.Add(new Node("Эквилибристика", 4, 3));
        _db.Add(new Node("Иппотерапия", 7, 1));
        _db.Add(new Node("Творческие студии"));
        _db.Add(new Node("Изобразительное искусство", 0, 7));
        _db.Add(new Node("Живопись", 0, 8));
        _db.Add(new Node("Гуашь", 3, 9));
        _db.Add(new Node("Масло", 2, 9));
        _db.Add(new Node("Графика", 4, 8));
        _db.Add(new Node("Литература", 0, 7));
        _db.Add(new Node("Поэзия", 1, 13));
        _db.Add(new Node("Проза", 1, 13));
        _db.Add(new Node("Технические кружки"));
        _db.Add(new Node("Робототехника", 0, 16));
        _db.Add(new Node("LEGO Mindstorms", 6, 17));
        _db.Add(new Node("Arduino", 2, 17));
        _db.Add(new Node("Моделирование", 5, 16));
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
