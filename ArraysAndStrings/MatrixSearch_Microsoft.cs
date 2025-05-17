namespace ArraysAndStrings
{
    public class MatrixSearch_Microsoft
    {
        // Microsoft 4th interview Question: 
        // Given an nxm array where all rows and columns are in sorted order,
        // write a function to detemine whether the array contains an element x.
        // [0,   1,  2,  3]
        // [4,   5,  6,  7]
        // [8,   9, 10, 11]
        // [12, 13, 14, 15]

        // O(n + m)
        // contains(arr, 5)
        // row = 1
        // col = 1

        // [4,   5,  6,  7]
        // [8,   9, 10, 11]
        // [12, 13, 14, 15]

        // [4,   5,  6]
        // [8,   9, 10]
        // [12, 13, 14]

        // [4,   5]
        // [8,   9]
        // [12, 13]

        public static Boolean contains(int[,] arr, int x)
        {
            if (arr.GetLength(1) == 0 || arr.GetLength(0) == 0) return false;

            int row = 0;
            int col = arr.GetLength(1) - 1;

            while (row < arr.GetLength(0) && col >= 0)
            {
                if (arr[row, col] == x) return true;

                if (arr[row, col] < x) row++;
                else col--;
            }

            return false;
        }
    }

    // Given a 2D matrix where each row and each column is sorted in ascending order,
    // write a function to find all occurrences of a target value and return their positions.
    public class Matrix
    {
        public class Cell
        {
            public int I { get; set; }
            public int J { get; set; }
        }

        public static List<Cell> FindLocations(int[,] matrix, int target)
        {
            List<Cell> cells = new List<Cell>();
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            int i = 0, j = colCount - 1;

            while (i < rowCount && j >= 0)
            {
                int value = matrix[i, j];
                if (value == target)
                {
                    cells.Add(new Cell { I = i, J = j });
                    j--; // move left to find other duplicates in the row
                }
                else if (value > target)
                {
                    j--; // move left
                }
                else
                {
                    i++; // move down
                }
            }

            return cells;
        }
    }
}
