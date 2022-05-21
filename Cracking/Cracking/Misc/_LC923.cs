using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Given an integer array arr, and an integer target, return the number of tuples i, j, k such that i < j < k and arr[i] + arr[j] + arr[k] == target. 
   As the answer can be very large, return it modulo 109 + 7.
 */
namespace Cracking.Misc
{
    class LC923
    {
        /*
            - First, sort the array
            - The turn the 3-sum problem into the 2-sum problem by iterating through the array once and taking the difference
            - For the inner loop, use two pointers to find 2 numbers from both ends that match target number
                - The reduction of runtime comes from the fact the array is now sorted and thus finding 2 numbers
                  that equal T from both ends is more efficient
        */
        public static int ThreeSumMulti(int[] arr, int target) {
            int MOD = 1_000_000_007;
            int ans = 0;
            Array.Sort(arr);

            // Turn the problem from 3-sum into two sum
            for (int i = 0; i < arr.Length; i++)
            {
                int T = target - arr[i];
                int j = i + 1;
                int k = arr.Length - 1;

                // This is effectively 2-sum
                // However, do note that there are duplicate numbers allowed
                while (j < k) // careful not to use != here - they might not "meetup" and cross over
                {
                    if (arr[j] + arr[k] < T)
                    {
                        j++;
                    }
                    else if (arr[j] + arr[k] > T)
                    { 
                        k--;
                    }
                    // Because of duplicate numbers, we need to count each time both pointers
                    // give a value of T from duplicate [j, j, j, ... k, k] values
                    else if (arr[j] != arr[k])
                    {
                        int numSameJ = 1;
                        while (arr[j] == arr[j + 1])
                        {
                            j++;
                            numSameJ++;
                        }
                        j++;

                        int numSameK = 1;
                        while (arr[k] == arr[k - 1])
                        {
                            k--;
                            numSameK++;
                        }
                        k--;

                        ans += numSameJ * numSameK;
                        ans %= MOD;
                    }
                    // if arr[j] == arr[k], we don't want to double count
                    // remember, each index from arr needs to be unique
                    // therefore, n choose 2, where n is the # dup values
                    // this simplifies to n * (n-1) / 2
                    else {
                        ans += (k - j + 1) * (k - j) / 2;
                        ans %= MOD;
                        break;
                    }
                }
            }

            return ans;
        }
    }

    [TestClass]
    public class Tests_LC923
    {
        [TestMethod]
        public void Test()
        {
            LC923.ThreeSumMulti(new int[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5}, 8);
        }
    }

    /*
Approach 2: Counting with Cases

Let count[x] be the number of times that x occurs in A. For every x+y+z == target, we can try to count the correct contribution to the answer. There are a few cases:

If x, y, and z are all different, then the contribution is count[x] * count[y] * count[z].

If x == y != z, the contribution is \binom{\text{count[x]}}{2} * \text{count[z]}( 
2
count[x]
​
 )∗count[z].

If x != y == z, the contribution is \text{count[x]} * \binom{\text{count[y]}}{2}count[x]∗( 
2
count[y]
​
 ).

If x == y == z, the contribution is \binom{\text{count[x]}}{3}( 
3
count[x]
​
 ).

(Here, \binom{n}{k}( 
k
n
​
 ) denotes the binomial coefficient \frac{n!}{(n-k)!k!} 
(n−k)!k!
n!
​
 .)

Each case is commented in the implementations below.

class Solution(object):
    def threeSumMulti(self, A, target):
        MOD = 10**9 + 7
        count = [0] * 101
        for x in A:
            count[x] += 1

        ans = 0

        # All different
        for x in xrange(101):
            for y in xrange(x+1, 101):
                z = target - x - y
                if y < z <= 100:
                    ans += count[x] * count[y] * count[z]
                    ans %= MOD

        # x == y
        for x in xrange(101):
            z = target - 2*x
            if x < z <= 100:
                ans += count[x] * (count[x] - 1) / 2 * count[z]
                ans %= MOD

        # y == z
        for x in xrange(101):
            if (target - x) % 2 == 0:
                y = (target - x) / 2
                if x < y <= 100:
                    ans += count[x] * count[y] * (count[y] - 1) / 2
                    ans %= MOD

        # x == y == z
        if target % 3 == 0:
            x = target / 3
            if 0 <= x <= 100:
                ans += count[x] * (count[x] - 1) * (count[x] - 2) / 6
                ans %= MOD

        return ans

Approach 3: Adapt from Three Sum

As in Approach 2, let count[x] be the number of times that x occurs in A. Also, let keys be a sorted list of unique values of A. We will try to adapt a 3Sum algorithm to work on keys, but add the correct answer contributions.

For example, if A = [1,1,2,2,3,3,4,4,5,5] and target = 8, then keys = [1,2,3,4,5]. When doing 3Sum on keys (with i <= j <= k), we will encounter some tuples that sum to the target, like (x,y,z) = (1,2,5), (1,3,4), (2,2,4), (2,3,3). We can then use count to calculate how many such tuples there are in each case.

class Solution(object):
    def threeSumMulti(self, A, target):
        MOD = 10**9 + 7
        count = collections.Counter(A)
        keys = sorted(count)

        ans = 0

        # Now, let's do a 3sum on "keys", for i <= j <= k.
        # We will use count to add the correct contribution to ans.
        for i, x in enumerate(keys):
            T = target - x
            j, k = i, len(keys) - 1
            while j <= k:
                y, z = keys[j], keys[k]
                if y + z < T:
                    j += 1
                elif y + z > T:
                    k -= 1
                else: # x+y+z == T, now calculate the size of the contribution
                    if i < j < k:
                        ans += count[x] * count[y] * count[z]
                    elif i == j < k:
                        ans += count[x] * (count[x] - 1) / 2 * count[z]
                    elif i < j == k:
                        ans += count[x] * count[y] * (count[y] - 1) / 2
                    else:  # i == j == k
                        ans += count[x] * (count[x] - 1) * (count[x] - 2) / 6

                    j += 1
                    k -= 1

        return ans % MOD
    */
}
