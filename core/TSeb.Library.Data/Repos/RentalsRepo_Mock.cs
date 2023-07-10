using TSeb.Library.Core.Models;
using TSeb.Library.Data.Context;

namespace TSeb.Library.Data.Repos
{
    /// <summary>
    /// Purpose: Represents mocked data service
    /// Created by: TSeb
    /// </summary>
    public class RentalsRepo_Mock : IRentalsRepo
    {
        IReadOnlyList<RentalModel> IRentalsRepo.GetAll() => MockedDataContext.RentalItems;
        RentalModel IRentalsRepo.GetById(int rentalCode)
        {
            return MockedDataContext.RentalItems.FirstOrDefault(b => b.RentalId == rentalCode);
        }


        public void Create(RentalModel rental)
        {
            var book = MockedDataContext.Books.FirstOrDefault(b => b.Id == rental.Item.Id);
            rental.Item = MockedDataContext.Books.FirstOrDefault(b => b.Id == rental.Item.Id);
            if (book != null)
            {
                book.StockQuantity--;
                if (book.StockQuantity <= 0)
                {
                    book.StockQuantity = 0;//MockedDataContext.Books.Remove(book);
                }

                MockedDataContext.RentalItems.Add(rental);
            }
        }

        public void Delete(int rentalId)
        {
            var returnedBook = MockedDataContext.RentalItems.FirstOrDefault(f => f.RentalId == rentalId).Item;
            var inStockBatch = MockedDataContext.Books.FirstOrDefault(b => b.Id == returnedBook.Id);
            if (inStockBatch.StockQuantity == 0)
            {
                inStockBatch.StockQuantity = inStockBatch.StockQuantity++;
                //MockedDataContext.Books.Add(new TrackItemModel<BookModel>
                //{
                //    Id = 1,
                //    StockQuantity = 1,
                //    TrackingItem = ((TrackItemModel<BookModel>)returnedBook).TrackingItem
                //}); 
            }
            inStockBatch.StockQuantity += 1;

            MockedDataContext.RentalItems.RemoveAll(x => x.RentalId == rentalId);
        }
    }
}
