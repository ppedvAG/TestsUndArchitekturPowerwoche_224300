// See https://aka.ms/new-console-template for more information
using HalloDekorator;

Console.WriteLine("Hello, World!");

IComponent brot1 = new Käse( new Käse(new Salami(new Brot())));

Console.WriteLine($"{brot1.Beschreibung} {brot1.Preis:c}");

IComponent pizza = new Käse(new Salami(new Käse(new Pizza())));

Console.WriteLine($"{pizza.Beschreibung} {pizza.Preis:c}");

