namespace DataStructures
{
    // An array is one of the simplest data structures that can store a list of integers, strings, and any type of objects sequentially in memory.
    // In C#, integers typically take 4 bytes of memory. We can access an item in the memory by its index, which is its address in the memory.
    // Pros: Constant-time lookup O(1).
    // Cons: Arrays have a fixed size, and we need to know the size of the array from the beginning before assigning it in memory.
    // We must determine in advance how many items we want to store in an array. If uncertain, we may need to make a guess. If our
    // guess is too large, we waste memory; if it's too small, our array fills up quickly, and to add another item, we have to resize the array.
    // Resizing involves allocating a larger array and copying all the items from the old array to the new one. Insertion time complexity becomes O(n).
    // Removing an item from the last index is the best case scenariowith a time complexity of O(1). However in the worst-case scenario, when removing an item from the first index in the array,
    // all subsequent items need to be shifted to the left, resulting in n operations and a time complexity of O(n).
    // If uncertain about the size of an array and dealing with frequent insertions and deletions alot, a linked list may be a more suitable alternative.
    // Let's create a dynamic Array in C#.
    public class Array
    {
        private int[] items;
        // Represents the count of items currently in the array.
        // Every time we insert an item, we increment the count.
        private int count;

        public Array(int length)
        {
            items = new int[length];
        }

        // Now we have a dynamic array; as the input grows, it will automatically resize.
        public void insert(int item)
        {
            // Resize the array if it is full  
            if (count == items.Length)
            {
                // Create a new array with double the size to accomodate resizing.
                var newItems = new int[count * 2];

                // Copy all the existing items
                for (int i = 0; i < count; i++)
                    newItems[i] = items[i];

                // Set "items" to this new array
                items = newItems;
            }

            // Add the new item at the end
            items[count++] = item;
        }

        public void print()
        {
            //Console.WriteLine(string.Join(" ",items));
            for (int i = 0; i < count; i++)
                Console.WriteLine(items[i]);
        }

        // Removing an item from the last index is the Best case: Deletion in O(1).
        // In the worst case, if we are removing an item from the first index in the array,
        // we need to move all the remaining items to the left, resulting in O(n) operations for Deletion.
        public void removeAt(int index)
        {
            // Validate the index
            if (index < 0 || index >= count)
                throw new Exception();
            // Shift the remaining items to the left to fill the gap created by the removed element.
            // [10, 30, 40]
            // index: 1
            // 1 <- 2
            // 2 <- 3
            for (int i = index; i < count; i++)
            {
                items[i] = items[i + 1];
            }

            // 'count' represents the total number of items in the array, not the size of the array.
            count--;
        }

        // Search operation:
        // The runtime complexity of this method is O(n).
        // Best case: The item is at index 0, resulting in O(1).
        // Worst case: The item is at the last index, resulting in O(n).
        // In the context of runtime complexity analysis, we consider the worst-case scenario, making it O(n).
        public int indexOf(int item)
        {
            // If we find it, return index
            // Otherwise, return -1
            for (int i = 0; i < count; i++)
                if (items[i] == item)
                    return i;

            return -1;
        }
    }
}
