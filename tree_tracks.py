class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None
        
# has bug
def print_tracks(curr, l, sum_val, val):
    
    if curr:

        if sum_val == val:
            print [x.val for x in l]
        else:
            if curr.left:
                print_tracks(curr.left, l + [curr.left], sum_val + curr.left.val, val)
                print_tracks(l[0].left, [l[0].left], l[0].left.val, val)
            if curr.right:
                print_tracks(curr.right, l + [curr.right], sum_val + curr.right.val, val)
                print_tracks(l[0].right, [l[0].right], l[0].right.val, val)

# don't have bug
def p_tracks(curr, l, sum_val, val):
    
    if curr:
        l = l + [curr]
        s = sum_val + curr.val
        if s == val:
            print [x.val for x in l]
         else:
            p_tracks(curr.left, l, s, val)
            p_tracks(curr.right, l, s, val)

            p_tracks(curr.left, [], 0, val)
            p_tracks(curr.right, [], 0, val)

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

    #print_tracks(n, [n], n.val, 5)
    p_tracks(n, [], 0, 5)
