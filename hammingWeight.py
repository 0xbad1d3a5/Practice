class Solution:
    # @param n, an integer
    # @return an integer
    def hammingWeight(self, n):
        count = 0
        for i in range(32):
            if n & 1:
                count += 1
            n = n >> 1
        return count

if __name__ == "__main__":
    
    s = Solution()
    print s.hammingWeight(3)
