public class RandoPractice_Queues{
    public class ArrayQueue{
        private int[] items;
        private int front;
        private int rear;
        private int maxSize;

        private int count;

        public ArrayQueue(int size){
            maxSize = size;
            items = new int[maxSize];
            front = 0;
            rear = -1;
            count = 0;
        }

        public void Enqueue(int value){
            if(count == maxSize){
                throw new InvalidOperationException("Queue is full");
            }

            rear = (rear + 1) % maxSize;
            items[rear] = value;
            count++;
        }

        public int Dequeue(){
            if(count == 0){
                throw new InvalidOperationException("Queue is empty");
            }

            int value = items[front];
            front = (front + 1) % maxSize;
            count--;

            return value;
        }

        public int Peek(){
            if(count == 0){
                throw new InvalidOperationException("Queue is empty");
            }

            return items[front];
        }
    }

    public class ListNode{
        public int Value;
        public ListNode Next;

        public ListNode(int value){
            Value = value;
            Next = null;
        }
    }

    public class LinkedListQueue{
        private ListNode front;
        private ListNode rear;

        public LinkedListQueue(){
            front = null;
            rear = null;
        }

        public void Enqueue(int value){
            ListNode newNode = new ListNode(value);

            if(rear == null){
                front = newNode;
                rear = newNode;
            }else{
                rear.Next = newNode;
                rear = newNode;
            }
        }

        public int Dequeue(){
            if(front == null){
                throw new InvalidOperationException("Queue is empty");
            }

            int value = front.Value;
            front = front.Next;

            if(front == null){
                rear = null;
            }

            return value;
        }

        public int Peek(){
            if(front == null){
                throw new InvalidOperationException("Queue is empty");
            }

            return front.Value;
        }
    }


    public class PriorityQueue{
        private List<int> heap = new List<int>();
        private void Swap(int i, int j){
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private void HeapifyUp(int index){
            if (index == 0)
            {
                return;
            }

            int parent = (index - 1) / 2; // Find parent index  
            if(index > 0 && heap[index] > heap[parent]){
                Swap(index, parent);
                HeapifyUp(parent);
            }   
        }

        private void HeapifyDown(int index){
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;
            if(leftChild < heap.Count && heap[leftChild] > heap[smallest]){
                smallest = leftChild;
            }

            if(rightChild < heap.Count && heap[rightChild] > heap[smallest]){
                smallest = rightChild;
            }

            if(smallest != index){
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        public void Enqueue(int value){
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        public int Dequeue(){
            if(heap.Count == 0){
                throw new InvalidOperationException("Queue is empty");
            }

            int value = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return value;
        }

        public int Peek(){
            if(heap.Count == 0){
                throw new InvalidOperationException("Queue is empty");
            }

            return heap[0];
        }

        public bool IsEmpty(){
            return heap.Count == 0;
        }
    }
}