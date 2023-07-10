using Newtonsoft.Json;
using TSeb.Library.Core.Models;
using TSeb.Library.Data.Context;

namespace TSeb.Library.Management.ConsoleApp
{
    /// <summary>
    /// Purpose: Requirements code implementation
    /// Created by: TSeb
    /// </summary>
    public static class AppLogic
    {
        public static void GetBooks()
        {
            var books = MockedDataContext.Books;
            ParseItems(books);
        }

        public static string AddBook(TrackItemModel<BookModel> model)
        {
            var books = MockedDataContext.Books;

            ParseItems(books);
            books.Add(model);
            var lastBookInserted = books.Last();
            var result = JsonConvert.SerializeObject(lastBookInserted, Formatting.Indented);
            return result;
        }

        public static void UpdateBook(TrackItemModel<BookModel> model)
        {
            var books = MockedDataContext.Books;

            if (books.Any(b => b.TrackingItem.ISBN == model.TrackingItem.ISBN))
            {
                var book = books.FirstOrDefault(b => b.TrackingItem.ISBN == model.TrackingItem.ISBN);
                var existingBook = JsonConvert.SerializeObject(book, Formatting.Indented);
                Console.WriteLine(existingBook);
                book.StockQuantity++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{ \"StockQuantity\": " + JsonConvert.SerializeObject(book.StockQuantity, Formatting.Indented) + " }");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void RentBook(RentalModel model)
        {
            var book = MockedDataContext.Books.FirstOrDefault(b => b.Id == model.Item.Id);
            if (book != null)
            {
                book.StockQuantity--;
                model.RentalId = MockedDataContext.RentalItems.Count == 0 ? 1 : (MockedDataContext.RentalItems.Last().RentalId + 1);
                if (book.StockQuantity <= 0)
                {
                    MockedDataContext.Books.Remove(book);
                }
                Console.WriteLine("Book is rented: " + JsonConvert.SerializeObject(book.TrackingItem, Formatting.Indented));
                Console.WriteLine("Remaining stock: " + book.StockQuantity);
                MockedDataContext.RentalItems.Add(model);
            }
        }

        public static void ReturnedBook(int rentalId)
        {
            var rental = MockedDataContext.RentalItems.FirstOrDefault(b => b.RentalId == rentalId);
            var trackedBookId = ((TrackItemModel<BookModel>)rental.Item).Id;
            Console.WriteLine("Stock Quantity BEFORE return was: " + ((TrackItemModel<BookModel>)rental.Item).StockQuantity);

            if (((TrackItemModel<BookModel>)rental.Item).StockQuantity == 0)
            {
                MockedDataContext.Books.Add((TrackItemModel<BookModel>)rental.Item);
            }
            ((TrackItemModel<BookModel>)rental.Item).StockQuantity += 1;

            MockedDataContext.RentalItems.RemoveAll(x => x.RentalId == rentalId);

            Console.WriteLine("Stock Quantity AFTER return is: " + MockedDataContext.Books.FirstOrDefault(b => b.TrackingItem.Id == trackedBookId).StockQuantity);
        }

        private static void ParseItems(IEnumerable<TrackItemModel<BookModel>> list)
        {
            foreach (var item in list)
            {
                var result = JsonConvert.SerializeObject(item, Formatting.Indented);
                Console.WriteLine($"{result}");
            }
        }
    }
}
