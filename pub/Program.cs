using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pub
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
        static void Main(string[] args)
        {
            List<DatasetProcessBatch> datasetProcessBatches = GetDataset();
            
            for (int i = 0; i < datasetProcessBatches.Count; i++)
            {
                var data = JsonSerializer.Serialize(datasetProcessBatches[i]); ;
                Console.WriteLine($"Sending {data}");
                var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
                if (datasetProcessBatches[i].Status == "Queued")
                {
                    var responseque = client.PostAsync($"http://localhost:{daprPort}/v1.0/publish/pubsub/datasetprocess", content).Result;
                }
                else if (datasetProcessBatches[i].Status == "Completed")
                {
                    var responseque = client.PostAsync($"http://localhost:{daprPort}/v1.0/publish/pubsub/datasetcompleted", content).Result;
                }
                
            }
        }
        static List<DatasetProcessBatch> GetDataset()
        {
            List<DatasetProcessBatch> datasetProcessBatches = new List<DatasetProcessBatch>();
            DatasetProcessBatch obj = new DatasetProcessBatch();
            obj.DatasetId = 9999;
            obj.Status = "Queued";
            obj.BatchId = 1;
            obj.UserId = "1";
            obj.CreatedOn = "04-09-2021 20:03";
            datasetProcessBatches.Add(obj);
            DatasetProcessBatch obj2 = new DatasetProcessBatch();
            obj2.DatasetId = 2;
            obj2.Status = "Completed";
            obj2.BatchId = 1;
            obj2.UserId = "1";
            obj2.CreatedOn = "04-09-2021 20:03";
            datasetProcessBatches.Add(obj2);
            DatasetProcessBatch obj3 = new DatasetProcessBatch();
            obj3.DatasetId = 3;
            obj3.Status = "Queued";
            obj3.BatchId = 1;
            obj3.UserId = "1";
            obj3.CreatedOn = "04-09-2021 20:03";
            datasetProcessBatches.Add(obj3);
            return datasetProcessBatches;
        }
    }
}
