namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents all three distinct value
    /// implementations for the homework assignment.
    /// </summary>
    public class ThreeDistinct
    {
        private List<int> randomIntegersList = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDistinct"/> class.
        /// Initializes randomIntegersList with random integers ranging from 0 to 20000.
        /// </summary>
        public ThreeDistinct()
        {
            Random rand = new Random();

            for (int i = 0; i < 10000; i++)
            {
                this.randomIntegersList.Add(rand.Next(200001));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDistinct"/> class.
        /// Copy constructor which sets randomIntegersList to the inputList.
        /// </summary>
        /// <param name="inputList">An input list to be used with the distinct implementations.</param>
        public ThreeDistinct(List<int> inputList)
        {
            this.randomIntegersList = inputList;
        }

        /// <summary>
        /// Returns the number of distinct numbers in randomIntegersList by inserting
        /// each value into a hashset and then getting the hashsets count field and
        /// return it.
        /// </summary>
        /// <returns>Returns the numbers of distint values in randomIntegersList.</returns>
        public int HashSetMethod()
        {
            HashSet<int> valuesHashSet = new HashSet<int>();

            // Adding each value to the hashset. Since hash sets are sets,
            // only one instance of each value can exists so we just keep
            // adding every value until we're done.
            foreach (int value in this.randomIntegersList)
            {
                valuesHashSet.Add(value);
            }

            return valuesHashSet.Count;
        }

        /// <summary>
        /// Returns the number of distinct numbers in randomIntegersList by
        /// looping through all possible value (0-20000) and checking if the list contains
        /// that value. If it does, add 1 to the count.
        /// </summary>
        /// <returns>Returns the total numbers of distinct values in randomIntegersList.</returns>
        public int BigOOneMethod()
        {
            int count = 0;

            // Since randomIntegersList can only contain values 0-20000, I loop through
            // and check to see if each value is contained in the array and then add 1 if
            // it is.
            for (int i = 0; i < 20000; i++)
            {
                if (this.randomIntegersList.Contains(i))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
