using TSeb.Library.Shared;

namespace TSeb.Library.Core.Models
{
    /// <summary>
    /// Purpose: This class acts as a wrapper over an item that can be tracked (for rentals, shippings, orders...)
    /// Created by: TSeb
    /// </summary>
    public class TrackItemModel<T> 
        : IItem
    {
        /// <summary>
        /// Track Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Object to be tracked
        /// </summary>
        public T TrackingItem { get; set; }

        /// <summary>
        /// How may items are in stock
        /// </summary>
        public int StockQuantity { get; set; }
    }
}