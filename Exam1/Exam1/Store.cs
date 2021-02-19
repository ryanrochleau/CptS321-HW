namespace Exam1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Store
    {
        private List<Product> products = new List<Product>();
        private string recentSearchTime;
        private string recentSearch;
        private List<Product> recentSearchProducts = new List<Product>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class.
        /// </summary>
        public Store()
        {
        }

        /// <summary>
        /// Adds a new product to the list.
        /// </summary>
        /// <param name="newProduct">New product to add.</param>
        public void AddProduct(Product newProduct)
        {
            this.products.Add(newProduct);
        }

        /// <summary>
        /// Gets the product list.
        /// </summary>
        /// <returns>The entire product list.</returns>
        public List<Product> GetProductList()
        {
            return this.products;
        }

        public List<Product> Search()
        {
            string searchQuery;
            int isAndorOr;
            Console.WriteLine("Enter a search query: ");
            searchQuery = Console.ReadLine();

            if (searchQuery.Length == 0)
            {
                return this.GetProductList();
            }
            else
            {
                string[] subs = searchQuery.Split(' ');

                if (subs.Length > 1)
                {
                    Console.WriteLine("Enter 1 for AND search and 2 for OR search: ");
                    isAndorOr = Convert.ToInt32(Console.ReadLine());
                    if (isAndorOr == 1)
                    {
                        foreach 
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
