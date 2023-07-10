namespace TSeb.Library.Management.Api.Dtos
{
    public class PostRentalsDto
    {
        /// <summary>
        /// Name of the person that rent the item
        /// </summary>
        public string RenterName { get; set; }

        /// <summary>
        /// Charge of the rent / day
        /// </summary>
        public decimal TaxCharge { get; set; }

        /// <summary>
        /// Object that is being rent
        /// </summary>
        public int ItemId { get; set; }

        public string RentDate { get; set; }
    }
}
