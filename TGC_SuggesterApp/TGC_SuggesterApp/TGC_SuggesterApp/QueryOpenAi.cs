using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TGC_ConjectureSuggesterApp
{
    // Getter/Setters for JSON data;
    public class QueryOpenAi
    {
        public static async Task<string> GetResult(string userMessage)
        {
            // Replace "your_data.json" with the actual path to your JSON file
            string filePath = "env.json";

            // Read JSON data from file
            string jsonKey = File.ReadAllText(filePath);


            AiKey aiKey = JsonConvert.DeserializeObject<AiKey>(jsonKey);

            // Set the OpenAI API endpoint for the Chat API
            string apiUrl = "https://api.openai.com/v1/chat/completions"; // Updated endpoint

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Clear();  // Clear existing headers
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {aiKey.OpenAiKey.Key}");
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

                var requestData = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                        {
                            //new { role = "system", content = "You are a helpful assistant." },
                            new { role = "user", content = userMessage }
                        }
                };

                // Convert request data to JSON
                string jsonData = JsonConvert.SerializeObject(requestData);

                // Create the HTTP content
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Make the POST request to the OpenAI API
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Read and return the response content
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
    }
}