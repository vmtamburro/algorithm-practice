public class KClosestPoints{
    /* 
        Return a certain number of points that are closest to the origin (0, 0) from a list of points.
        - The distance between two points on a plane is the Euclidean distance.
        - The Euclidean distance between two points p1 and p2 is the square root of the sum of the squares of the differences between the x-coordinates and y-coordinates of the two points.
        - The distance between two points p1 and p2 = sqrt((p1.x - p2.x)^2 + (p1.y - p2.y)^2)
    */
    public class Ordered{
        public double value {get; set;}
        public int[] point {get; set;}
    }
    
    public int[][] KClosest(int[][] points, int k) {
       var pointsObj = points.Select(p => new Ordered{value = Math.Sqrt(Math.Pow(p[0], 2) + Math.Pow(p[1], 2)), point = p}).ToArray(); 
       return pointsObj.OrderBy(p => p.value).Take(k).Select(p => p.point).ToArray();
    }
}