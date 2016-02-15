class Solution:
    # @return an integer
    def lengthOfLongestSubstring(self, string):

        # hashtable for holding last-seen character value
        d = {}
        # max length substring seen so far
        result = 0
        # current index in string
        start = -1

        # iterate through the string
        for index, char in enumerate(string):
            # if the char is in d, then we set the start of substring
            # also if the d[char] is greater than start or we'll go backwards
            if char in d and d[char] > start:
                start = d[char]
            # update where we seen characters
            d[char] = index

            # result would be what's bigger - last seen substring or current
            result = max(result, index - start)
        return result

if __name__ == "__main__":
    
    s = Solution()
    print s.lengthOfLongestSubstring("abba")
