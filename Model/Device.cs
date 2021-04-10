using Newtonsoft.Json;

namespace WakeOnLan.Model
{
    public class Device
    {
        [JsonProperty("mac")]
        public string MacAddress { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}