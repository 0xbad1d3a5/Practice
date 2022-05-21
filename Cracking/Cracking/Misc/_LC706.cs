using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Design a HashMap without using any built-in hash table libraries.

    Implement the MyHashMap class:

    MyHashMap() initializes the object with an empty map.
    void put(int key, int value) inserts a (key, value) pair into the HashMap. If the key already exists in the map, update the corresponding value.
    int get(int key) returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
    void remove(key) removes the key and its corresponding value if the map contains the mapping for the key.
 */
namespace Cracking.Misc
{
    class LC706
    {
        public class MyHashMap {

            int[] arr = new int[(int)1E6+1];

            public MyHashMap() {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = -1;
                }
            }
            
            public void Put(int key, int value) {
                arr[key] = value;
            }
            
            public int Get(int key) {
                return arr[key];
            }
            
            public void Remove(int key) {
                arr[key] = -1;
            }
        }
    }

    [TestClass]
    public class Tests_LC706
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
