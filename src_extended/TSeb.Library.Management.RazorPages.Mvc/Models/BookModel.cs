using Newtonsoft.Json;

namespace TSeb.Library.Management.RazorPages.Mvc.Models
{
    public class BookModel
    {
        /// <summary>
        /// Book's title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Author (s)
        /// </summary>
        public string[] Authors { get; set; }

        /// <summary>
        /// The International Standard Book Number (ISBN) is a numeric commercial book identifier that is intended to be unique.
        /// It is used to uniquely identify a particular version or release of a book, rather than the book itself or all editions of the book.
        /// </summary>
        public string ISBN { get; set; }
    }
}
