public class CountSquares {

    private Dictionary<(int X, int Y), int> points;

    public CountSquares() {
        points = new();
    }
    
    public void Add(int[] point) {
        var pos = (point[0], point[1]);
        points[pos] = points.ContainsKey(pos) ? points[pos] + 1 : 1;
    }
    
    public int Count(int[] points) {
        // a b
        // c d

        // for any given axis aligned square, abs(a - d) = abs(b - c) = abs(a - c) = abs(b - d)
        // if we find b and c, or a and d we can calculate the other 2 points and check if they exist
        // then the number of combinations that can be made is the frequency of those 2 points multiplied

        var c = 0;
        foreach (var (pos, count) in this.points)
        {
            var (otherX, otherY) = pos;
            var xDiff = points[0] - otherX;
            var yDiff = points[1] - otherY;

            if (xDiff != 0 && Math.Abs(xDiff) == Math.Abs(yDiff))
            {
                // Check if we can make a square with 2 extra points
                var p3 = (points[0], otherY);
                var p4 = (otherX, points[1]);

                if (!this.points.ContainsKey(p3) || !this.points.ContainsKey(p4)) continue;

                c += this.points[pos] * this.points[p3] * this.points[p4];
            }
        }

        return c;
    }
}
