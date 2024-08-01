using ImageToText.Interfaces;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ImageToText.Services
{
    public class ComputerVisionService : IComputerVision
    {
        private ComputerVisionClient _client;

        public ComputerVisionService()
        {
            var endpoint = "https://<your-region>.api.cognitive.microsoft.com";

            var key = "<your-api-key>";

            _client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
            { Endpoint = endpoint };
        }

        public async Task<string> GenerateImageToTextAsync(Stream imageStream)
        {
            try
            {
                var textHeaders = await _client.ReadInStreamAsync(imageStream);
                string operationLocation = textHeaders.OperationLocation;
                string operationId = operationLocation.Substring(operationLocation.Length - 36);

                ReadOperationResult results;
                do
                {
                    results = await _client.GetReadResultAsync(Guid.Parse(operationId));
                }
                while (results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted);

                StringBuilder stringBuilder = new StringBuilder();
                var textRecognitionResults = results.AnalyzeResult.ReadResults;

                foreach (var page in textRecognitionResults)
                {
                    foreach (var line in page.Lines)
                    {
                        stringBuilder.AppendLine(line.Text);
                    }
                }

                return stringBuilder.ToString();
            }
            catch (ComputerVisionOcrErrorException ex)
            {
                // Log the detailed error message
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Status Code: {ex.Response.StatusCode}");
                Console.WriteLine($"Headers: {string.Join(", ", ex.Response.Headers)}");

                // Re-throw the exception to handle it in the controller
                throw;
            }
        }
    }
}