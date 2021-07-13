using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nop.Plugin.ExchangeRate.Quandl
{
    public class QuandlResponse
    {
        [JsonProperty(PropertyName = "dataset")]
        public QuandlDataset Dataset { get; set; }
    }

    public class QuandlDataset
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "dataset_code")]
        public string DatasetCode { get; set; }

        [JsonProperty(PropertyName = "database_code")]
        public string DatabaseCode { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "data")]
        public IEnumerable<string[]> Data { get; set; }
    }
}
