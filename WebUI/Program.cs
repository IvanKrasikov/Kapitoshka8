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
        _db.Add(new Node("���������� ������", 0, 0));
        _db.Add(new Node("������", 5, 1));
        _db.Add(new Node("�������� �����", 0, 1));
        _db.Add(new Node("��������", 6, 3));
        _db.Add(new Node("��������������", 4, 3));
        _db.Add(new Node("�����������", 7, 1));
        _db.Add(new Node("���������� ������"));
        _db.Add(new Node("��������������� ���������", 0, 7));
        _db.Add(new Node("��������", 0, 8));
        _db.Add(new Node("�����", 3, 9));
        _db.Add(new Node("�����", 2, 9));
        _db.Add(new Node("�������", 4, 8));
        _db.Add(new Node("����������", 0, 7));
        _db.Add(new Node("������", 1, 13));
        _db.Add(new Node("�����", 1, 13));
        _db.Add(new Node("����������� ������"));
        _db.Add(new Node("�������������", 0, 16));
        _db.Add(new Node("LEGO Mindstorms", 6, 17));
        _db.Add(new Node("Arduino", 2, 17));
        _db.Add(new Node("�������������", 5, 16));
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
