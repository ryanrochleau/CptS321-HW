namespace Exam1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class representing a product.
    /// </summary>
    public class Product
    {
        private string uniqueId;
        private string description;
        private bool isPhysical;
        private int inStock;

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// Constructor for all parameters.
        /// </summary>
        /// <param name="uniqueId">New product id.</param>
        /// <param name="description">new product description.</param>
        /// <param name="isPhysical">New product isPhysical.</param>
        /// <param name="inStock">New amount in stock.</param>
        public Product(string uniqueId, string description, bool isPhysical, int inStock)
        {
            this.uniqueId = uniqueId;
            this.description = description;
            this.isPhysical = isPhysical;
            this.inStock = inStock;
        }


        /// <summary>
        /// Gets the unique id of the product.
        /// </summary>
        /// <returns>A string unique id.</returns>
        public string GetUniqueId()
        {
            return this.uniqueId;
        }

        /// <summary>
        /// Sets the unique id.
        /// </summary>
        /// <param name="newId">The new id.</param>
        public void SetUniqueId(string newId)
        {
            this.uniqueId = newId;
        }

        /// <summary>
        /// Gets the description of the product.
        /// </summary>
        /// <returns>The description.</returns>
        public string GetDescription()
        {
            return this.description;
        }

        /// <summary>
        /// Sets the description of the product.
        /// </summary>
        /// <param name="newDescription">The new description.</param>
        public void SetDescription(string newDescription)
        {
            this.description = newDescription;
        }

        /// <summary>
        /// Gets whether or not the product is physical.
        /// </summary>
        /// <returns>A boolean representing if the product is physical.</returns>
        public bool GetIsPhysical()
        {
            return this.isPhysical;
        }

        /// <summary>
        /// Sets whether or not the product is physical.
        /// </summary>
        /// <param name="newIsPhysical">The new bool for whether the product is physical.</param>
        public void SetIsPhysical(bool newIsPhysical)
        {
            this.isPhysical = newIsPhysical;
        }

        /// <summary>
        /// Returns the amount of items in stock.
        /// </summary>
        /// <returns>Integer for number of items in stock.</returns>
        public int GetInStock()
        {
            return this.inStock;
        }

        /// <summary>
        /// Sets the amount of items in stock.
        /// </summary>
        /// <param name="newInStock">Integer value for new stock amount.</param>
        public void SetInStock(int newInStock)
        {
            this.inStock = newInStock;
        }
    }
}
