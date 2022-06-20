using System;

namespace DataStructures
{
    // Array is one of the simplest data structure that can save list of int, strings and any type of objects sequentialy in memory.
    // integers in java takes 4 bytes of memory. we can access an item in the memory by it's index which is its address in the memory.
    // Pros: Lookup O(1)
    // Cons: Arrays have fixed size, and we should know from the beginning the size of the array that we'd like to assign to in the memory.
    // we need to know ahead of time that how many items we want to store in an array, but if we don't know we have to make a guess. If our
    // guess is too large we waste memory. if our guess is too small our array gets filled quickly then to add another item we have to resize the array.
    // which means we have to allocate a larger array and copy all the items in th old array to the new one. Insert O(n)
    // removing an item from the last index which is the Best case: Delete O(1) and in worst case scenario if we are removing an item from the first index in the array,
    // move all the items to the left so we have n operations: Delete O(n)
    // If we're not sure about the size of an array and we have insertion and deletion alot, we use linked list instead.
    // Dynamic Array
    public class Array
    {
        private int[] items;
        // the count of the items exist in the array
        // every time we insert an item, we will increment the count
        private int count;

        public Array(int length)
        {
            items = new int[length];
        }

        // now we have a dynamic array, as the input grows, it will resize
        public void insert(int item)
        {
            // If the array is full, resize it
            if(count == items.Length)
            {
                // Create a new array (twice the size)
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

        public void removeAt(int index)
        {
            // Validate the index
            if (index < 0 || index >= count)
                throw new Exception();
                // 2 3 4  i = 1 , 2
                // 2 4
                // Shift the items to the left to fill the hole
                // [10, 30, 40]
                // index: 1
                // 1 <- 2
                // 2 <- 3
                for (int i = index; i < count; i++)
                {
                    items[i] = items[i + 1];
                }

                // count is the total number of items in the array, not the size of the array.
                count--;
        }

        // Search operation
        // run time complexity of this method is O(n)
        // Best case the item is at the index 0 so O(1)
        // Worst case scenario it's that the item is at the last index O(n)
        // in the run time complexity we always want the worst case scenario so it's O(n)
        public int indexOf(int item)
        {
            // If we find it, return index
            // Otherwise, return -1
            for(int i = 0; i < count; i++)
                if (items[i] == item)
                    return i;

            return -1;
        }
    }
}
