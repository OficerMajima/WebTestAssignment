using System.Text.Json.Serialization;

namespace ModelsLibrary.Models
{
    /// <summary>
    /// Класс представляющий заказ пользователя.
    /// </summary>
    public class UserOrder
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("orderdate")]
        public string OrderDate { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("userid")]
        public int? UserID { get; set; }

    }
}