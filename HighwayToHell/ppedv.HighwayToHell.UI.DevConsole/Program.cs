using ppedv.HighwayToHell.Logic.OrderService;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

Console.WriteLine("*** HighwayToHell v0.1 ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=HightwayToHell_dev;Trusted_Connection=true;";
IRepository repo = new ppedv.HighwayToHell.Data.EfCore.EfRepository(conString);
OrderManager om = new OrderManager(repo);

int bestMonth = om.GetBestSellingMonth();
Console.WriteLine($"Best Month: {new DateTime(1, bestMonth, 1):MMMM}");

Console.WriteLine("--- CARS ---");
foreach (var car in repo.GetAll<Car>())
{
    Console.WriteLine($"{car.Manufacturer?.Name} {car.Model}");
}
Console.WriteLine("--- ORDERS ---");
foreach (var order in repo.GetAll<Order>())
{
    Console.WriteLine($"{order.OrderDate} pay:{order.BillingCustomer?.Name} deliver to:{order.DeliveryCustomer?.Name}");
    foreach (var item in order.Items)
    {
        Console.WriteLine($"\t{item.Amount}x {item.Car?.Manufacturer?.Name} {item.Car?.Model} {item.Color}");
    }
}




