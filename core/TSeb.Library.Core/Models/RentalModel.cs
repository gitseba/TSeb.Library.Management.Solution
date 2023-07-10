using TSeb.Library.Shared;

namespace TSeb.Library.Core.Models
{
    /// <summary>
    /// Purpose: 
    /// Created by: TSeb
    /// </summary>
    public class RentalModel : IRental
    {
        /// <summary>
        /// Id of the rent 
        /// Created by: TSeb
        /// </summary>
        public int RentalId { get; set; }
        
        /// <summary>
        /// Name of the person that rent the item
        /// </summary>
        public string RenterName { get; set; }

        /// <summary>
        /// Charge of the rent / day
        /// </summary>
        public decimal TaxCharge { get; set; }
        
        /// <summary>
        /// Date when the rent has been placed
        /// </summary>
        public DateTime RentDate { get; set; }

        /// <summary>
        /// Object that is being rent
        /// </summary>
        public IItem Item { get; set; }
    }
}
