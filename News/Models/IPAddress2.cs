using System.Text.Json.Serialization;

namespace News.Models
{
	public class IPAddress2
	{
		[JsonPropertyName("ip")]
		public string IP { get; set; }

		[JsonPropertyName("geo-ip")]
		public string GeoIP { get; set; }

		[JsonPropertyName("API Help")]
		public string APIHelp { get; set; }
	}
}
