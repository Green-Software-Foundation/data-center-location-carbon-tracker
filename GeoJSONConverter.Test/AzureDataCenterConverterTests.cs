using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace GeoJSONConverter.Test
    
{
    [TestClass]
    public class AzureDataCenterConverterTests
    {
        [TestMethod]
        public void ValidateAzureDataCenterConverter()
        {
            using (var reader = new StreamReader(@"azure_regions_sample.json"))
            {
                var text = reader.ReadToEnd();
                var dataCenters = AzureDataCenterConverter.ConvertToDataCenters(text);
                Assert.IsNotNull(dataCenters);
                Assert.AreEqual(75, dataCenters.Count);

                var eastUSCenter = dataCenters.First();
                Assert.IsNotNull(eastUSCenter);
                Assert.AreEqual("East US", eastUSCenter.DisplayName);
                Assert.AreEqual(37.3719f, eastUSCenter.Metadata.Latitude.Value, 10e-3f);
                Assert.AreEqual(-79.8164f, eastUSCenter.Metadata.Longitude.Value, 10e-3f);
            }
        }
    }
}