class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None

class LLNode:
    def __init__(self, treenode):
        self.treenode = treenode 
        self.next = None

class ListList:
    def __init__(self, head):
        self.ListHead = head
        self.ListNext = None

def treeToListList(treenode, listlist):
    if treenode == None:
        return
    if listlist.ListNext == None:
        listlist.ListNext = ListList(None)
    u = LLNode(treenode)
    u.next = listlist.ListHead
    listlist.ListHead = u
    treeToListList(treenode.right, listlist.ListNext)
    treeToListList(treenode.left, listlist.ListNext)

def treeToListListP(treenode, ll, depth):
    if treenode == None:
        return
    if len(ll) <= depth:
        ll.append([])
    ll[depth].append(treenode)
    treeToListListP(treenode.left, ll, depth+1)
    treeToListListP(treenode.right, ll, depth+1)

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

    ll = []
    treeToListListP(n, ll, 0)
    for l in ll:
        for n in l:
            print n.val,
        print ""
    
    """
    while ll != None:
        lln = ll.ListHead
        while lln != None:
            print lln.treenode.val,
            lln = lln.next
        print ""
        ll = ll.ListNext
        """
