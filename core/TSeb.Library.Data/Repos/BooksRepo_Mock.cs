using TSeb.Library.Core.Models;
using TSeb.Library.Data.Context;

namespace TSeb.Library.Data.Repos
{
    /// <summary>
    /// Purpose: Represents mocked data service
    /// Created by: TSeb
    /// </summary>
    public class BooksRepo_Mock : IBooksRepo
    {
        public IReadOnlyList<TrackItemModel<BookModel>> GetAll() => MockedDataContext.Books;

        public TrackItemModel<BookModel> GetById(int id) => MockedDataContext.Books.FirstOrDefault(b => b.Id == id);

        public void Create(TrackItemModel<BookModel> book)
        {
            var existingBook = MockedDataContext.Books.FirstOrDefault(b => b.TrackingItem.Id == book.TrackingItem.Id);
            if (existingBook != null)
            {
                existingBook.StockQuantity++;
            }
            else
            {
                book.TrackingItem.Id = MockedDataContext.Books.Count + 1;
                MockedDataContext.Books.Add(book);
            }
        }

        public void Update(TrackItemModel<BookModel> book)
        {
            var dbBook = MockedDataContext.Books.FirstOrDefault(b => b.Id == book.Id);
            dbBook = book;
        }

        public void Delete(int id) => MockedDataContext.Books.RemoveAll(x => x.Id == id);
    }
}
