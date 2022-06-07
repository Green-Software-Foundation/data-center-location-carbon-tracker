// See https://aka.ms/new-console-template for more information

using GeoJSONConverter;
using WattTime;

var wattTimeConnector = new WattTimeConnector();
var username = args[0];
var password = args[1];
var dataFolder = args[2];

var token = await wattTimeConnector.Login(username, password);



if (!string.IsNullOrEmpty(dataFolder) && !Directory.Exists(dataFolder))
{
    Directory.CreateDirectory(dataFolder);
}
var regions = await wattTimeConnector.GetRegions(token);
var realtimeData = new Dictionary<string, double>();
using (var writer = new StreamWriter(Path.Combine(dataFolder, "emission.csv")))
{
    foreach (var region in regions)
    {
        Console.WriteLine(region);
        //get real time data
        var data = await wattTimeConnector.GetRealTimeData(token, region);
        Console.WriteLine(data);
        writer.WriteLine(data.CSVString());
        realtimeData[region.RegionCode] = data.MOER;
    }
}

var gridMap = await wattTimeConnector.GetMap(token);
StreamReader reader = new StreamReader(gridMap);
var moerWithGrid = MOERDataMerger.Merge(reader.ReadToEnd(), realtimeData);

using (var writer = new StreamWriter(Path.Combine(dataFolder, "map_with_moer.json")))
{
    writer.Write(moerWithGrid);
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

