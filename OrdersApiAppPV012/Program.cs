using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;
using OrdersApiAppPV012.Service.ClientService;
using OrdersApiAppPV012.Service.OrderService;

var builder = WebApplication.CreateBuilder(args);

// добавление зависимостей
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder,DbDaoOrder>();  

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// тестирование операций с таблицей клиента

app.MapGet("/clients/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.AddClient(client);
});
app.MapGet("/orders/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAllOrder();
});

app.MapPost("/orders/add", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.AddOrder(order);
});


app.Run();
