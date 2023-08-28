using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPuller
{
    public class Deserializer
    {
        public T DeserializeJson<T>(string json)
        {
            try
            {
                T deserializedObject = JsonConvert.DeserializeObject<T>(json);
                return deserializedObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return default(T); // Default value for the type
            }
        }

        
    }


}
