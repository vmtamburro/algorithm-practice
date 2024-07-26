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
}