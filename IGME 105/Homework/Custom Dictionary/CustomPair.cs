// Conor Race
// Nov. 17th, 2021
// Purpose: Allows for the creation of CustomPair objects, which
// allows for a generic element and a generic keyword.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Dictionary
{
    class CustomPair<TKey,TValue>
    {
        private TKey key;
        private TValue value;

        /// <summary>
        /// Constructor for CustomPair class. Accepts a generic element and a generic key
        /// and combines them into one object. Specially made for dictionaries.
        /// </summary>
        /// <param name="key"> Generic key for the object. </param>
        /// <param name="value"> Generic element for the object. </param>
        public CustomPair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        /// <summary>
        /// Generic property; Allows for the retrieval and setting of generic key values.
        /// </summary>
        public TKey Key { get { return key; } set { key = value; } }

        /// <summary>
        /// Generic property; Allows for the retrieval and setting of generic element values.
        /// </summary>
        public TValue Value { get { return value; } set { this.value = value; } }
    }
}
