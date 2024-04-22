using Newtonsoft.Json;
using OnlineCourse.Model.Models;
using System;

namespace OnlineCourse.Service;

public class Service<T> : IService<T> where T : class
{
    private string _baseUrl = "http://localhost:60805/api";
    GetAllListMainResponseModel dessirilizeResponse = new GetAllListMainResponseModel();
    public async Task<List<T>> GetAllAsync(string url)
    {
        var returnResponse = new List<T>();
        using (var client = new HttpClient())
        {
            string requestUrl = $"{_baseUrl}/{url}"; // Construct the full URL

            var apiResonse = await client.GetAsync(requestUrl);
            if (apiResonse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await apiResonse.Content.ReadAsStringAsync();
                dessirilizeResponse = JsonConvert.DeserializeObject<GetAllListMainResponseModel>(response);
                if (dessirilizeResponse.count > 0)
                {
                    returnResponse = JsonConvert.DeserializeObject<List<T>>(dessirilizeResponse.items.ToString());
                }
            }
        }
        return returnResponse;
    }

    public async Task<T> GetByIdAsync(string url)
    {
        T returnResponse = default(T); // Initialize to default value
        using (var client = new HttpClient())
        {
            string requestUrl = $"{_baseUrl}/{url}"; // Construct the full URL

            var apiResonse = await client.GetAsync(requestUrl);
            if (apiResonse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await apiResonse.Content.ReadAsStringAsync();
                returnResponse = JsonConvert.DeserializeObject<T>(response);
              
            }
        }
        return returnResponse;
    }
}