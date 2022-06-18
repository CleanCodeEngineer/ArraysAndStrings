namespace ArraysAndStrings
{
    public class SetZeros_Chapter1_1p8
    {
        // 1.8: Zero Matrix:Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
        // O(N) space
        // Hints:
        // #17: If you just cleared the rows and columns as you found Os, you'd likely wind up clearing 
        // the whole matrix.Try finding the cells with zeros first before making any changes to the
        // matrix.
        // #74: Can you use 0(N) additional space instead of 0(N2)? What information do you really 
        // need from the list of cells that are zero?
        // Solution 1:
        public static void setZeros(int[,] matrix)
        {
            // We use two arrays to keep track of all the rows with zeros and all 
            // the columns with zeros. We then nullify rows and columns based on the values in these arrays. 
            Boolean[] row = new bool[matrix.GetLength(0)];
            Boolean[] col = new Boolean[matrix.GetLength(1)];

            // Store the row and column index with value 0
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = true;
                        col[j] = true;
                    }
                }
            }

            // Nullify rows
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i]) nullifyRow(matrix, i);
            }

            // Nullify columns
            for (int j = 0; j < col.Length; j++)
            {
                if (col[j]) nullifyColumn(matrix, j);
            }
        }

        public static void nullifyRow(int[,] matrix, int row)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = 0;
            }
        }

        public static void nullifyColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, col] = 0;
            }
        }

        // Solution 2:
        // #102: You probably need some data storage to maintain a list of the rows and columns that 
        // need to be zeroed.Can you reduce the additional space usage to O(1) by using the 
        // matrix itself for data storage?
        // We can reduce the space to 0 (1) by using the first row as a replacement for the row array and the first
        // column as a replacement for the column array.This works as follows: 
        // 1. Check if the first row and first column have any zeros, and set variables rowHasZero and
        // columnHasZero. (We'll nullify the first row and first column later, if necessary.) 
        // 2. Iterate through the rest of the matrix, setting matrix[i][0] and matrix [0][j] to zero whenever
        // there's a zero in matrix[i][j]. 
        // 3. Iterate through rest of matrix, nullifying row i if there's a zero in matrix[i][0]. 
        // 4. Iterate through rest of matrix, nullifying column j if there's a zero in matrix[0][j]. 
        // 5. Nullify the first row and first column, if necessary (based on values from Step 1). 
        public static void SetZeros2(int[,] matrix)
        {
            Boolean rowHasZero = false;
            Boolean colHasZero = false;

            // Check if first row has a zero
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[0, j] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            // Check if first column has a zero
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == 0)
                {
                    colHasZero = true;
                    break;
                }
            }

            // Check for zeros in the rest of the array
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            // Nullify rows based on values in first column
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == 0)
                    nullifyRow(matrix, i);
            }

            // Nullify columns based on values in first row
            for(int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[0, j] == 0)
                    nullifyColumn(matrix, j);
            }

            // Nullify first row 
            if (rowHasZero)
                nullifyRow(matrix, 0);

            // Nullify first column
            if (colHasZero)
                nullifyColumn(matrix, 0);
        }
    }
}
