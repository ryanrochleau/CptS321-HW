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

        /// <summary>
        /// Searches the product list according to the input provided by the user.
        /// The user can give multiple strings delimited by spaces and then indicate whether
        /// the search is an AND or OR search. AND searches will ensure that all strings are
        /// present in the product while OR searched will just ensure 1 string is present
        /// in the product.
        /// </summary>
        /// <returns>A list of products.</returns>
        public List<Product> Search()
        {
            string searchQuery;
            int isAndorOr;
            List<Product> returnList = new List<Product>();
            bool successful = true;

            Console.WriteLine("Enter a search query: ");
            searchQuery = Console.ReadLine();

            if (searchQuery.Length == 0)
            {
                return this.GetProductList();
            }
            else
            {
                string[] subs = searchQuery.Split(' ');

                // Checking if there are more than 1 strings in the search query
                if (subs.Length > 1)
                {
                    Console.WriteLine("Enter 1 for AND search and 2 for OR search: ");
                    isAndorOr = Convert.ToInt32(Console.ReadLine());

                    // AND search
                    if (isAndorOr == 1)
                    {
                        // Nested foreach loops to loop through each product and check that each string
                        // is present in the product or not. Set successful to false and break if there
                        // is no occurance of the string since this is an AND search.
                        foreach (Product product in this.products)
                        {
                            foreach (string substring in subs)
                            {
                                if (product.GetUniqueId().Contains(substring))
                                {
                                    successful = true;
                                }
                                else if (product.GetDescription().Contains(substring))
                                {
                                    successful = true;
                                }
                                else
                                {
                                    successful = false;
                                    break;
                                }
                            }

                            if (successful == true)
                            {
                                returnList.Add(product);
                            }
                        }
                    }

                    // OR search
                    else
                    {
                        // Nested foreach loops as in AND implementation. Break if we find a field with
                        // the substring since this is an OR search.
                        foreach (Product product in this.products)
                        {
                            foreach (string substring in subs)
                            {
                                if (product.GetUniqueId().Contains(substring))
                                {
                                    successful = true;
                                    break;
                                }
                                else if (product.GetDescription().Contains(substring))
                                {
                                    successful = true;
                                    break;
                                }
                                else
                                {
                                    successful = false;
                                }
                            }

                            if (successful == true)
                            {
                                returnList.Add(product);
                            }
                        }
                    }
                }

                // Only 1 token present in the input string
                else
                {
                    foreach (Product product in this.products)
                    {
                        foreach (string substring in subs)
                        {
                            if (product.GetUniqueId().Contains(substring))
                            {
                                successful = true;
                                break;
                            }
                            else if (product.GetDescription().Contains(substring))
                            {
                                successful = true;
                                break;
                            }
                            else
                            {
                                successful = false;
                            }
                        }

                        if (successful == true)
                        {
                            returnList.Add(product);
                        }
                    }
                }
            }

            return returnList;
        }
    }
}
