namespace TSeb.Library.Management.RazorPages.Mvc.ViewModels
{
    public class PostRentViewModel
    {
        public int ItemId { get; set; }

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
    }
}
