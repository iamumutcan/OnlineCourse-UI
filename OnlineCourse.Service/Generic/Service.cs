using Newtonsoft.Json;
using OnlineCourse.Model.Models;
using System;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public async Task<T> GetAsync(string url)
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
    public async Task<T> GetAsync(string url, string authToken)
    {
        T returnResponse = default(T); // Initialize to default value
        using (var client = new HttpClient())
        {
            string requestUrl = $"{_baseUrl}/{url}"; // Construct the full URL

            // Set the Authorization header with the provided authToken
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var apiResonse = await client.GetAsync(requestUrl);
            if (apiResonse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await apiResonse.Content.ReadAsStringAsync();
                returnResponse = JsonConvert.DeserializeObject<T>(response);

            }
        }
        return returnResponse;
    }

    public async Task<T> PostAsync(string url, T data)
    {
        T returnResponse = default(T); // Initialize to default value

        using (var client = new HttpClient())
        {
            string requestUrl = $"{_baseUrl}/{url}"; // Construct the full URL
            var jsonData = JsonConvert.SerializeObject(data);

            var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var apiResponse = await client.PostAsync(requestUrl, requestContent);
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                returnResponse = JsonConvert.DeserializeObject<T>(response);
                return returnResponse;

            }
        }
        return returnResponse;
    }
    public async Task<T> PostAsync(string url, T data, string authToken)
    {
        T returnResponse = default(T); // Initialize to default value

        using (var client = new HttpClient())
        {
            // Serialize data to JSON
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Add authorization header
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

            // Construct the full URL
            string requestUrl = $"{_baseUrl}/{url}";

            // Send POST request
            var apiResponse = await client.PostAsync(requestUrl, content);
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                returnResponse = JsonConvert.DeserializeObject<T>(response);
                return returnResponse;

            }

            return returnResponse;
        }
    }


}