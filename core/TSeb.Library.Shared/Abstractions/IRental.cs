namespace TSeb.Library.Shared
{
    /// <summary>
    /// Purpose: Represents any object that can be rented
    /// Created by: TSeb
    /// </summary>
    public interface IRental
    {
        /// <summary>
        /// Id of the rental action (is being set by Db, or manually in this case)
        /// </summary>
        public int RentalId { get; set; }

        /// <summary>
        /// Person that rent the item
        /// </summary>
        public string RenterName { get; set; }

        /// <summary>
        /// Represents the number to charge the renter / per day
        /// </summary>
        public decimal TaxCharge { get; set; }
        
        /// <summary>
        /// Date when the rent was provided
        /// </summary>
        public DateTime RentDate { get; }
    }
}

