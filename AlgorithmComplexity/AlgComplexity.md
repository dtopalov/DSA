# Problem 1
```c#
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else 
                end--;
    }
    return count;
}
```
Assuming the size of the array is *n* the expected running time is O(n^2^) because the complexity of the traversal of the whole array is O(n), each iteration of the outer loop causes n more iterations of the inner loop, and the other operations (getting an element by index or incrementing/decrementing variables) is constant, so the total running time is O(n^2^).

# Problem 2

```C#
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```
Here the expected running time is O(n\*m) (assuming sizes *n* and *m*) because the first cycle will run n times and roughly half of these times the inner cycle will run from 0 to m-1 so after ignoring the constants, we get n*m.

# Problem 3
```C#
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++) 
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1)) 
        sum += CalcSum(matrix, row + 1);
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
```
The expected complexity is n*m as the *for* cycle in the CalcSum method is of complexity O(n) and the method itself is called m times, so the total expected running time is O(n\*m). 