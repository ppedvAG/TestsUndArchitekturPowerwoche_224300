// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");

var schrank1 = new Schrank.Builder()
                         .SetObfläche(Oberfläche.Lackiert)
                         .SetFarbe("Gelb")
                         .SetBöden(6)
                         .SetTüren(5)
                         .Create();


var schrank2 = new Schrank.Builder()
                         .SetObfläche(Oberfläche.Gewachst)
                         .SetBöden(6)
                         .SetTüren(5)
                         .Create();