namespace Altos.Domain.Features.Products
{
    /// <summary>
    /// Represents a product type
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// Represents an unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Represents a custom product/booking (instance)
        /// </summary>
        InstantiableProduct = 10,

        /// <summary>
        /// Represents all other products not custom
        /// </summary>
        Main = 20
    }
}
