using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a circular linked list, implement an algorithm which returns the node at
 * the beginning of the loop.
 * DEFINITION
 * Circular linked list: A (corrupt) linked list in which a node's next pointer points
 * to an earlier node, so as to make a loop in the linked list.
 * EXAMPLE
 * Input: A - > B - > C - > D - > E - > C [the same C as earlier]
 * Output: C
 */
namespace Cracking.Chapter02
{
    class _6
    {
        /* 
         * ! - Exclamation point denotes collision point
         * [A!] -> B -> C -> [A]                     | collision point 0 away from beginning of loop A
         * BEFORE LOOP (empty)
         * A -> [B] -> C -> D! -> [B]                | collision point 1 away from beginning of loop B
         * - BEFORE LOOP size = 1
         * A -> B -> [C] -> D! -> E -> [C]           | collision point 2 away from beginning of loop C
         * ------ BEFORE LOOP size = 2
         * A -> B -> C -> [D!] -> E -> F -> [D]      | collision point 0 away from beginning of loop D
         * ----------- BEFORE LOOP size = 3
         * A -> B -> C -> D -> [E] -> F -> G! -> [E] | collision point 1 away from beginning of loop E
         * ---------------- BEFORE LOOP size = 4
         * 
         * We can then essentially deduce BEFORE_LOOP % LOOP_SIZE = how far the collision away is from the beginning.
         * Since we know there must be a loop, BEFORE LOOP must be a multiple of how far away the collision point is from the beginning of the loop (or the collision point would be in a different spot).
         * Then we can simply run a pointer from BEFORE LOOP and then continue a pointer from collision point, and the place they collide is the beginning of the loop.
         * 
         * More formally: when the slower pointer takes k steps, the faster pointer will have taken 2k steps. Therefore, the collision would have happened at 2k - k (or k steps).
         * When the slower pointer is 0 steps into the loop, the faster pointer will be k % LOOP_SIZE (K from now on) steps into the loop.
         * The slower pointer is thus LOOP_SIZE - K distance from the faster pointer.
         * Since both pointers are now in a circle, the faster pointer will approach the slower pointer at a rate of 1 node per step.
         * Since K is just k % LOOP_SIZE, another pointer sent from the beginning of the list will collide with a pointer resumed from the start of the list, as both are K away from the beginning of the list.
         * 
         */
        public static Node BeginningOfLoop(Node head)
        {
            Node p1 = head; // step by 1
            Node p2 = head; // step by 2

            do
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }
            while (p1 != p2); // This is where they collide

            p2 = head; // Move to start of list, now move by 1
            while (p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p1;
        }
    }

    [TestClass]
    public class Tests_02_6
    {
        [TestMethod]
        public void Test()
        {
            Node A = new Node(1);
            Node B = new Node(2);
            Node C = new Node(3);
            Node D = new Node(4);
            Node E = new Node(5);
            Node F = new Node(6);

            A.next = B;
            B.next = C;
            C.next = D;
            D.next = E;
            E.next = F;
            F.next = D;

            Node result = _6.BeginningOfLoop(A);
        }
    }
}
