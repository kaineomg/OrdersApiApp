using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;
using OrdersApiAppPV012.Service;
using OrdersApiAppPV012.Service.ClientService;
using OrdersApiAppPV012.Service.OrderProductService;
using OrdersApiAppPV012.Service.OrderService;
using OrdersApiAppPV012.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

// добавление зависимостей
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDao<Client>, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder,DbDaoOrder>();
builder.Services.AddTransient<IDao<Product>, DbDaoProduct>();
builder.Services.AddTransient<IDao<OrderProduct>, DbDaoOrderProduct>();


var app = builder.Build();


app.MapGet("/", () => "Orders API");

// тестирование операций с таблицей clients

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




//orders 
app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAll();
});

app.MapPost("/order/add", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.Add(order);
});

app.MapGet("/order/get", async (HttpContext context, IDaoOrder dao, int id) =>
{
    return await dao.GetById(id);
});
app.MapPost("/order/update", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.Update(order);
});
app.MapPost("/order/delete", async (HttpContext context, IDaoOrder dao, int id) =>
{
    return await dao.Delete(id);
});




// products
app.MapGet("/product/all", async (HttpContext context, IDao<Product> dao) =>
{
    return await dao.GetAll();
});

app.MapPost("/product/add", async (HttpContext context, Product product, IDao<Product> dao) =>
{
    return await dao.Add(product);
});
app.MapGet("/product/get", async (HttpContext context, IDao<Product> dao, int id) =>
{
    return await dao.GetById(id);
});
app.MapPost("/product/update", async (HttpContext context, Product product, IDao<Product> dao) =>
{
    return await dao.Update(product);
});
app.MapPost("/product/delete", async (HttpContext context, IDao<Product> dao, int id) =>
{
    return await dao.Delete(id);
});





//OrderProduct

app.MapGet("/orderproduct/all", async (HttpContext context, IDao<OrderProduct> dao) =>
{
    return await dao.GetAll();
});

app.MapPost("/orderproduct/add", async (HttpContext context, OrderProduct orderPr, IDao<OrderProduct> dao) =>
{
    return await dao.Add(orderPr);
});
app.MapGet("/orderproduct/get", async (HttpContext context, IDao<OrderProduct> dao, int id) =>
{
    return await dao.GetById(id);
});
app.MapPost("/orderproduct/update", async (HttpContext context, OrderProduct orderPr, IDao<OrderProduct> dao) =>
{
    return await dao.Update(orderPr);
});
app.MapPost("/orderproduct/delete", async (HttpContext context, IDao<OrderProduct> dao, int id) =>
{
    return await dao.Delete(id);
});






//Check
app.MapGet("/check", async (HttpContext context, IDaoOrder dao, int orderId) =>
{
    Order order = await dao.GetFullOrderById(orderId);

     return new
    {
         Products = order.OrderProducts.Select(OP => OP.Product),
         CheckPrice = order.OrderProducts.Sum(OP => OP.Count * OP.Product.Price)
    };
});




app.Run();
