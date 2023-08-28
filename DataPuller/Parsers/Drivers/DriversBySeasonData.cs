using Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPuller.Parsers.Drivers
{
    public class DriversBySeasonData
    {
        public string url { get; set; }

        public DriversBySeasonData(string url)
        {
            this.url = url;
        }
        public DriversBySeasonData() { }

        public void PrintURL()
        {
            Console.WriteLine(url);
        }
        // Getting correct deserialized WHOLE json object as a ROOTOBJECT
        private async Task<Rootobject> GetRootForDrivers()
        {
            APIService apiserv = new APIService(url);
            Deserializer serializer = new Deserializer();
            string stringFromAPI = await apiserv.GetStringFromAPIAsync();
            Rootobject root = serializer.DeserializeJson<Rootobject>(stringFromAPI);
            return root;
        }
        // Returns array of Drivers
        private async Task<Driver[]> GetDriversArray(Rootobject root)
        {
            Driver[] drivers = root.MRData.DriverTable.Drivers;
            return drivers;
        }

        public void SetURL(string url)
        {
            this.url = url;
        }
        public async Task<Driver[]> GetDriversAsync()
        {
            Rootobject root = await GetRootForDrivers();
            Driver[] drivers = await GetDriversArray(root);
            return drivers;
        }

        public async Task<Driver[]> GetDriversAsyncMyAPI(string _url)
        {
            APIService apiserv = new APIService(_url);
            Deserializer serializer = new Deserializer();
            string stringFromAPI = await apiserv.GetStringFromAPIAsync();
            await Console.Out.WriteLineAsync(stringFromAPI);
            Driver[] drivers = serializer.DeserializeJson<Driver[]>(stringFromAPI);
            return drivers;
        }
    }
}
