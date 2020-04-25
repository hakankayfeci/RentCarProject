using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCP.UI.Model
{
    public class Brand
    {
        [JsonProperty("id")]
        public int Brandid { get; set; }

        [JsonProperty("brand")]
        public string BrandName { get; set; }

        public List<Model> ModelName { get; set; }
    }
    public class Model
    {
        public int ModelId { get; set; }
        [JsonProperty("models")]
        public string ModelName { get; set; }
    }
}