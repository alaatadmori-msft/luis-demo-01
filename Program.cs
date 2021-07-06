// full sample code and explanation @ https://docs.microsoft.com/en-us/azure/cognitive-services/luis/client-libraries-rest-api?tabs=windows&pivots=programming-language-csharp#get-prediction-from-runtime

using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace luis_demo_src
{
    class Program
    {
        static async Task Main()
        {
            var appId = "REPLACE-WITH-YOUR-APP-ID";
            var key = "REPLACE-WITH-YOUR-AUTHORING-KEY";
            var predictionResourceName = "REPLACE-WITH-YOUR-PREDICTION-RESOURCE-NAME";

            var predictionEndpoint = string.Format("https://{0}.cognitiveservices.azure.com/", predictionResourceName);
            var credentials = new Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.ApiKeyServiceClientCredentials(key);
            
            var runtimeClient = new LUISRuntimeClient(credentials) { Endpoint = predictionEndpoint };

            var request = new PredictionRequest { Query = "I want two small pizzas" };
            
            // Production == slot name
            var prediction = await runtimeClient.Prediction.GetSlotPredictionAsync(Guid.Parse(appId), "Production", request);
            
            Console.Write(JsonConvert.SerializeObject(prediction, Formatting.Indented));
        }
    }
}
