using Microsoft.AspNetCore.Mvc;
using TSeb.Library.Core.Models;
using TSeb.Library.Data.Context;
using TSeb.Library.Data.Repos;
using TSeb.Library.Management.Api.Dtos;

namespace TSeb.Library.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalsRepo _rentalsRepo;

        public RentalsController(IRentalsRepo rentalsRepo)
        {
            _rentalsRepo = rentalsRepo;
        }

        //Se poate cere o lista cu toate cartile din biblioteca
        [HttpGet(Name = "GetRentals")]
        public ActionResult<IReadOnlyList<GetRentalsDto>> GetRentals()
        {
            //Alternative to AutoMapper
            var rentals = _rentalsRepo.GetAll()
                .Select(r => new GetRentalsDto
                {
                    Item = r.Item,
                    TaxCharge = r.TaxCharge,
                    RentalId = r.RentalId,
                    RenterName = r.RenterName,
                    RentDate = r.RentDate//DateTime.Parse(DateTime.Now.ToString("g"))
                });

            return rentals == null ? NoContent() : Ok(rentals);
        }

        [HttpPost]
        public ActionResult<PostRentalsDto> CreateRental(PostRentalsDto rental)
        {
            var mapped = new RentalModel
            {
                RentalId = MockedDataContext.RentalItems.Count + 1,
                Item = new BookModel
                {
                    // Id of the item that is being rent
                    Id = rental.ItemId,
                },
                TaxCharge = rental.TaxCharge,
                RenterName = rental.RenterName,
                RentDate = DateTime.Parse(rental.RentDate)
            };
            _rentalsRepo.Create(mapped);

            return CreatedAtRoute(nameof(GetRentals), new { Id = mapped.RentalId }, mapped);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRental(int id)
        {
            _rentalsRepo.Delete(id);
            return Ok();
        }
    }
}
