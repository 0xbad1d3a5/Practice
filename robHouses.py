class Solution:
    # @param num, a list of integer
    # @return an integer
    def rob(self, num):
        return sum(num[::2]) if sum(num[::2]) > sum(num[1::2]) else sum(num[1::2])

if __name__ == "__main__":
    
    s = Solution()
    print s.rob([1, 2, 3, 4, 5, 6])
