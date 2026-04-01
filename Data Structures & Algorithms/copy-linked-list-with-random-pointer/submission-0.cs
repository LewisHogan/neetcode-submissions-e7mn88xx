/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        // Iterate over the nodes
        // work out their indicies and store them in a dictionary <Node, int>
        // when we do another pass, create new nodes and leave the indices in the random slot
        // then another pass where we link them all up

        if (head == null) return null;

        var i = 0;
        var nodeMap = new Dictionary<Node, int>();
        var copyMap = new Dictionary<int, Node>();
        var current = head;
        while (current != null) {
            nodeMap[current] = i;
            copyMap[i++] = new Node(current.val);
            current = current.next;
        }

        current = head;
        i = 0;
        while (current != null) {
            copyMap[i].next = copyMap.ContainsKey(i + 1) ? copyMap[i + 1] : null;

            if (current.random != null) {
                var randomNodeIndex = nodeMap[current.random];
                copyMap[i].random = copyMap[randomNodeIndex];
            }
            
            current = current.next;
            i++;
        }

        return copyMap[0];
    }
}
