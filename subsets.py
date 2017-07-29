class Solution:
    # @param S, a list of integer
    # @return a list of lists of integer
    def subsets(self, S):
        subsets = []
        for s in S:
            temp_subsets = []
            for e in subsets:
                temp_subsets.append(sorted(e + [s]))
            subsets += temp_subsets
            subsets.append([s])
        return sorted([[]] + subsets, key=lambda x:len(x))

if __name__ == "__main__":
    
    s = Solution()
    print s.subsets([4, 1, 0])
