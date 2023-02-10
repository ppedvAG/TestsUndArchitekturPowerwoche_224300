using Autofac;
using ppedv.HighwayToHell.Data.EfCore;
using ppedv.HighwayToHell.Logic.OrderService;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;
using System.Reflection;

Console.WriteLine("*** HighwayToHell v0.1 ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=HightwayToHell_dev;Trusted_Connection=true;";

//DI per Reflection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\TestsUndArchitekturPowerwoche_224300\HighwayToHell\ppedv.HighwayToHell.Data.EfCore\bin\Debug\net6.0\ppedv.HighwayToHell.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = Activator.CreateInstance(typeMitRepo, conString) as IRepository;

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfUnitOfWork>().WithParameter("conString", conString).As<IUnitOfWork>();
builder.RegisterType<OrderManager>().As<IOrderManager>();
var container = builder.Build();

IOrderManager om = container.Resolve<IOrderManager>();
IUnitOfWork uow = container.Resolve<IUnitOfWork>();

//DI Manuell 
//IRepository repo = new ppedv.HighwayToHell.Data.EfCore.EfRepository(conString);
//OrderManager om = new OrderManager(repo);

int bestMonth = om.GetBestSellingMonth();
Console.WriteLine($"Best Month: {new DateTime(1, bestMonth, 1):MMMM}");

Console.WriteLine("--- CARS ---");
foreach (var car in uow.GetRepo<Car>().GetAll())
{
    Console.WriteLine($"{car.Manufacturer?.Name} {car.Model}");
}

Console.WriteLine("--- ORDERS ---");
foreach (var order in uow.GetRepo<Order>().GetAll())
{
    Console.WriteLine($"{order.OrderDate} pay:{order.BillingCustomer?.Name} deliver to:{order.DeliveryCustomer?.Name}");
    foreach (var item in order.Items)
    {
        Console.WriteLine($"\t{item.Amount}x {item.Car?.Manufacturer?.Name} {item.Car?.Model} {item.Color}");
    }
}




