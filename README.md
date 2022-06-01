# Data Center Location Carbon Tracker

## Background
Most of cloud providers or on-premise data centers are providing carbon footprint of their services within their data centers. However, to make a decision holistically, carbon footprint within data centers are not sufficient, considering the overall constraints on green energy sources. What is the missing is the energy sources and carbon tracking across the electricity generation grid. This repo combines the date input from given data center locations (e.g. Azure data centers or on-prem), emission data index and electricity grid boundaries (e.g. [WattTime](https://www.watttime.org/)) to give a holistic view of carbon footprint in a data center location. The combined data set can be further processed and visualized to reveal more insights, and give guidance to our engineering teams. One example is to host with a map service. (e.g. Azure Map Service)

## Measurements

**Grid Emission Factor** refers to CO2 emission factor (tCO2/MWh) which will be associated with each unit of electricity provided by an electricity system.​

**Marginal Operating Emissions Rate (MOER)** is a measurement in units of pounds of emissions per megawatt-hour (e.g. CO2 lbs/MWh), allowing to compare how marginal emissions rates vary by time and place by accurate marginal emissions analysis.

## Input Data
### MOER Data from WattTime API
One example to get MOER data in realtime is to use [WattTime API](https://www.watttime.org/api-documentation/#introduction)
This repo provides a .net core library to retrieve MOER real-time, historical, and forecast data, given a region or a lat/lon.

**Step 1. Register an account** `public async Task<string> Register(User user)`

An example app can be found in **RegisterExample** folder.

**Step 2. Log in the account** `public async Task<string> Login(string username, string password)`
A token (valid for 30 minutes) will be returned after logged in. 

**Step 3. Check which regions are available with your valid license** 
```
var regions = await wattTimeConnector.GetRegions(token);
```

**Step 4. Retrieve emission data** with the token retrieved from step 2
```
public async Task<string> GetRealTimeData(string token, Region region)
public async Task<Stream?> GetHistoryData(string token, string ba)
public async Task<string> GetForecastData(string token, string ba)
```

### Data Center Locations
##### Azure Data Centers
1. Azure Data Center locations can be retrieved via Azure CLI cmd: 
```
az account list-locations
```
2. Convert the exported json file to GeoJson file using *AzureDataCenterConverter.ConvertToGeoJson* function.

#### On-premise Data Centers
Given the pre-known locations (lat/lon), create the GeoJson file using *GeoJSON.Net.Geometry* and *GeoJSON.Net.Feature* objects.

### Map Service
#### Azure Maps
You can follow the [Azure Maps document](https://docs.microsoft.com/en-us/azure/azure-maps/) to create a map service. You can also refer to https://github.com/Azure-Samples/AzureMapsCodeSamples to get more examples.

## Example Visualization

![image](https://user-images.githubusercontent.com/62902203/170833157-df33e8d9-a241-4bbc-bdc5-f4b270c5f332.png)

