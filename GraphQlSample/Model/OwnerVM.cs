using Newtonsoft.Json;

namespace GraphQlSample.Model
{
    public class OwnerVM
    {
        [JsonProperty("createOwner")]
        public CreateOwner CreateOwner { get; set; }
    }

    public class CreateOwner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
