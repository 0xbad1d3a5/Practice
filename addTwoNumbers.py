# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    # @return a ListNode
    def addTwoNumbers(self, l1, l2):
        head = None
        curr = head
        carry = 0
        while l1 != None or l2 != None or carry:
            # Compute the value of the node
            if l1 and l2:
                value = l1.val + l2.val + carry
                l1 = l1.next
                l2 = l2.next
            elif l1:
                value = l1.val + carry
                l1 = l1.next
            elif l2:
                value = l2.val + carry
                l2 = l2.next
            else:
                value = carry
                
            # Create the new node with value
            new_node = ListNode(value % 10)
            if head:
                curr.next = new_node
                curr = curr.next
            else:
                head = new_node
                curr = head
            
            # Assign or reset the carry
            if value >= 10:
                carry = 1
            else:
                carry = 0
                
        return head

if __name__ == "__main__":
    
    s = Solution()
    l1 = ListNode(1)
    l2 = ListNode(2)
    print s.addTwoNumbers(l1, l2).val
