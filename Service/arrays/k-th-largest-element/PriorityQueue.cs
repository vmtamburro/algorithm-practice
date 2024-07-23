public class PriorityQueue{
    public int FindKthLargest(int[] nums, int k){
        // Create a min heap
        SortedSet<int> minHeap = new SortedSet<int>();
        
        foreach(int num in nums){
            minHeap.Add(num);
            if(minHeap.Count > k){
                minHeap.Remove(minHeap.Min);
            }
        }
        
        return minHeap.Min;
    }

    public int FindKthLargestFromScratch(int[] nums, int k){
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach(var num in nums){
            minHeap.Enqueue(num, num);
            if(minHeap.Count > k){
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}