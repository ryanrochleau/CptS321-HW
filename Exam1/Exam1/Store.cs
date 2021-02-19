namespace Exam1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Store
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
        /// Initializes a new instance of the <see cref="Store"/> class.
        /// Constructor with and input list.
        /// </summary>
        /// <param name="newList">Input list of products.</param>
        public Store(List<Product> newList)
        {
            this.products = newList;
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
        /// Gets the recentSearchTime string.
        /// </summary>
        /// <returns>A string which represent the time of a recent search.</returns>
        public string GetRecentSearchTime()
        {
            return this.recentSearchTime;
        }

        /// <summary>
        /// Sets the recentSearchTime field to an input.
        /// </summary>
        /// <param name="recentTime">A new string that is the recent search time.</param>
        public void SetRecentSearchTime(string recentTime)
        {
            this.recentSearchTime = recentTime;
        }

        /// <summary>
        /// Gets the most recent search string.
        /// </summary>
        /// <returns>String for recent search.</returns>
        public string GetRecentSearch()
        {
            return this.recentSearch;
        }

        /// <summary>
        /// Sets the recentSearch field to the input.
        /// </summary>
        /// <param name="recentSearch">A string which is the most recent search.</param>
        public void SetRecentSearch(string recentSearch)
        {
            this.recentSearch = recentSearch;
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
            int isAndorOr = -1;
            List<Product> returnList = new List<Product>();
            bool successful = true;

            Console.WriteLine("Enter a search query: ");
            searchQuery = Console.ReadLine();
            this.SetRecentSearch(searchQuery);
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

        /// <summary>
        /// Same as search function but takes string inputs instead of user input.
        /// Used for testing.
        /// </summary>
        /// <param name="searchQuery">Simulated search query string.</param>
        /// <param name="isAndorOr">Simulated search type int.</param>
        /// <returns>A list of products.</returns>
        public List<Product> Search(string searchQuery, int isAndorOr)
        {
            List<Product> returnList = new List<Product>();
            bool successful = true;

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
