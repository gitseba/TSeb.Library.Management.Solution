using Microsoft.AspNetCore.Mvc;
using TSeb.Library.Core.Models;
using TSeb.Library.Data;
using TSeb.Library.Management.Api.Dtos;

namespace TSeb.Library.Management.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo _booksRepo;

        public BooksController(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksDto))]
        public ActionResult<IReadOnlyList<BooksDto>> GetBooks()
        {
            //Alternative to AutoMapper
            var books = _booksRepo.GetAll()
                //.Where(b => b.StockQuantity > 0)
                .Select(b => new BooksDto
                {
                    Id = b.Id,
                    StockQuantity = b.StockQuantity,
                    Title = b.TrackingItem.Title,
                    Authors = b.TrackingItem.Authors,
                    ISBN = b.TrackingItem.ISBN,
                    Thumbnail = b.TrackingItem.Thumbnail
                });

            return books == null ? NoContent() : Ok(books);
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BooksDto> GetBookById(int id)
        {
            var book = _booksRepo.GetById(id);
            var result = new BooksDto
            {
                Id = book.Id,
                Title = book.TrackingItem.Title,
                Authors = book.TrackingItem.Authors,
                ISBN = book.TrackingItem.ISBN,
                StockQuantity = book.StockQuantity,
                Thumbnail = $"../../img/{id}.jpg"
            };
            
            return result;
        } //=> new JsonResult(_booksRepo.GetById(id));


        [HttpPost]
        public ActionResult<BooksDto> CreateBook(BooksDto book)
        {
            var mapped = new TrackItemModel<BookModel>
            {
                StockQuantity = book.StockQuantity,
                TrackingItem = new BookModel
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    Authors = book.Authors,
                    Thumbnail = book.Thumbnail
                }
            };
            _booksRepo.Create(mapped);

            return CreatedAtRoute(nameof(GetBookById), new { Id = book.ISBN }, book);
        }
    }
}
