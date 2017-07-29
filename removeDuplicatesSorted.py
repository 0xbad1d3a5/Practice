class Solution:
    
    def swap(self, A, i, j):
        temp = A[j]
        A[j] = A[i]
        A[i] = temp

    # @param a list of integers
    # @return an integer
    def removeDuplicates(self, A):
        if not A:
            return 0

        i = 0
        j = 0
        while j != len(A):
            if A[i] != A[j]:
                i += 1
                self.swap(A, i, j)
                j += 1
            else:
                j += 1

        return i + 1

if __name__ == "__main__":

    s = Solution()
    print s.removeDuplicates([1, 2, 3, 4, 4, 4, 4])
