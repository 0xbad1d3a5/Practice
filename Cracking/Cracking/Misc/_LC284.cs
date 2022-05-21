using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Design an iterator that supports the peek operation on an existing iterator in addition to the hasNext and the next operations.

    Implement the PeekingIterator class:

    PeekingIterator(Iterator<int> nums) Initializes the object with the given integer iterator iterator.
    int next() Returns the next element in the array and moves the pointer to the next element.
    boolean hasNext() Returns true if there are still elements in the array.
    int peek() Returns the next element in the array without moving the pointer.
    Note: Each language may have a different implementation of the constructor and Iterator, but they all support the int next() and boolean hasNext() functions.
 */
namespace Cracking.Misc
{
    class LC284
    {
        class PeekingIterator {

            IEnumerator<int> pIterator;
            bool hasNext;
            int current;

            public PeekingIterator(IEnumerator<int> iterator) {
                pIterator = iterator;
                hasNext = true;
                current = iterator.Current;
            }
            
            // Returns the next element in the iteration without advancing the iterator.
            public int Peek() {
                return pIterator.Current;
            }
            
            // Returns the next element in the iteration and advances the iterator.
            public int Next() 
            {
                current = pIterator.Current;

                if (!pIterator.MoveNext())
                {
                    hasNext = false;
                }

                return current;
            }
            
            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext() {
                return hasNext;
            }
        }
    }

    [TestClass]
    public class Tests_LC284
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
