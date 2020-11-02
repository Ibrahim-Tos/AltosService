using System;
using System.Collections.Generic;
using System.Text;

namespace Altos.Domain.Features.Products
{
    /// <summary>
    /// Represents a product
    /// </summary>
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductTimeZoneId { get; set; }
        /// <summary>
        /// Gets or sets the id of the company that owns the product (i.e: TTG, etc)
        /// </summary>
        public int CompanyId { get; set; }
        public string Sku { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public int? TotalReviews { get; set; }
        public int? TotalRating { get; set; }
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
        public DateTime? LastModifiedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product deletion
        /// </summary>
        public DateTime? DeletedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the collection of product instances, both on and off of a series.
        /// </summary>
        public virtual ICollection<ProductInstance> ProductInstances { get; protected set; } = new List<ProductInstance>();

    }
}
