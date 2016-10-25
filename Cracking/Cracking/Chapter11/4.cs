using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Imagine you have a 20 GB file with one string per line. Explain how you would
 * sort the file
 */
namespace Cracking.Chapter11
{
    /*
     * You would not be able to bring the entire file into memory, so the file would have to be sorted in chunks.
     * Merge sort would be a prime canidate for this problem, although some tweaking would be required since you
     * wouldn't be able to merge such a large file either, and would have to write-out as you are merging.
     * 
     * The general concept would be this:
     * 
     * 1) Read/break the file into managable chunks (~10MB), sort those lines using whatever O(nlogn) sorting algorithm, write out each chunk as a sorted file.
     * 2) Now take two sorted files and merge them. Read chunks of both files and merge them into one file. As you are merging you will need to continuously
     *    write out to (another) sorted file chunk. It does not matter which two chunks gets merged, since a sorted chunk merged with another sorted chunk will
     *    just result in a merged sorted chunk.
     * 3) When you are left with only one sorted file you are done.
     */
    class _4
    {
    }

    [TestClass]
    public class Tests_11_4
    {
        [TestMethod]
        public void Test() 
        {
        }
    }
}
