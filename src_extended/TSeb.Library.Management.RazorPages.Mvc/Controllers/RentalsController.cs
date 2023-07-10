using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TSeb.Library.Management.RazorPages.Mvc.Models;
using TSeb.Library.Management.RazorPages.Mvc.ViewModels;

namespace TSeb.Library.Management.RazorPages.Mvc.Controllers
{
    public class RentalsController : Controller
    {

        private readonly HttpClient _httpClient;

        public RentalsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("LibraryManagement.Api");
        }

        [HttpGet]
        public async Task<IActionResult> Rent(int id)
        {
            // Create the HttpRequestMessage with the desired URL and HTTP method
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/books/{id}");

            // Send the request and retrieve the response
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TrackItemModel>(responseContent);

            return View(new RentalViewModel { Rental = new RentalModel { Item = result } });
        }

        [HttpPost]
        public async Task<IActionResult> Rent(PostRentViewModel postRentalViewModel)
        {
            var json = JsonConvert.SerializeObject(postRentalViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Create the HttpRequestMessage with the desired URL and HTTP method
            var request = new HttpRequestMessage(HttpMethod.Post, "api/rentals")
            {
                Content = content // Set the content of the request
            };

            // Send the request and retrieve the response
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            return RedirectToAction(nameof(Index), "Home");

        }

        [Route("returned/{id}")]
        public async Task<IActionResult> Returned(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/rentals/{id}");
            request.Content = new StringContent(JsonConvert.SerializeObject(new { id }), Encoding.UTF8, "application/json");
            await this._httpClient.SendAsync(request);

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
