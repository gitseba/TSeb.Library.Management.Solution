using Microsoft.AspNetCore.Mvc;
using System.Text;
using TSeb.Library.Management.RazorPages.Mvc.Models;
using TSeb.Library.Management.RazorPages.Mvc.ViewModels;
using TSeb.Library.Shared.Services;

namespace TSeb.Library.Management.RazorPages.Mvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly IWebHostEnvironment _hostEnv;
        private HttpClient _httpClient;

        public BooksController(IHttpClientFactory httpClientFactory, IWebHostEnvironment hostEnvironment)
        {
            _httpClient = httpClientFactory.CreateClient();
            _hostEnv = hostEnvironment;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new BookVm());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BookVm book)
        {
            var books = await ApiHelper.GetDataFromAsync<List<TrackItemModel>>(url: "http://localhost:5000/api/books");

            var data = new TrackItemModel
            {
                Id = books.model.Count + 1, 
                StockQuantity = 1,
                Authors = book.Authors,
                ISBN = book.ISBN,
                Thumbnail = $"{_hostEnv.WebRootPath}/img/{Path.GetFileNameWithoutExtension(book.Thumbnail.FileName)}.jpg",
                Title = book.Title                 
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Create the HttpRequestMessage with the desired URL and HTTP method
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/books"){ Content = content };

            // Send the request and retrieve the response
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            return RedirectToAction("Index", "Home");
        }

        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var book = await ApiHelper.GetDataFromAsync<TrackItemModel>(url: $"http://localhost:5000/api/books/{id}");

            var bookVm = new BookVm_Details
            {
                Title = book.model.Title,
                Authors = book.model.Authors,
                BookId = book.model.Id,
                ISBN = book.model.ISBN,
                Thumbnail = book.model.Thumbnail,
                StockQuantity = book.model.StockQuantity
            };

            return View(bookVm);
        }
    }
}
