namespace ArraysAndStrings
{
    // Implement a Priority Queue with push and pop methods
    // I'll implement the priority Queue with Min-Heap
    // 3, 4, 5
    // [3, 4, 5, 0, 0, 0]
    //     ^
    // We're gonna implement our Heap using Array
    // At our array the children of index 0 are at index 1 and 2. 
    // 0 -> 1, 2
    // 1 -> 3, 4
    // 2 -> 5, 6
    // So we can compute what are the children of an index and also what is the parent of a given index (subtract by 1 and divide by 2)
    public class PriorityQueue
    {
        public int[] Heap { get; set; }
        int HeapSize { get; set; }

        public PriorityQueue(int maxSize)
        {
            Heap = new int[maxSize];
            HeapSize = 0;
        }

        public void Push(int value)
        {
            if (HeapSize == Heap.Length) throw new Exception();

            int pos = HeapSize;
            Heap[pos] = value;

            while (pos > 0)
            {
                int parent = (pos - 1) / 2;

                if (Heap[parent] <= Heap[pos]) break;

                swapIndices(parent, pos);

                pos = parent;
            }

            HeapSize++;
        }

        public int Pop()
        {
            if (HeapSize == 0) throw new Exception();

            int toReturn = Heap[0];

            Heap[0] = Heap[HeapSize - 1];
            Heap[HeapSize - 1] = 0;

            HeapSize--;

            int pos = 0;

            while (pos < HeapSize / 2)
            {
                int leftChild = pos * 2 + 1;
                int rightChild = leftChild + 1;

                if (rightChild < HeapSize && Heap[rightChild] < Heap[leftChild])
                {
                    if (Heap[pos] <= Heap[rightChild]) break;

                    swapIndices(pos, rightChild);
                    pos = rightChild;
                }
                else
                {
                    if (Heap[pos] <= Heap[leftChild]) break;

                    swapIndices(pos, leftChild);
                    pos = leftChild;
                }
            }          

            return toReturn;
        }

        private void swapIndices(int i, int j)
        {
            int temp = Heap[i];
            Heap[i] = Heap[j];
            Heap[j] = temp;
        }
    }
}
