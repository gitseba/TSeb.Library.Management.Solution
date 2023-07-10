using System.ComponentModel.DataAnnotations;

namespace TSeb.Library.Management.RazorPages.Mvc.ViewModels
{
    public class BookVm_Details
    {
        public int BookId { get; set; }

        [StringLength(40)]
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public string ISBN { get; set; }
        public string Thumbnail { get; set; }

        public int StockQuantity { get; set; }
    }
}
