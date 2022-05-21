using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Design a HashSet without using any built-in hash table libraries.

    Implement MyHashSet class:

    void add(key) Inserts the value key into the HashSet.
    bool contains(key) Returns whether the value key exists in the HashSet or not.
    void remove(key) Removes the value key in the HashSet. If key does not exist in the HashSet, do nothing.
 */
namespace Cracking.Misc
{
    class LC705
    {
        public class MyHashSet {

            bool[] arr = new bool[(int)1E6+1];

            public MyHashSet() {
                
            }
            
            public void Add(int key) {
                arr[key] = true;
            }
            
            public void Remove(int key) {
                arr[key] = false;
            }
            
            public bool Contains(int key) {
                return arr[key];   
            }
        }
    }

    [TestClass]
    public class Tests_LC705
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
