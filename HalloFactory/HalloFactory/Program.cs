// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data.Common;

Console.WriteLine("Hello, World!");

//DbProviderFactory factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
DbProviderFactory factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;

ShowUsers(factory);
 
void ShowUsers(DbProviderFactory factory)
{
    DbConnection con = factory.CreateConnection();

    //SqlConnection conSqlServer = new SqlConnection();
    //SqliteConnection conSqlite= new SqliteConnection();
    con.ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
    con.Open();

    var cmd = factory.CreateCommand();
    cmd.Connection = con;
    cmd.CommandText = "SELECT * FROM Employees;";

    var reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine(reader.GetString(2));
    }
}