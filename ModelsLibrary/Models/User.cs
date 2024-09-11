using System.Text.Json.Serialization;

namespace ModelsLibrary.Models

{
    /// <summary>
    /// Класс представляющий пользователя.
    /// </summary>
    public class User
    {
        [JsonPropertyName("id")]
        public int? ID { get; set; }
        [JsonPropertyName("login")]
        public string? Login { get; set; }
        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}