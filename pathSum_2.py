# Definition for a  binary tree node
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:

    def pSum(self, node, node_list, result_list, curr_sum, total_sum):
        if node:
            # leaf node
            if node.left == None and node.right == None:
                if curr_sum + node.val == total_sum:
                    result_list.append([n.val for n in node_list + [node]])

            node_list.append(node)
            self.pSum(node.left, node_list, result_list, curr_sum + node.val, total_sum)
            self.pSum(node.right, node_list, result_list, curr_sum + node.val, total_sum)
            if node_list:
                node_list.pop()

    # @param root, a tree node
    # @param sum, an integer
    # @return a list of lists of integers
    def pathSum(self, root, sum):
        result_list = []
        self.pSum(root, [], result_list, 0, sum)
        return result_list

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
    n.right = TreeNode(0)
    n.left.left = TreeNode(3)
    n.left.right = TreeNode(4)
    n.right.left = TreeNode(5)
    n.right.right = TreeNode(6)
    n.right.right.right = TreeNode(7)

    s = Solution()
    print s.pathSum(n, 5)
