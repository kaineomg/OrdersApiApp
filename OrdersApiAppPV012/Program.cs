using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;
using OrdersApiAppPV012.Service.ClientService;
using OrdersApiAppPV012.Service.OrderProductService;
using OrdersApiAppPV012.Service.OrderService;
using OrdersApiAppPV012.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

// добавление зависимостей
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder,DbDaoOrder>();
builder.Services.AddTransient<IDaoProduct, DbDaoProduct>();
builder.Services.AddTransient<IDaoOrderProduct, DbDaoOrderProduct>();


var app = builder.Build();


app.MapGet("/", () => "Привет World!");

// тестирование операций с таблицей клиента

app.MapGet("/client/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.AddClient(client);
});
app.MapGet("/client/get", async (HttpContext context, IDaoClient dao, int id) =>
{
    return await dao.GetClientById(id);
});
app.MapPost("/client/update", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.UpdateClient(client);
});
app.MapPost("/client/delete", async (HttpContext context, IDaoClient dao, int id) =>
{
    return await dao.DeleteClient(id);
});




//ордеры 
app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAllOrders();
});

app.MapPost("/order/add", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.AddOrder(order);
});


app.Run();
