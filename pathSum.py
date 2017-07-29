# Definition for a  binary tree node
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:

    def pSum(self, node, curr_sum, total_sum):
        if node:
            # we are at a leaf node
            if node.left == None and node.right == None:
                if curr_sum + node.val == total_sum:
                    return True
                else:
                    return False
        
            L = self.pSum(node.left, curr_sum + node.val, total_sum)
            R = self.pSum(node.right, curr_sum + node.val, total_sum)
            if L or R:
                return True
            else:
                return False
    
    # @param root, a tree node
    # @param sum, an integer
    # @return a boolean
    def hasPathSum(self, root, sum):
        return self.pSum(root, 0, sum)

if __name__ == "__main__":
    
    #      0
    #    /   \
    #   1     2
    #  / \   / \
    # 3  4   5  6
    #            \
    #             7
    n = TreeNode(0)
    n.left = TreeNode(1)
    n.right = TreeNode(2)
    n.left.left = TreeNode(3)
    n.left.right = TreeNode(4)
    n.right.left = TreeNode(5)
    n.right.right = TreeNode(6)
    n.right.right.right = TreeNode(7)

    s = Solution()
    print s.hasPathSum(None, 8)
