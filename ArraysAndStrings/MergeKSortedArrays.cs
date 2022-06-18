namespace ArraysAndStrings
{
    // Given K sorted arrays, merge them into a single sorted array.
    // eg. merge({{1, 4, 7}, {2, 5, 8}, {3, 6, 9}})
    // {1, 4, 7}
    // {2, 5, 8}
    // {3, 6, 9}
    // Priority Queue, Add an element to a priority queue will take LogN time.
    // And the priority queue will always going to be length k. 
    // And removing from the priority queue takes constant time.
    // Min-Heap 
    public class MergeKSortedArrays
    {
        // we're defining a class to have 3 fields: Array number, Index in the array and the Value of that index in that array 
        private class QueueNode
        {
            public int Array { get; set; }
            public int Index { get; set; }
            public int Value { get; set; }

            public QueueNode(int array, int index, int value)
            {
                Array = array;
                Index = index;
                Value = value;
            }
        }

        public static int[] merge(int[,] arrays)
        {
            // Using built-in Priority Queue class in C#
            // Priority Queue of QueueNode element and its priority(value in each array because it's sorted)
            PriorityQueue<QueueNode, int> pq = new PriorityQueue<QueueNode, int>();

            int resultSize = 0;

            // find the size of result array and initialize the Priority Queue with numbers at index 0 in each array
            // arrays.GetLength(0) will give us the number of arrays in that 2D Array: [3,4] = 3
            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                // arrays.GetLength(1) will give us the size of each array in the 2D Array: [3,4] = 4
                resultSize += arrays.GetLength(1);

                pq.Enqueue(new QueueNode(i, 0, arrays[i, 0]), arrays[i, 0]);
            }

            // defining the result array
            int[] result = new int[resultSize];

            for (int i = 0; pq.Count != 0; i++)
            {
                // every time we remove the min number in the priority queue
                QueueNode n = pq.Dequeue();

                result[i] = n.Value;

                // increment the index in the nodes array
                int newIndex = n.Index + 1;

                if (newIndex < arrays.GetLength(1))
                {
                    pq.Enqueue(new QueueNode(n.Array, newIndex, arrays[n.Array, newIndex]), arrays[n.Array, newIndex]);
                }
            }

            return result;
        }
    }
}
