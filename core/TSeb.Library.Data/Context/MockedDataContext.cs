using TSeb.Library.Core.Models;

namespace TSeb.Library.Data.Context
{
    /// <summary>
    /// Purpose: Defined mocked data for Library Management Solution
    /// Created by: TSeb
    /// </summary>
    public static class MockedDataContext
    {
        public static List<TrackItemModel<BookModel>> Books { get; set; }
        public static List<RentalModel> RentalItems { get; set; }

        static MockedDataContext()
        {
            Books = new List<TrackItemModel<BookModel>>
            {
                new TrackItemModel<BookModel>
                {
                    Id = 1,
                    StockQuantity = 10,
                    TrackingItem  = new BookModel
                    {
                        Id = 1,
                        Title = "The 50th Law",
                        Authors = new string[] { "50 Cent", "Robert Greene"},
                        ISBN = "979-8367220841",
                        Thumbnail = "./img/1.jpg"
                    }
                },
                new TrackItemModel<BookModel>
                {
                    Id = 2,
                    StockQuantity = 2,
                    TrackingItem  =  new BookModel
                    {
                        Id = 2,
                        Title = "To Kill a Mockingbird",
                        Authors = new string[] { "Harper Lee" },
                        ISBN = "9780060935467",
                        Thumbnail = "./img/2.jpg"
                    }
                }
            };

            RentalItems = new List<RentalModel>();
        }
    }
}

