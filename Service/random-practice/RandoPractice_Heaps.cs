public class RandoPractice_Heaps
{
    public class MinHeap
    {
        private int[] heap;
        private int size;
        private int capacity;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            heap = new int[capacity];
            size = 0;
        }

        private int Parent(int i) => (i - 1) / 2;
        private int LeftChild(int i) => 2 * i + 1;
        private int RightChild(int i) => 2 * i + 2;

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public void Insert(int key)
        {
            if (size == capacity)
                throw new InvalidOperationException("Heap is full");

            size++;
            int i = size - 1;
            heap[i] = key;

            while (i != 0 && heap[Parent(i)] > heap[i])
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public int ExtractMin()
        {
            if (size <= 0)
                throw new InvalidOperationException("Heap is empty");

            if (size == 1)
            {
                size--;
                return heap[0];
            }

            int root = heap[0];
            heap[0] = heap[size - 1];
            size--;
            MinHeapify(0);

            return root;
        }

        private void MinHeapify(int i)
        {
            int l = LeftChild(i);
            int r = RightChild(i);
            int smallest = i;

            if (l < size && heap[l] < heap[smallest])
                smallest = l;
            if (r < size && heap[r] < heap[smallest])
                smallest = r;

            if (smallest != i)
            {
                Swap(i, smallest);
                MinHeapify(smallest);
            }
        }
    }


public class MaxHeap
{
    private int[] heap;
    private int size;
    private int capacity;

    public MaxHeap(int capacity)
    {
        this.capacity = capacity;
        heap = new int[capacity];
        size = 0;
    }

    private int Parent(int i) => (i - 1) / 2;
    private int LeftChild(int i) => 2 * i + 1;
    private int RightChild(int i) => 2 * i + 2;

    private void Swap(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    public void Insert(int key)
    {
        if (size == capacity)
            throw new InvalidOperationException("Heap is full");

        size++;
        int i = size - 1;
        heap[i] = key;

        while (i != 0 && heap[Parent(i)] < heap[i])
        {
            Swap(i, Parent(i));
            i = Parent(i);
        }
    }

    public int ExtractMax()
    {
        if (size <= 0)
            throw new InvalidOperationException("Heap is empty");

        if (size == 1)
        {
            size--;
            return heap[0];
        }

        int root = heap[0];
        heap[0] = heap[size - 1];
        size--;
        MaxHeapify(0);

        return root;
    }

    private void MaxHeapify(int i)
    {
        int l = LeftChild(i);
        int r = RightChild(i);
        int largest = i;

        if (l < size && heap[l] > heap[largest])
            largest = l;
        if (r < size && heap[r] > heap[largest])
            largest = r;

        if (largest != i)
        {
            Swap(i, largest);
            MaxHeapify(largest);
        }
    }
}
}