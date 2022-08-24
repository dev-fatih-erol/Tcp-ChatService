// TCP server address
using ChatService.Client.Clients;
using ChatService.Client.Extensions;
using ChatService.Client.Helpers;
using ChatService.Client.Services;

string address = "127.0.0.1";
if (args.Length > 0)
    address = args[0];

// TCP server port
int port = 1111;
if (args.Length > 1)
    port = int.Parse(args[1]);

Console.WriteLine($"TCP server address: {address}");
Console.WriteLine($"TCP server port: {port}");
Console.WriteLine();

// Create a new TCP chat client
var client = new ChatClient(address, port);

// Connect the client
Console.Write("Client connecting...");
client.ConnectAsync();
Console.WriteLine("Done!");
Console.WriteLine("Press Enter to stop the client or '!' to reconnect the client...");

// Perform text input
for (;;)
{
    string line = Console.ReadLine();
    if (string.IsNullOrEmpty(line))
        continue;

    ConsoleHelper.ClearConsoleLine();

    // Disconnect the client
    if (line == "!")
    {
        Console.Write("Client disconnecting...");
        client.DisconnectAsync();
        Console.WriteLine("Done!");
        continue;
    }

    // Get user data
    var user = UserService.Get(client.Id);
    var currentDate = DateTime.Now;
    var elapsedTime = currentDate.ToElapsedTime(user.LastMessageDate);
    // Check if elapsed time is less than 1 second
    if (elapsedTime < 1)
    {
        if (user.Counter == 1)
        {
            // if repeated, it will break the connection
            client.DisconnectAndStop();
        }
        else
        {
            // Send a warning message
            user.Counter++;
            Console.Write("You send messages too often. If repeated, you will be disconnected");
        }
    }

    // Update the user data with the new one
    user.LastMessageDate = currentDate;
    UserService.Replace(user);

    // Send the entered text to the chat server
    client.SendAsync(line);
}

// Disconnect the client
Console.Write("Client disconnecting...");
client.DisconnectAndStop();
Console.WriteLine("Done!");