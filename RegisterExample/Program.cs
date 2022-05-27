// See https://aka.ms/new-console-template for more information
using WattTime;

var wattTimeConnector = new WattTimeConnector();


var result = await wattTimeConnector.Register(new User { UserName = args[0], Password = args[1],
    Email = args[2], Organization = args[3] });

Console.WriteLine(result);
Console.WriteLine("Please enter any key to exit...");
Console.ReadLine();
