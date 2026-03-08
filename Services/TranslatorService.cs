
using System.Text;
using System.Text.Json;

namespace Azure_AI_DocumentProcessor.Services
{
    public class TranslatorService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public TranslatorService(IConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        public async Task<string> TranslateAsync(string text, string targetLanguage)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var endpoint = _config["Translator:Endpoint"];
            var key = _config["Translator:Key"];
            var region = _config["Translator:Region"];

            var route = $"/translate?api-version=3.0&to={targetLanguage}";
            var url = endpoint + route;

            var body = new object[] { new { Text = text } };
            var requestBody = JsonSerializer.Serialize(body);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            request.Headers.Add("Ocp-Apim-Subscription-Key", key);
            request.Headers.Add("Ocp-Apim-Subscription-Region", region);

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(result);

            return doc.RootElement[0]
                .GetProperty("translations")[0]
                .GetProperty("text")
                .GetString();
        }
    }
}