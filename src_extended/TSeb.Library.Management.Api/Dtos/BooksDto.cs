namespace TSeb.Library.Management.Api.Dtos
{
    public class BooksDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Book's title
        /// </summary>
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

        /// <summary>
        /// How may items are in stock
        /// </summary>
        public int StockQuantity { get; set; }

        public string Thumbnail { get; set; }
    }
}
