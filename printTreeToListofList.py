class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None

# appends all nodes on a single level to a list
def preOrderLevelList(node, l, level):
    if node != None:
        if level == 0:
            l.append(node)
        else:
            preOrderLevelList(node.left, l, level-1)
            preOrderLevelList(node.right, l, level-1)
    return l

# creates a list of lists from the levels of a tree
def treeToListofList(node):
    count = 0
    result = []
    while True:
        l = preOrderLevelList(node, [], count)
        if l:
            result.append(l)
            count += 1
        else:
            break
    return result

if __name__ == "__main__":

    #      0
    #    /   \
    #   1     2
    #  / \   / \
    # 3  4   5  6
    #            \
    #             7
    n = Node(0)
    n.left = Node(1)
    n.right = Node(2)
    n.left.left = Node(3)
    n.left.right = Node(4)
    n.right.left = Node(5)
    n.right.right = Node(6)
    n.right.right.right = Node(7)

    lists_of_lists = treeToListofList(n)
    print lists_of_lists
    for one_list in lists_of_lists:
        for node in one_list:
            print node.val,
        print ""
