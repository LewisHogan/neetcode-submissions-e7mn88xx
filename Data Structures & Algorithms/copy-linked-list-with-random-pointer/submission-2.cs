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
        if (head == null) return null;
        
        var map = new Dictionary<Node, Node>();        

        var current = head;
        while (current != null) {
            if (!map.ContainsKey(current)) {
                map[current] = new Node(current.val);
            }

            if (current.next != null && !map.ContainsKey(current.next)) {
                map[current.next] = new Node(current.next.val);
            }

            if (current.random != null && !map.ContainsKey(current.random)) {
                map[current.random] = new Node(current.random.val);
            }

            map[current].next = current.next != null ? map[current.next] : null;
            map[current].random = current.random != null ? map[current.random] : null;

            current = current.next;
        }

        return map[head];
    }
}
