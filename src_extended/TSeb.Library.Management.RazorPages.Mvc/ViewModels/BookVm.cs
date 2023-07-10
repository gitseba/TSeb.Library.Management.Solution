using System.ComponentModel.DataAnnotations;

namespace TSeb.Library.Management.RazorPages.Mvc.ViewModels
{
    public class BookVm
    {
        public int BookId { get; set; }

        [StringLength(40)]
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public string ISBN { get; set; }

        /// <summary>
        /// Profile Photo loaded by User
        /// </summary>
        public IFormFile Thumbnail { get; set; }
    }
}
