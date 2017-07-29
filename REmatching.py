class Solution:
    
    def buildStateMachine(self, pattern):
        head = ["START", []]
        curr = head
        for char in pattern:
            if char == "*":
                curr[1].append(curr)
            else:
                temp = [char, []]
                curr[1].append(temp)
                curr = temp
        curr.append(["END", []])
        return head

    # @return a boolean
    def isMatch(self, s, p):
        s_index = 0
        p_index = 0
        p_prev = -1

        s_len = len(s)
        p_len = len(p)

        for char in s:
            if s[s_index] == p[p_index] or p[p_index] == '.':
                s_index += 1
                p_index += 1
                p_prev += 1

if __name__ == "__main__":

    s = Solution()
    
    print s.buildStateMachine(".*abc")
