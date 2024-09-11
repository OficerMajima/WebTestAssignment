using System.Text.Json.Serialization;

namespace ModelsLibrary.Models
{
    /// <summary>
    /// Класс представляющий товар.
    /// </summary>
    public class Product
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
