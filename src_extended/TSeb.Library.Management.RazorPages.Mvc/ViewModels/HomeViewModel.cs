using TSeb.Library.Management.RazorPages.Mvc.Models;

namespace TSeb.Library.Management.RazorPages.Mvc.ViewModels
{
    /// <summary>
    /// Home view moedl object. Contains all the necessary information to display the Home dashboard page
    /// </summary>
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Books = new List<TrackItemModel>();
            Rentals = new List<RentalModel>();
        }

        public List<TrackItemModel> Books { get; set; }
        public List<RentalModel> Rentals { get; set; }
    }
}
