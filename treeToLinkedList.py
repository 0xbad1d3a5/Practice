class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None

def rightMostElement(node):
    if node and not node.right:
        return node
    return rightMostElement(node.right)

def leftMostElement(node):
    if node:
        if node.left == None:
            return node
        else:
            return leftMostElement(node.left)

def inOrder(node):
    head = leftMostElement(node)
    if node:
        if node.left or node.right:
            left = node.left
            right = node.right
            if left:
                rightMostElement(left).right = node
            if right:
                node.right = leftMostElement(right)
            inOrder(left)
            inOrder(right)
    return head

if __name__ == "__main__":
    
    #      0
    #    /   \
    #   1     2
    #  / \   / \
    # 3  4   5  6
    n = Node(0)
    n.left = Node(1)
    n.right = Node(2)
    n.left.left = Node(3)
    n.left.right = Node(4)
    n.right.left = Node(5)
    n.right.right = Node(6)
    
    inOrder(n)
