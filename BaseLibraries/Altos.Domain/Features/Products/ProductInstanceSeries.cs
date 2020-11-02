using System;
using System.Collections.Generic;

namespace Altos.Domain.Features.Products
{
    /// <summary>
    /// Represents a product instance series
    /// </summary>
    public class ProductInstanceSeries : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product (owner) identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets title of the series
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets start date and time of the series
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets end date and time of the series
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets start time zone of the series
        /// </summary>
        public string StartTimezone { get; set; }

        /// <summary>
        /// Gets or sets end time zone of the series
        /// </summary>
        public string EndTimezone { get; set; }

        /// <summary>
        /// Gets or sets available places
        /// </summary>
        public int? Availability { get; set; }

        /// <summary>
        /// Gets or sets description of the series
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets recurrence rule of the series
        /// </summary>
        public string RecurrenceRule { get; set; }

        /// <summary>
        /// Gets or sets recurrence exception of the series
        /// </summary>
        public string RecurrenceException { get; set; }

        /// <summary>
        /// Gets or sets if all day series
        /// </summary>
        public bool IsAllDay { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Gets the product (Owner)
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the collection of product instances
        /// </summary>
        public virtual ICollection<ProductInstance> ProductInstances { get; set; } = new List<ProductInstance>();
        public bool IsDeleted { get; set; }

        #endregion
    }
}
