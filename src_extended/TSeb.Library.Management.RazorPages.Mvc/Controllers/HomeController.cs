using Microsoft.AspNetCore.Mvc;
using TSeb.Library.Management.RazorPages.Mvc.Models;
using TSeb.Library.Management.RazorPages.Mvc.ViewModels;
using TSeb.Library.Shared.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace TSeb.Library.Management.RazorPages.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homeVm = new HomeViewModel();

            //
            var books = await ApiHelper.GetDataFromAsync<List<TrackItemModel>>(url: "http://localhost:5000/api/books");
            homeVm.Books = books.model;

            var rentals = await ApiHelper.GetDataFromAsync<List<RentalModel>>(url: "http://localhost:5000/api/rentals");
            homeVm.Rentals = rentals.model;

            return View(homeVm);
        }


    }
}