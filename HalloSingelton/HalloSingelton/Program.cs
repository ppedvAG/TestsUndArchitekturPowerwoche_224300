// See https://aka.ms/new-console-template for more information
using HalloSingelton;

Console.WriteLine("Hello, World!");

for (int i = 0; i < 20; i++)
{
    Task.Run(() => Logger.Instance.Log($"Hallo Logger {i:00}"));
}

Logger.Instance.Log("Hallo Logger");