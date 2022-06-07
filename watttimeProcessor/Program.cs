// See https://aka.ms/new-console-template for more information
using WattTime;

var wattTimeConnector = new WattTimeConnector();
var username = args[0];
var password = args[1];
var dataFolder = args[2];

var token = await wattTimeConnector.Login(username, password);


var regions = await wattTimeConnector.GetRegions(token);
using (var writer = new StreamWriter(Path.Combine(dataFolder, "emission.csv")))
{
    foreach (var region in regions)
    {
        Console.WriteLine(region);
        //get real time data
        var data = await wattTimeConnector.GetRealTimeData(token, region);
        Console.WriteLine(data);
        writer.WriteLine(data.CSVString());

        
    }
}

using (var writer = new StreamWriter(Path.Combine(dataFolder, "emission_forecast.csv")))
{
    writer.WriteLine(EmissionData.CSVHeader);
    foreach (var region in regions)
    {
        var forecastData = await wattTimeConnector.GetForecastData(token, region.RegionCode);
        
        foreach(var item in forecastData.Forecast)
        {
            Console.WriteLine(item.ToString());
            writer.WriteLine(item.ToCSVString());
        }
    }
}

