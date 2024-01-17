// Conor Race
// Nov. 17th, 2021
// Purpose: Allows for the creation of CustomDictionaries. Replicates
// the function of C#'s actual Dictionary objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Dictionary
{
    class CustomDictionary<TKey, TValue>
    {
        private List<CustomPair<TKey, TValue>>[] myDict;
        private int count;

        /// <summary>
        /// Default constructor for CustomDictionary class. Should there be no specified array
        /// length, a default value of 100 is used as an initial length.
        /// </summary>
        public CustomDictionary() : this(100)
        {
        }
        
        /// <summary>
        /// Parameterized constructor for CustomDictionary class. Creates a custom dictionary object
        /// by taking in a dictionary length and setting its item count to 0.
        /// </summary>
        /// <param name="length"> The dictionary's initial length. </param>
        public CustomDictionary(int length)
        {
            myDict = new List<CustomPair<TKey, TValue>>[length];
            count = 0;
        }

        /// <summary>
        /// Property; Allows for the retrieval of the dictionary's element count.
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Property; Allows for the retrieval of the dictionary's load factor, as expressed by
        /// a particular formula.
        /// </summary>
        public double LoadFactor { get { return (double)count/myDict.Length; } }

        /// <summary>
        /// Indexer; Enables the CustomDictionary class to have its keyword identity (unlike a list's
        /// integer identity). Starts by converting the input key into a hash code int value and mods
        /// the value by the dictionary's length. Uses the index from there.
        /// 
        /// For Get: First checks if there is a pre-existing list at the array's index (as translated
        /// by the input key). If there is a list, the entire list is searched, checking if the keys
        /// ever match. If there is a match, the key's associated element is returned. Should any of
        /// these conditions fail, an exception is thrown.
        /// 
        /// For Set: If there is no pre-existing list at the array's index, creates a new list and
        /// inserts the key and element to that list (Count increases). If a list already exists at 
        /// the index, first checks the list to see if the key already exists. If it does, replaces
        /// the value with the new passed in one. If it does not, the key and value is added to end
        /// of the corresponding list (Count increases).
        /// </summary>
        /// <param name="key"> Generic key used for indexing purposes. </param>
        /// <returns> An CustomPair's generic element/value if found. Throws exception if failed. </returns>
        public TValue this[TKey key]
        {
            get
            {
                int index = Math.Abs(key.GetHashCode()) % myDict.Length;

                if (myDict[index] != null)
                {
                    for (int i = 0; i < myDict[index].Count; i++)
                    {
                        if (myDict[index][i].Key.Equals(key))
                        {
                            return myDict[index][i].Value;
                        }
                    }
                }

                throw new KeyNotFoundException("Error! Key not found in dictionary!");
            }

            set
            {
                int index = Math.Abs(key.GetHashCode()) % myDict.Length;

                if (myDict[index] == null)
                {
                    myDict[index] = new List<CustomPair<TKey, TValue>>();
                    myDict[index].Add(new CustomPair<TKey, TValue>(key, value));
                    count++;
                }

                else if (myDict[index] != null)
                {
                    for (int i = 0; i < myDict[index].Count; i++)
                    {
                        if (myDict[index][i].Key.Equals(key))
                        {
                            myDict[index][i] = new CustomPair<TKey, TValue>(key, value);
                            return;
                        }
                    }

                    myDict[index].Add(new CustomPair<TKey, TValue>(key, value));
                    count++;
                }
            }
        }

        /// <summary>
        /// Accepts a generic key value and checks whether or not a CustomPair object with that 
        /// key exists in the dictionary.
        /// </summary>
        /// <param name="key"> Generic key value to check whether it exists in the dictionary. </param>
        /// <returns> True if the object does exist. False otherwise. </returns>
        public bool ContainsKey(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % myDict.Length;

            if (myDict[index] != null)
            {
                for (int i = 0; i < myDict[index].Count; i++)
                {
                    if (myDict[index][i].Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Takes in a generic key and value and adds it appropriately within the dictionary,
        /// if possible (Throws exception if user attempts to use a key that already exists within
        /// the dictionary).
        /// </summary>
        /// <param name="key"> Generic key of the new object to be added. </param>
        /// <param name="value"> Generic value of the new object to be added. </param>
        public void Add(TKey key, TValue value)
        {
            int index = Math.Abs(key.GetHashCode()) % myDict.Length;

            if (myDict[index] == null)
            {
                myDict[index] = new List<CustomPair<TKey, TValue>>();
                myDict[index].Add(new CustomPair<TKey, TValue>(key, value));
                count++;
            }

            else if (ContainsKey(key))
            {
                throw new ArgumentException("Error! Key already in use!");
            }

            else
            {
                myDict[index].Add(new CustomPair<TKey, TValue>(key, value));
                count++; 
            }
            
        }

        /// <summary>
        /// Accepts a generic key value and deletes the associated object with said key if the 
        /// key exists in the dictionary. Also reduces count value.
        /// </summary>
        /// <param name="key"> Generic key value to check whether it exists in the dictionary and 
        ///                    can be deleted. </param>
        /// <returns> True if the object was removed. False otherwise. </returns>
        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % myDict.Length;

            if (myDict[index] != null)
            {
                for (int i = 0; i < myDict[index].Count; i++)
                {
                    if (myDict[index][i].Key.Equals(key))
                    {
                        myDict[index].RemoveAt(i);
                        count--;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Resets the dicitionary, clearing all elements and setting count to 0.
        /// </summary>
        public void Clear()
        {
            myDict = new List<CustomPair<TKey, TValue>>[myDict.Length];
            count = 0;
        }
    }
}
