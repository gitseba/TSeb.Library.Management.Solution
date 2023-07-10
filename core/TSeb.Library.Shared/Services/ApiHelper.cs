using System.Net.Http.Json;

namespace TSeb.Library.Shared.Services
{
    /// <summary>
    /// Purpose: Rest for API's
    /// Created by: sebde
    /// Created at: 5/28/2023 8:45:51 PM
    /// </summary>
    public static class ApiHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// GET data from url as an object model
        /// </summary>
        /// <typeparam name="T"> object model response </typeparam>
        /// <param name="url"> url resource </param>
        public static async Task<(T model, string error)> GetDataFromAsync<T>(string url)
        {
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        T result = await response?.Content.ReadFromJsonAsync<T>();
                        return (result, "");
                    }
                    else
                    {
                        return (model: default(T), response.ReasonPhrase);
                    }
                }

            }
            catch (InvalidOperationException ex)
            {
                return (model: default(T), ex.Message);
            }
            catch (Exception ex)
            {
                return (model: default(T), ex.Message);
            }
        }
    }
}
