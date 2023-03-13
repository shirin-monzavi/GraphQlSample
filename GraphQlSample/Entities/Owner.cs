using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GraphQlSample.Entities
{
    public class Owner
    {
        public Owner()
        {
            Accounts = new List<Account>();
        }

        [JsonProperty]
        public Guid Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Address { get; set; }
        [JsonProperty]
        public ICollection<Account> Accounts { get; set; }
    }
}
