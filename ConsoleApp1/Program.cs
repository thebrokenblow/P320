using Microsoft.Data.SqlClient;

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine($"ID подключения: {connection.ClientConnectionId}");
}

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine($"ID подключения: {connection.ClientConnectionId}");
}