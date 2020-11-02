using System;

namespace Altos.Domain.Features.Products
{
    /// <summary>
    /// Represents a product instance
    /// </summary>
    public class ProductInstance : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product instance series identifier
        /// </summary>
        public int ProductInstanceSeriesId { get; set; }

        /// <summary>
        /// Gets or sets title of the instance
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets description of the instance
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets start date and time of the instance
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets end date and time of the series
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets available places
        /// </summary>
        public int Availability { get; set; }

        /// <summary>
        /// Gets or sets initial available places
        /// </summary>
        public int InitialAvailability { get; set; }

        public int GroupNumber { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? LastModifiedOnUtc { get; set; }

        public DateTime? DeletedOnUtc { get; set; }

        public int ProductId { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Gets the product instance series
        /// </summary>
        public virtual ProductInstanceSeries ProductInstanceSeries { get; set; }

        public virtual Product Product { get; set; }

        #endregion
    }
}
