using TSeb.Library.Core.Models;

namespace TSeb.Library.Data.Repos
{
    /// <summary>
    /// Purpose: 
    /// Created by: TSeb
    /// </summary>
    public interface IRentalsRepo
    {
        public IReadOnlyList<RentalModel> GetAll();

        public RentalModel GetById(int rentalCode);

        public void Create(RentalModel book);

        public void Delete(int id);
    }
}

