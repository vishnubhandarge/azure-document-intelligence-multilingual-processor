
using Azure;
using Azure.AI.DocumentIntelligence;

namespace Azure_AI_DocumentProcessor.Services
{
    public class DocumentAIService
    {
        private readonly DocumentIntelligenceClient _client;

        public DocumentAIService(IConfiguration config)
        {
            var endpoint = config["DocumentAI:Endpoint"];
            var key = config["DocumentAI:Key"];

            _client = new DocumentIntelligenceClient(
                new Uri(endpoint),
                new AzureKeyCredential(key));
        }

        public async Task<AnalyzeResult> AnalyzeAsync(Stream stream)
        {
            var binaryData = await BinaryData.FromStreamAsync(stream);

            var operation = await _client.AnalyzeDocumentAsync(
                WaitUntil.Completed,
                "prebuilt-layout",
                binaryData);

            return operation.Value;
        }
    }
}
