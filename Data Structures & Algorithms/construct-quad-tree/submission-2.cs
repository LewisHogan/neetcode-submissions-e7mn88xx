/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    public Node Construct(int[][] grid) {
        var root = Construct(grid, (0, 0), (grid.Length, grid[0].Length));
        return root;
    }

    Node Construct(int[][] grid, (int, int) min, (int, int) max)
    {
        var (minRow, minCol) = min;
        var (maxRow, maxCol) = max;

        var isLeafNode = true;

        var prev = grid[minRow][minCol];
        for (var row = minRow; row < maxRow; row++)
        {
            for (var col = minCol; col < maxCol; col++)
            {
                if (grid[row][col] != prev)
                {
                    isLeafNode = false;
                    break;
                }
            }

            if (!isLeafNode) break;
        }

        if (!isLeafNode)
        {
            var midRow = minRow + (maxRow - minRow) / 2;
            var midCol = minCol + (maxCol - minCol) / 2;

            var topLeft = Construct(grid, (minRow, minCol), (midRow, midCol));
            var topRight = Construct(grid, (minRow, midCol), (midRow, maxCol));
            var bottomLeft = Construct(grid, (midRow, minCol), (maxRow, midCol));
            var bottomRight = Construct(grid, (midRow, midCol), max);

            return new Node(false, isLeafNode, topLeft, topRight, bottomLeft, bottomRight);
        }
        else
        {
            return new Node(prev == 1, isLeafNode);
        }
    }
}