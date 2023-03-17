using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;
using OrdersApiAppPV012.Service;
using OrdersApiAppPV012.Service.ClientService;
using OrdersApiAppPV012.Service.OrderProductService;
using OrdersApiAppPV012.Service.OrderService;
using OrdersApiAppPV012.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������������
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDao<Client>, DbDaoClient>();
builder.Services.AddTransient<IDao<Order>,DbDaoOrder>();
builder.Services.AddTransient<IDao<Product>, DbDaoProduct>();
builder.Services.AddTransient<IDao<OrderProduct>, DbDaoOrderProduct>();


var app = builder.Build();


app.MapGet("/", () => "������ World!");

// ������������ �������� � �������� �������

app.MapGet("/client/all", async (HttpContext context, IDao<Client> dao) =>
{
    return await dao.GetAll();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDao<Client> dao) =>
{
    return await dao.Add(client);
});
app.MapGet("/client/get", async (HttpContext context, IDao<Client> dao, int id) =>
{
    return await dao.GetById(id);
});
app.MapPost("/client/update", async (HttpContext context, Client client, IDao<Client> dao) =>
{
    return await dao.Update(client);
});
app.MapPost("/client/delete", async (HttpContext context, IDao<Client> dao, int id) =>
{
    return await dao.Delete(id);
});




//������ 
app.MapGet("/order/all", async (HttpContext context, IDao<Order> dao) =>
{
    return await dao.GetAll();
});

app.MapPost("/order/add", async (HttpContext context, Order order, IDao<Order> dao) =>
{
    return await dao.Add(order);
});


app.Run();
