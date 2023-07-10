using TSeb.Library.Shared;

namespace TSeb.Library.Management.RazorPages.Mvc.Models
{
    public class RentalModel
    {
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
        public DateTime RentDate => DateTime.Parse(DateTime.Now.ToString("g"));

        /// <summary>
        /// Object that is being rent
        /// </summary>
        public TrackItemModel Item { get; set; }
    }
}
