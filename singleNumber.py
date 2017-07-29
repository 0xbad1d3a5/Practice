class Solution:
    # @param A, a list of integer
    # @return an integer
    def singleNumber(self, A):
        if A:
            num = A[0]
            for a in A[1:]:
                num = num ^ a
            return num
        else:
            return 0

if __name__ == "__main__":
    
    s = Solution()
    print s.singleNumber([1, 2, 1])
