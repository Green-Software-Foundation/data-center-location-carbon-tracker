# Data Center Location Carbon Tracker

This project has been moved to dormant state as per our [Project Lifecycle document](https://github.com/Green-Software-Foundation/oc/blob/main/project-lifecycle.md#dormant). 

## Background
Today, if we as software engineers want to deploy our applications to a data center, we want to know how clean that energy source is. Most of cloud providers or on-premise data centers are providing carbon footprint of their services within their data centers. However, to make a decision holistically, carbon footprint within data centers are not sufficient, considering the overall constraints on green energy sources. What is the missing is the energy sources and carbon tracking across the electricity generation grid. This repo combines the date input from given data center locations (e.g. Azure data centers or on-prem), emission data index and electricity grid boundaries (e.g. [WattTime](https://www.watttime.org/)) to give a holistic view of carbon footprint in a data center location. The combined data set can be further processed and visualized to reveal more insights. This repo is aiming to provide an easy-to-use toolkit and give guidance to our engineering teams. 

## Measurements

**Grid Emission Factor** refers to CO2 emission factor (tCO2/MWh) which will be associated with each unit of electricity provided by an electricity system.​

**Marginal Operating Emissions Rate (MOER)** is a measurement in units of pounds of emissions per megawatt-hour (e.g. CO2 lbs/MWh), allowing to compare how marginal emissions rates vary by time and place by accurate marginal emissions analysis.

## Input Data
### MOER Data from WattTime API
One example to get MOER data in realtime is to use [WattTime API](https://www.watttime.org/api-documentation/#introduction)
This repo provides a .net core library to retrieve MOER real-time, historical, and forecast data, given a region or a pair of lat/lon.

**Step 1. Register an account** `public async Task<string> Register(User user)`

An example app can be found in [**RegisterExample**](RegisterExample) folder. 

Execute following command to run the sample app:
```
dotnet run -- username password email org
```


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
Couple of examples can be found in [**watttimeProcessor**](watttimeProcessor) folder.


### Data Center Locations
##### Azure Data Centers
1. Azure Data Center locations can be retrieved via Azure CLI cmd: 
```
az account list-locations
```
2. Convert the exported json file to GeoJson file using *AzureDataCenterConverter.ConvertToGeoJson* function.

#### On-premise Data Centers
Given the pre-known locations (lat/lon), create the GeoJson file using *GeoJSON.Net.Geometry* and *GeoJSON.Net.Feature* objects.

### Visualization

#### Azure Maps
You can follow the [Azure Maps document](https://docs.microsoft.com/en-us/azure/azure-maps/) to create a map service. You can also refer to https://github.com/Azure-Samples/AzureMapsCodeSamples to get more examples.

Here is an example map view using Azure Maps
![image](https://user-images.githubusercontent.com/62902203/170833157-df33e8d9-a241-4bbc-bdc5-f4b270c5f332.png)

#### Geo Data Viewer
[geo-data-viewer](https://github.com/RandomFractals/geo-data-viewer) provides a [VS Code extension](https://marketplace.visualstudio.com/items?itemName=RandomFractalsInc.geo-data-viewer) that supports to preview geojson files. By combining different data sources, you can configure and preview the MOER data on a map easily from VS Code or Codespaces.

Here is an example map view using geo-data-viewer
<img width="1062" alt="image" src="https://user-images.githubusercontent.com/62902203/172466718-52763c8e-8088-46b3-b55f-e17bc6db54f9.png">

#### VS Code Data Preview
[vscode-data-preview](https://github.com/RandomFractals/vscode-data-preview) provides a [VS Code extension](https://marketplace.visualstudio.com/items?itemName=RandomFractalsInc.vscode-data-preview) that supports to preview csv, excel or other grid data in VS code or Codespaces.

Here is an example chart of forecast data using vscode-data-preview 
![image](https://user-images.githubusercontent.com/62902203/172475752-420ada12-8cc8-497c-bcb7-c9fd4208b99e.png)


## Collaborating With the WG

**Adding changes**

1. Create a new Issue<br>
2. Discuss Issue with the WG --> Create PR if required<br>
3. PR to be submitted against the **DEV feature branch** (Everything gets merged into the Dev branch)<br>
4. PR discussed with the WG. If the WG agrees to the changes, the WG Chair/Project lead will merge the PR into DEV Feature branch - **Only the Chair/Project lead can merge into the Dev branch**.<br>

**Project public release**

1. At the point of the project being ready for release (merging Dev into Main), please inform the Opensource WG Chair(s), as there needs to be a consistency review for all GSF members to add any final comments before its official release.
2. Once the consistency review has been completed and any comments resolved, the Opensource WG will approve the project for the Chair/Project lead to merge Dev into Main. 

<figure>
	<img src="images/single-trunk-branch.svg" alt="GSF Single-Trunk Based Branch Flow">
	<figcaption></figcaption>
</figure>


## Help
helpdesk@greensoftware.io

