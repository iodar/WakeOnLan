using System.Collections.Generic;
using Newtonsoft.Json;

namespace WakeOnLan.Model
{
    public class DeviceList
    {
        [JsonProperty("devices")]
        public IList<Device> Devices { get; set; }
    }
}